using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace NachoTacos.Server.Authentication.IdSvr.Configuration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("nachotacos","Nacho Tacos")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client
                {
                    ClientId="nachotacosclient",
                    ClientSecrets= new [] { new Secret("nachocheese".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "nachotacos" }

                },
                new Client
                {
                    ClientId = "nachotacosweb",
                    ClientSecrets= new [] { new Secret("nachotuesday".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,
                    RedirectUris = { "https://localhost:44371/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44371/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
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
                Password = "testuser1pass"
            };

            TestUser testUser2 = new TestUser
            {
                SubjectId = "002",
                Username = "testuser2@nachotacos.com",
                Password = "testuser2pass"
            };

            return new[]
            {
                testUser1,
                testUser2
            };
        }
    }
}
