# Bits and Bots Project

Welcome to the Bits and Bots project repository. This repository contains the source code for a web based platform in which young entrepreneurs can advertise their creations, workshops and fundraisers to the general public.

This document will contain the steps for setting up the project workspace. These instructions are for the Windows operating system, the steps may vary slightly for other operating systems.

## Project Setup Instructions
### Install The Required Software
To setup the project you will need Visual Studio Community 2022 or later.
1. Navigate to https://visualstudio.microsoft.com/downloads/.
2. Select the download button for Community.
3. Run the downloaded executable.
4. Select Continue.
5. Select ASP.NET and web development and then select Install.
6. Wait for the installation to complete.

### Clone The Repository
1. Launch Visual Studio 2022.
2. Select Clone a repository
3. Input https://github.com/samlgithubaccount/BitsAndBots.git into the Repository location field.
4. Input a folder where you would like the project to be stored for the Path field.
5. Select Clone.
6. Wait for cloning to complete.

### Run The Project
1. The project should open after cloning is completed and you will be taken to a screen like this.
2. Expand the BitsAndBots item in the Solution Explorer and open appsettings.json
3. Configure the appsettings as required. These settings will be applied on startup of the project.

    a. FileUploadConstraints configures what is allowed for product, event and fundraiser images.
    The defaults shown here will be applied if this is omitted.
    
    b. Administrators configures the administrator users that will be setup automatically when the project is run. 
    Any number of administrators may be specified.
    All 3 fields are required for each administrator and the email and username must be unique.
    
    c. SenderEmailCredentials configures the SMTP settings that will be used by the BitsAndBots website to send a product enquiry notification to the user that listed a product.
    All fields are required.

4. Click the run button at the top to start the project. The dropdown can be used to change it to http if required. The database will be setup automatically when the project runs.
