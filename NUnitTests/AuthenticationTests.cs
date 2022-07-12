using framework_core;
using framework_core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ApiTests
{
    /// <summary>
    /// https://docs.thecatapi.com/authentication
    /// </summary>
    public class AuthenticationTests : BaseTestClass
    {

        string _baseUrl = "https://api.thecatapi.com";
        string _authToken;
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            string file = @".\CatsApiDONTCHECKIN.json";
            Logger.Info(System.IO.Directory.GetCurrentDirectory());
            Logger.Info("Full Path of Config File:" + Path.GetFullPath(file));
            this.Config.addJsonConfig(Path.GetFullPath(file));

            this.Config.buildConfigSources();
            this.client = new RestClient(this._baseUrl);

            this._authToken = this.Config.Root.GetSection("apiSettings").GetSection("authToken").Value;
            //this.client.UseNewtonsoftJson();
        }

        /// <summary>
        /// Authenticate with Query Param
        /// The least secure way, and not advisable unless there is no other way.
        /// Intended for use in IoT use-cases & backwards compatibility
        /// Pass as the api_key query parameter
        /// e.g.https://thecatapi.com/v1/images?api_key=ABC123
        /// </summary>
        [Test]
        public async Task CanAuthWithQueryParamAsync()
        {
            RestRequest imageRequest = new("v1/images/search", Method.Get);
            imageRequest.AddQueryParameter("api_key", this._authToken);
            Logger.Info($"Auth Token: {this._authToken}");
            var response = await client.ExecuteAsync(imageRequest);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.IsSuccessful, Is.True);
            Logger.Info($"Response Status Code: {response.StatusCode}");
            //var cont = JsonConvert
            var content = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response.Content);
            Logger.Info($"Url: {content[0]["url"]}");
        }

        /// <summary>
        /// Authenticate with Request Header
        /// The best & most secure way to send it
        /// Set your API Key as the x-api-key header on evey request.
        /// e.g headers[“x - api - key”] = "ABC123"
        /// </summary>
        [Test]
        public async Task CanAuthWithRequestHeaderAsync()
        {
            RestRequest imageRequest = new("v1/images/search", Method.Get);
            imageRequest.AddHeader("x-api-key", this._authToken);
            Logger.Info($"Auth Token: {this._authToken}");
            var response = await client.ExecuteAsync(imageRequest);
            Logger.Info($"Response Status Code: {response.StatusCode}");

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Assert.That(response.IsSuccessful, Is.True);
            });

            //var cont = JsonConvert
            var content = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response.Content);
            Logger.Info($"Url: {content[0]["url"]}");
        }
    }
}