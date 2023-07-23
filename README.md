# Azure Resources Deployment Assignment

The purpose of this assignment is to gain hands-on experience in creating Azure resources using shell-based tools and to secure the created resources through Azure Active Directory.

## Pre-requisites

1. Azure Portal with an active subscription
2. Proficiency in working with Azure CLI, PowerShell & Active Directory
3. Git repository: https://github.com/kilmarzo/Deploying-secure-Azure-resources

## Section 1: Create a Web Application using Azure CLI

Developed a .NET web API application and published its code into a Git repository. Created a Resource Group with a randomly assigned unique name, serving as the central container for all subsequent resources, services, and components.

Created and configured a Web Server (App Service Plan) in a free tier, and a Web App hosted within the App Service Plan. Deployed the .NET web API to the Web App. 

The commands for this section are as follows (using PowerShell):

```bash
# Define your variables
$workload = "azure-assignment"
$environment = "prod"
$region = "norwayeast"

# Generate a unique string
$unique_string = -join ((65..90) + (97..122) | Get-Random -Count 6 | % {[char]$_})

# Construct your resource group name
$rg_name="rg-${workload}-${environment}-${region}-${unique_string}"

# Create the resource group
az group create --name $rg_name --location $region
```

Refer to azure_cli_commands.txt for the complete list of commands used.

## Section 2: Create an Azure SQL Database & Secure it with a Firewall using Azure PowerShell

Used the previously created Resource Group and arranged all the resources into it. Created a Sql Database Server with necessary configurations and protected it with an admin username/password. Set up the firewall rule to connect and access the Azure SQL database from any source. Created a Database within SQL Database Server.

The commands for this section are as follows (using PowerShell):

```bash
$serverName = "<server-name>" # The globally unique name for your SQL Server instance
$location = "norwayeast" # The location/region where the SQL Server will be created
$adminSqlLogin = "<admin-username>" # The admin username for the SQL Server
$password = "<admin-password>" # The admin password for the SQL Server
$databaseName = "<database-name>" # The name of the database that you will create on the server

# Firewall rule to allow all incoming connections
az sql server firewall-rule create --resource-group $rg_name --server $serverName -n AllowAll --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255
```

Refer to azure_powershell_scripts.txt for the complete list of commands used.

## Submission

This repository contains:

1. This README, a written description of the deployment process.
2. Azure CLI commands saved in azure_cli_commands.txt.
3. Azure PowerShell scripts saved in azure_powershell_scripts.txt.
4. Screenshots of deployed services in the images/ directory.

## Screenshots

To be added.

---

Just replace "To be added" with the actual screenshots once you upload them to your repository. You can do this by using Markdown's syntax for images, which is `![Description](url)`, replacing `url` with the actual URL to the image file in your repository.

I hope this helps! If you have any other questions, feel free to ask.
