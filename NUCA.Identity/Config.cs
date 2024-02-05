// Copyright (c) Brock Allen & Dominick Baier. AllPermissions rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace NUCA.Identity
{
    public static class Config
    {
        public static string FrontendUri => "http://localhost:4200";
        public static string ProductionFrontendUri => "http://192.168.8.100";
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]
           {
                 new ApiResource("projects", "Projects Api")
                 {
                     Scopes ={"projects.fullaccess"},
                 },
                 new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
           };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                 new ApiScope("projects.fullaccess"),
                 new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
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
                    RedirectUris = new List<string>{ $"{FrontendUri}/auth/signin-callback", $"{FrontendUri}/auth/signout-callback", $"{ProductionFrontendUri}/auth/signin-callback", $"{ProductionFrontendUri}/auth/signout-callback"},
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        "projects.fullaccess",
                        IdentityServerConstants.LocalApi.ScopeName,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    AllowedCorsOrigins = { FrontendUri, ProductionFrontendUri},
                    RequireClientSecret = false,
                    PostLogoutRedirectUris = new List<string> { $"{FrontendUri}/auth/signout-callback" , $"{ProductionFrontendUri}/auth/signout-callback"},
                    RequireConsent = false,
                    AccessTokenLifetime = 6000
                },
            };
    }
}