# \# FutureTechAcademy

# 

# \*\*FutureTechAcademy\*\* is a cloud-connected student management web application built with \*\*ASP.NET Core and C#\*\*. The project demonstrates the development of a modern web application that integrates cloud-based data storage, file storage, and third-party authentication.

# 

# \## Project Overview

# 

# The application provides a platform for managing student information while integrating Microsoft Azure services for cloud storage and Google OAuth for authentication.

# 

# The project was developed to strengthen practical experience in \*\*backend development, database integration, cloud services, authentication, and secure application configuration\*\*.

# 

# \## Technology Stack

# 

# \* \*\*C#\*\*

# \* \*\*ASP.NET Core\*\*

# \* \*\*.NET 10\*\*

# \* \*\*Azure Cosmos DB\*\*

# \* \*\*Azure Blob Storage\*\*

# \* \*\*Google OAuth 2.0\*\*

# \* \*\*HTML / CSS\*\*

# \* \*\*Git \& GitHub\*\*

# \* \*\*Visual Studio\*\*

# 

# \## Core Features

# 

# \### Student Management

# 

# The application provides functionality for working with student records stored in Azure Cosmos DB.

# 

# \### Azure Cosmos DB

# 

# Student information is stored in \*\*Azure Cosmos DB\*\*, providing a scalable cloud-based NoSQL data layer for the application.

# 

# \### Azure Blob Storage

# 

# Student images are stored in \*\*Azure Blob Storage\*\*, separating file storage from the application's primary data storage.

# 

# \### Google Authentication

# 

# The application integrates \*\*Google OAuth 2.0\*\* to support authentication through Google accounts.

# 

# \### Secure Configuration

# 

# Sensitive credentials are separated from the application's source code.

# 

# The project uses:

# 

# \* `appsettings.json` for non-sensitive application configuration

# \* \*\*ASP.NET Core User Secrets\*\* for local development credentials

# 

# No real connection strings, API keys, or OAuth secrets are stored in the GitHub repository.

# 

# \## Application Architecture

# 

# ```text

# ┌──────────────────────────────┐

# │        Web Application       │

# │       ASP.NET Core / C#      │

# └──────────────┬───────────────┘

# &#x20;              │

# &#x20;      ┌───────┴────────┐

# &#x20;      │                │

# &#x20;      ▼                ▼

# ┌─────────────┐  ┌───────────────┐

# │ Azure       │  │ Azure Blob    │

# │ Cosmos DB   │  │ Storage       │

# │             │  │               │

# │ Student     │  │ Student       │

# │ Data        │  │ Images        │

# └─────────────┘  └───────────────┘

# 

# &#x20;              │

# &#x20;              ▼

# &#x20;       ┌───────────────┐

# &#x20;       │ Google OAuth  │

# &#x20;       │ Authentication│

# &#x20;       └───────────────┘

# ```

# 

# \## Project Structure

# 

# ```text

# FutureTechAcademy/

# │

# ├── Controllers/

# │   └── Application controllers

# │

# ├── Models/

# │   └── Application models

# │

# ├── Views/

# │   └── Razor views

# │

# ├── wwwroot/

# │   └── Static files

# │

# ├── Properties/

# │

# ├── appsettings.json

# ├── Program.cs

# └── FutureTechAcademy.csproj

# ```

# 

# \## Configuration

# 

# The project separates application configuration from sensitive credentials.

# 

# \### `appsettings.json`

# 

# Only non-sensitive configuration should be committed to source control.

# 

# ```json

# {

# &#x20; "AzureSettings": {

# &#x20;   "CosmosConnectionString": "",

# &#x20;   "DatabaseName": "FutureTechDB",

# &#x20;   "ContainerName": "Students",

# &#x20;   "BlobConnectionString": "",

# &#x20;   "BlobContainerName": "student-images"

# &#x20; },

# &#x20; "Authentication": {

# &#x20;   "Google": {

# &#x20;     "ClientId": "",

# &#x20;     "ClientSecret": ""

# &#x20;   }

# &#x20; }

# }

# ```

# 

# \### User Secrets

# 

# Local development credentials are stored using \*\*ASP.NET Core User Secrets\*\*.

# 

# Example structure:

# 

# ```json

# {

# &#x20; "AzureSettings": {

# &#x20;   "CosmosConnectionString": "YOUR\_COSMOS\_CONNECTION\_STRING",

# &#x20;   "BlobConnectionString": "YOUR\_STORAGE\_CONNECTION\_STRING"

# &#x20; },

# &#x20; "Authentication": {

# &#x20;   "Google": {

# &#x20;     "ClientId": "YOUR\_GOOGLE\_CLIENT\_ID",

# &#x20;     "ClientSecret": "YOUR\_GOOGLE\_CLIENT\_SECRET"

# &#x20;   }

# &#x20; }

# }

# ```

# 

# > \*\*Security:\*\* Never commit real credentials, connection strings, API keys, or OAuth client secrets to source control.

# 

# \## Getting Started

# 

# \### Prerequisites

# 

# \* Visual Studio

# \* .NET 10 SDK

# \* An Azure account

# \* Azure Cosmos DB

# \* Azure Storage Account

# \* Google Cloud project with OAuth credentials

# 

# \### Clone the Repository

# 

# ```bash

# git clone <repository-url>

# cd FutureTechAcademy

# ```

# 

# \### Configure User Secrets

# 

# In Visual Studio:

# 

# \*\*Solution Explorer → Right-click FutureTechAcademy → Manage User Secrets\*\*

# 

# Add the required Azure and Google configuration values.

# 

# \### Run the Application

# 

# Open the solution in Visual Studio and run the application using:

# 

# ```text

# Ctrl + F5

# ```

# 

# or the Visual Studio \*\*Start\*\* button.

# 

# \## Development Focus

# 

# This project focuses on practical implementation of:

# 

# \* Backend web development

# \* C# and ASP.NET Core

# \* Cloud database integration

# \* Cloud file storage

# \* OAuth authentication

# \* Configuration management

# \* Secure handling of application secrets

# \* Git and GitHub version control

# 

# \## Future Improvements

# 

# Planned improvements could include:

# 

# \* Role-based access control

# \* Administrative dashboard

# \* Student search and filtering

# \* Pagination

# \* Course and enrollment management

# \* Improved validation and error handling

# \* Automated unit and integration testing

# \* CI/CD with GitHub Actions

# \* Deployment to Microsoft Azure

# \* Improved responsive UI

# 

# \## Author

# 

# \### Lethukuthula Mpembe

# 

# \*\*ICT Applications Development Student | Aspiring Software Developer\*\*

# 

# Durban University of Technology

# 

# GitHub: \*\*LethukuthulaMpembe\*\*

# 

# \---

# 

# \*Built as an academic and portfolio project to demonstrate practical software development and cloud integration skills.\*



