using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseFrame.IdentityServer
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "角色", new List<string> { JwtClaimTypes.Role }),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource("baseframe.core.api", "BaseFrame.Core API") {
                    // include the following using claims in access token (in addition to subject id)
                    //requires using using IdentityModel;
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Role }
                }
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client {
                    ClientId = "webapi",
                    ClientName = "BaseFrame.Core WebApi Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:5000/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5000" },
                    AllowedCorsOrigins =     { "http://localhost:5000" },
                    RequireConsent=true,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "baseframe.core.api"
                    },
                    ClientSecrets={new Secret("secret".Sha256()) }
                },
                new Client
                {
                    ClientId="easyui",
                    ClientName = "easyui vuejs Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris={ "http://localhost:8080/callback" },
                    PostLogoutRedirectUris = { "http://localhost:8080" },
                    AllowedCorsOrigins =     { "http://localhost:8080" },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "baseframe.core.api"
                    }
                }
            };
        }
    }
}
