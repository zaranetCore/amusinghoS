using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json.Linq;
using Xunit;

namespace amusinghos.xUnit.id4.Test
{
   public class idConsole
    {
        [Fact]
        public async Task Main()
        {
            var client = new HttpClient();
            //发现identityserver字典   [Get identityServer Discovery]
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000/");

            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }
            //客户端证书 [Request Access Token] 
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = "XUnit Console Application for identityServer4",
                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                Scope = "api1 openid"
            });
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            //根据证书请求API [Call Api]
            //这里还没有Api，我们还是先试试IdentityServer的openid
            var apiclient = new HttpClient();
            apiclient.SetBearerToken(tokenResponse.AccessToken);
            var response = await apiclient.GetAsync(disco.UserInfoEndpoint);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            Assert.NotNull(disco);
        }
    }
}
