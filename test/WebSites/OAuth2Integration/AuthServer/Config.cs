﻿using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace OAuth2Integration.AuthServer
{
    public static class Config
    {
        internal static IEnumerable<Client> Clients()
        {
            yield return new Client
            {
                AllowAccessTokensViaBrowser = true,
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowedScopes = new[] { "readAccess", "writeAccess" },
                ClientId = "test-id",
                ClientName = "test-app",
                ClientSecrets = new[] { new Secret("test-secret".Sha256()) },
                RedirectUris = new[] {
                    "http://localhost:50581/resource-server/swagger/oauth2-redirect.html", // IIS Express
                    "http://localhost:5000/resource-server/swagger/oauth2-redirect.html", // Kestrel
                }
            };
        }

        internal static IEnumerable<ApiResource> ApiResources()
        {
            yield return new ApiResource
            {
                Name = "api",
                DisplayName = "API",
                Scopes = new[]
                {
                    new Scope("readAccess", "Access read operations"),
                    new Scope("writeAccess", "Access write operations")
                }
            };
        }

        internal static List<TestUser> TestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "joebloggs",
                    Username = "joebloggs",
                    Password = "pass123"
                }
            };
        }
    }
}
