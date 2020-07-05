# Adding IdentityServer4 Quickstart UI templates
This will create the views and other ui elements from identityserver templates
1. Install IdentityServer4.Templates
2. Install IdentityServer 4 Quickstart UI
3. Fix build issues with .NET Core 3.1
4. Add MVC and Routing for UI

## Install IdentityServer4.Templates
You can find more details [here](https://github.com/IdentityServer/IdentityServer4.Templates)
```
> dotnet new -i identityserver4.templates
```

## Install IdentityServer 4 Quickstart UI
1. Open a new command prompt
2. Change directory to the Idsvr project folder and run the command:
```

iex ((New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/IdentityServer/IdentityServer4.Quickstart.UI/main/getmain.ps1'))

```

## Fix build issues with .NET Core 3.1
1. Add Package "System.Security.Principal.Windows" Version="4.7.0"
2. Add the necessary missing "using" assemblies

## Add MVC and Routing for UI
1. Add and modify the following at Startup.cs file
```
public void ConfigureServices(IServiceCollection services)
{
  ...

  services.AddMvc();

  ...
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  ...

  app.UseAuthorization();
  
  app.UseEndpoints(endpoints =>
  {
      endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
  });

  ...
}

```