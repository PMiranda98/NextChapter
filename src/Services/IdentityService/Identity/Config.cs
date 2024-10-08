﻿using Duende.IdentityServer.Models;

namespace Identity
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
                //new ApiScope("scope1"),
                //new ApiScope("scope2"),
                new ApiScope("advertisementApp", "Advertisement app full access"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //This is just for development
                new Client()
                {
                    ClientId="postman",
                    ClientName="Postman",
                    ClientSecrets = { new Secret("NotASecret".Sha256()) },
                    AllowedScopes = { "openid", "profile", "advertisementApp" },
                    //Just because is needed
                    RedirectUris = { "https://www.getpostman.com/oauth2/callback" },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword
                },
                new Client()
                {
                    ClientId="nextApp",
                    ClientName="nextApp",
                    ClientSecrets={ new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequirePkce = false,
                    RedirectUris = {"http://localhost:3000/api/auth/callback/id-server"},
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "advertisementApp" },
                    AccessTokenLifetime = 3600*24*30,
                    AlwaysIncludeUserClaimsInIdToken = true,
                }


                //// m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "scope1" }
                //},

                //// interactive client using code flow + pkce
                //new Client
                //{
                //    ClientId = "interactive",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44300/signin-oidc" },
                //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "scope2" }
                //},
            };
    }
}
