using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseFrame.IdentityServer
{
    public class InMemoryConfig
    {
        /// <summary>
        /// 被保护的api资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("BaseFrame.Core.api","baseframe.core.api")
            };
        }
        /// <summary>
        /// 可以使用本认证服务的客户端
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId="app1",//客户端id
                    ClientSecrets=new []{ new Secret("app1secret".Sha256())},//秘钥
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,//通过用户名密码和ClientCredentials获取token
                    AllowedScopes=new [] { "baseframe.core.api" }//允许访问的api资源
                }
            };
        }
        /// <summary>
        /// 指定可以使用本认证服务授权的用户
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "lkf",
                        Password = "lkf"
                    }
            };
        }
    }
}
