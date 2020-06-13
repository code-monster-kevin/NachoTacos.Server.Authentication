using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace NachoTacos.Server.Authentication.IdSvr.Configuration
{
    public class InMemoryConfiguration
    {
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
