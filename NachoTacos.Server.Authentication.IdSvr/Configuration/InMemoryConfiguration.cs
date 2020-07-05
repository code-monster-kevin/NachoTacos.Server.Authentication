using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace NachoTacos.Server.Authentication.IdSvr.Configuration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("nachotacosapi","Nacho Tacos API")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "0c680cfc-8c69-4671-a6f4-59bebc1b343f",
                    ClientName = "Nacho Tacos Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44371/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44371/signout-callback-oidc" },
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "nachotacosapi"
                    }
                }
            };
        }

        public static IEnumerable<TestUser> TestUsers()
        {
            TestUser testUser1 = new TestUser
            {
                SubjectId = "001",
                Username = "testuser1@nachotacos.com",
                Password = "testuser1pass",
                Claims = new[]
                {
                    new Claim("name", "Test User 1"),
                    new Claim("email", "testuser1@nachotacos.com")
                }
            };

            TestUser testUser2 = new TestUser
            {
                SubjectId = "002",
                Username = "testuser2@nachotacos.com",
                Password = "testuser2pass",
                Claims = new[]
                {
                    new Claim("name", "Test User 2"),
                    new Claim("email", "testuser2@nachotacos.com")
                }
            };

            return new[]
            {
                testUser1,
                testUser2
            };
        }
    }
}
