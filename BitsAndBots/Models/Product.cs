﻿using BitsAndBots.Data;
using BitsAndBots.Validators;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class Product
    {
        public long Id { get; set; }
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [Required]
        public string Title { get; set; }
        [StringLength(3000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 20)]
        [Required]
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdatedTimestamp { get; set; }
        public string CreatedUserId { get; set; }
        public ApplicationUser CreatedUser { get; set; }
        [Range(0, 999999999D)]
        public double? Price { get; set; }
        [Display(Name = "Quantity Available")]
        [Range(0, Int32.MaxValue)]
        public int? Quantity { get; set; }
        [StringLength(150, ErrorMessage = "{0} may only contain up to {1} characters.")]
        [TagValidator(ErrorMessage = "{0} must not contain whitespace.")]
        public string? Tags { get; set; }
        [MinLength(1, ErrorMessage = "A minimum of 1 Image is required.")]
        public IList<ProductImage> Images { get; set; } = [];
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Required]
        public string Location { get; set; }
    }
}
