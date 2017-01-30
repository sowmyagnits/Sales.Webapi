using Microsoft.Owin.Testing;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderWebAPI.Tests
{
    [TestFixture]
    public class LoginTests
    {
       
        [Test]
        public async Task GetToken_withValidUser_ReturnsToken()
        {
            var loginUserModel = TestDataProvider.GetLoginUserModel();           
            
            using (var tokenServer = TestServer.Create<TestStartupRegUser>())
            {
                var tokenResponse = await tokenServer.CreateRequest("/token").And(x => x.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", loginUserModel.Email),
                    new KeyValuePair<string, string>("password", loginUserModel.PasswordHash),
                    new KeyValuePair<string, string>("grant_type", "password"),
                })).PostAsync();

                Assert.That(tokenResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            }
        }


        [Test]
        public async Task GetToken_withInValidUser_ReturnsToken()
        {
            var loginUserModel = TestDataProvider.GetLoginUserModel();

            using (var testServer = TestServer.Create<TestStartupNonRegUser>())
            {
                var tokenResponse = await testServer.CreateRequest("/token").And(x => x.Content = new FormUrlEncodedContent(new[]
               {
                    new KeyValuePair<string, string>("username", loginUserModel.Email),
                    new KeyValuePair<string, string>("password", loginUserModel.PasswordHash),
                    new KeyValuePair<string, string>("grant_type", "password"),
                })).PostAsync();

                Assert.That(tokenResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest)); 
            }

            
        }


    }
}
