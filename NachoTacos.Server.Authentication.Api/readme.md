# Nacho Tacos Server Authentication Api
.NET Core 3.1 Web Application API Project for testing authentication

1. Enable XML Documentation
2. Setup Swagger
3. Setup JWTBearer Token Authentication

## Enable XML Documentation
1. From API Project Properties
2. Select the "Build" tab
3. Select "All configurations"
4. Check/enable the XML Documentation File
5. Disable the warning messages for documentation
```
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    ...
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>
```

## Setup Swagger
NOTE: Enable XML Documentation before set up swagger
1. Add Package "Swashbuckle.AspNetCore"
2. Configure Startup.cs
```
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

public void ConfigureServices(IServiceCollection services)
{
    ...

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "NachoTacos Server Authentication Api", Version = "v1" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
        c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Basic token authentication",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.OperationFilter<SecurityRequirementsOperationFilter>();
    });

    ...
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...

    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AffinHwang DataContext ARMS API");
        c.RoutePrefix = string.Empty;
    });

    ...
}
```

## Setup JWTBearer Token Authentication
1. Add package "Microsoft.AspNetCore.Authentication.JwtBearer" Version="3.1.5"
2. Add JWTBearer Authentication Startup.cs

```
public void ConfigureServices(IServiceCollection services)
{
  ...

  string tokenAuthority = Configuration.GetValue<string>("Authentication:Authority");
  string tokenAudience = Configuration.GetValue<string>("Authentication:Audience");
  services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.Audience = tokenAudience;
              options.Authority = tokenAuthority;
          });
  
  ...
}

```



### Useful Tools
https://jwt.io/