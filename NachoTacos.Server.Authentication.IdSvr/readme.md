# Nacho Tacos Server Authentication IdSvr

1. Add a new project ASP .NET Core Web Application (3.1) Empty Template
2. Add package "IdentityServer4" Version="3.1.3"
3. Setup Resources, Clients, Users
4. Configure Startup.cs for IdentityServer4

## Setup Resources, Clients, Users
1. Resources - which API Resources can use
2. Clients - which applications can use
3. Users - which users can use

refer to the source code ~\Configuration\InMemoryConfiguration.cs


## Configure Startup.cs for IdentityServer4

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddTestUsers(InMemoryConfiguration.TestUsers().ToList())
                    .AddInMemoryClients(InMemoryConfiguration.Clients())
                    .AddInMemoryApiResources(InMemoryConfiguration.ApiResources());
}
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...

    app.UseIdentityServer();

    ...
}

```


## Launch settings to launch from console
Remove the IIS Settings and IIS Express profile
Open the file ~\Properties\launchSettings.json
Replace the current settings
```
{
  "iisSettings": {
    "windowsAuthentication": false, 
    "anonymousAuthentication": true, 
    "iisExpress": {
      "applicationUrl": "http://localhost:51454",
      "sslPort": 44361
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "NachoTacos.Server.Authentication.IdSvr": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
Delete the IIS Settings and IIS Express profile
```
{
  "profiles": {
    "NachoTacos.Server.Authentication.IdSvr": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:51454",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```