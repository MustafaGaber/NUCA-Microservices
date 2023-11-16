// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace NUCA.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                 new ApiScope("projects.fullaccess"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                  // m2m client credentials flow client
              /* new Client
                {
                    ClientId = "m2m.projects",
                    ClientName = "Projects Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("51153AEF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "projects.fullaccess" }
                },*/

                // interactive client using code flow + pkce
               new Client
                {
                    ClientName = "Angular Client",
                    ClientId = "angular-client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{ "http://localhost:4200/auth/signin-callback", "http://localhost:4200/auth/signout-callback"},
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "projects"
                    },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    RequireClientSecret = false,
                    PostLogoutRedirectUris = new List<string> { "http://localhost:4200/auth/signout-callback" },
                    RequireConsent = false,
                    AccessTokenLifetime = 6000
                },
            };
    }
}