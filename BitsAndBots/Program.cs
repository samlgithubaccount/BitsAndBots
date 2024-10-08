using BitsAndBots.Components;
using BitsAndBots.Components.Account;
using BitsAndBots.Configuration;
using BitsAndBots.Data;
using BitsAndBots.Service;
using BitsAndBots.Validators;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<UserService>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

var administrators = builder.Configuration.GetSection("Administrators").Get<List<AdministratorUser>>();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string role = "Administrator";
    if (!(await roleManager.RoleExistsAsync(role)))
    {
        await roleManager.CreateAsync(new IdentityRole(role));
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    if (administrators != null && administrators.Any())
    {
        ILogger logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        IUserStore<ApplicationUser> userStore = scope.ServiceProvider.GetRequiredService<IUserStore<ApplicationUser>>();

        foreach (var admin in administrators)
        {
            if (admin == null)
            {
                logger.LogWarning("Administrator not setup due to null value.");
                continue;
            }

            if (string.IsNullOrWhiteSpace(admin.Email) || string.IsNullOrWhiteSpace(admin.UserName) || string.IsNullOrWhiteSpace(admin.Password))
            {
                logger.LogWarning("Administrator not setup. Email, UserName and Password must be specified.");
                continue;
            }

            admin.Email = admin.Email?.Trim();
            admin.UserName = admin.UserName?.Trim();
            admin.Password = admin.Password?.Trim();

            if (!new EmailAddressAttribute().IsValid(admin.Email))
            {
                logger.LogWarning("Administrator not setup. Email address is invalid.");
                continue;
            }

            if (!new UsernameCharacterValidator().IsValid(admin.UserName))
            {
                logger.LogWarning("Administrator not setup. The Username may only contain alphanumeric characters, underscores and hyphens.");
                continue;
            }

            var usernameStringLengthAttribute = new StringLengthAttribute(30)
            {
                MinimumLength = 1,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long."
            };
            if (!usernameStringLengthAttribute.IsValid(admin.UserName))
            {
                logger.LogWarning($"Administrator not setup. {usernameStringLengthAttribute.FormatErrorMessage("Username")}");
                continue;
            }

            var passwordStringLengthAttribute = new StringLengthAttribute(100)
            {
                MinimumLength = 6,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long."
            };
            if (!passwordStringLengthAttribute.IsValid(admin.Password))
            {
                logger.LogWarning($"Administrator not setup. {passwordStringLengthAttribute.FormatErrorMessage("Password")}");
                continue;
            }

            var existingUser = await userManager.FindByEmailAsync(admin.Email);
            if (existingUser != null)
            {
                logger.LogWarning($"Administrator not setup. An administrator with the email {admin.Email} already exists.");
                continue;
            }

            existingUser = await userManager.FindByNameAsync(admin.UserName);
            if (existingUser != null)
            {
                logger.LogWarning($"Administrator not setup. An administrator with the Username {admin.UserName} already exists.");
                continue;
            }

            var user = Activator.CreateInstance<ApplicationUser>();
            await userStore.SetUserNameAsync(user, admin.UserName, CancellationToken.None);
            await ((IUserEmailStore<ApplicationUser>)userStore).SetEmailAsync(user, admin.Email, CancellationToken.None);
            var createUserResult = await userManager.CreateAsync(user, admin.Password);

            if (createUserResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                logger.LogInformation($"Administrator '{admin.Email}' created.");

                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmEmailResult = await userManager.ConfirmEmailAsync(user, code);
            }
            else
            {
                logger.LogWarning($"Administrator not setup. Errors: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
            }
        }
    }
}

app.Run();
