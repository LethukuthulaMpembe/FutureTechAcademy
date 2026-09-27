# FutureTechAcademy

**Student Management Web Application**

FutureTechAcademy is an ASP.NET Core web application developed using C# and .NET. The project demonstrates practical software development skills through cloud database integration, file storage, authentication, and secure application configuration.

## About the Project

The application provides a platform for managing student information and integrates Microsoft Azure services for cloud-based data and file storage.

It was developed as an academic and portfolio project to gain practical experience in backend development, cloud technologies, authentication, and version control.

## Tech Stack

* C#
* ASP.NET Core
* .NET 10
* Azure Cosmos DB
* Azure Blob Storage
* Google OAuth 2.0
* HTML & CSS
* Git & GitHub
* Visual Studio

## Features

**Student Management**
Manage student information stored in Azure Cosmos DB.

**Cloud Database**
Uses Azure Cosmos DB as the application's cloud-based NoSQL database.

**Image Storage**
Uses Azure Blob Storage to store student images separately from application data.

**Google Authentication**
Integrates Google OAuth 2.0 for user authentication.

**Secure Configuration**
Uses ASP.NET Core User Secrets to keep development credentials outside the source code repository.

## Architecture

```text
                    FutureTechAcademy
                           │
                    ASP.NET Core / C#
                           │
             ┌─────────────┼─────────────┐
             │             │             │
             ▼             ▼             ▼
        Cosmos DB     Blob Storage   Google OAuth
        Student Data   Images        Authentication
```

## Project Structure

```text
FutureTechAcademy/
│
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── Properties/
│
├── appsettings.json
├── Program.cs
└── FutureTechAcademy.csproj
```

## Configuration

Sensitive credentials are **not stored in the GitHub repository**.

The application uses:

* `appsettings.json` for general application configuration
* ASP.NET Core User Secrets for local development credentials

Example configuration:

```json
{
  "AzureSettings": {
    "CosmosConnectionString": "",
    "DatabaseName": "FutureTechDB",
    "ContainerName": "Students",
    "BlobConnectionString": "",
    "BlobContainerName": "student-images"
  },
  "Authentication": {
    "Google": {
      "ClientId": "",
      "ClientSecret": ""
    }
  }
}
```

> Never commit real connection strings, API keys, passwords, or OAuth client secrets to Git.

## Getting Started

### Requirements

* Visual Studio
* .NET 10 SDK
* Azure Cosmos DB
* Azure Storage Account
* Google Cloud project with OAuth credentials

### Clone the Repository

```bash
git clone <repository-url>
cd FutureTechAcademy
```

### Configure User Secrets

In Visual Studio:

**Solution Explorer → Right-click FutureTechAcademy → Manage User Secrets**

Add the required Azure and Google credentials to the local `secrets.json` file.

### Run the Application

Open the project in Visual Studio and select **Start** or press:

```text
Ctrl + F5
```

## Future Improvements

* Administrative dashboard
* Role-based access control
* Student search and filtering
* Course and enrollment management
* Improved validation and error handling
* Automated testing
* CI/CD with GitHub Actions
* Azure deployment
* Improved responsive UI

## Author

**Lethukuthula Mpembe**

ICT Applications Development Student
Durban University of Technology

GitHub: **LethukuthulaMpembe**

---

*Academic and portfolio project focused on software development and cloud integration.*

