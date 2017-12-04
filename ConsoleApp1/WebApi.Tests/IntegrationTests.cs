using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;

namespace WebApi.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private readonly TestServer _testServer;
        private readonly HttpClient _client;

        public IntegrationTests()
        {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _testServer.CreateClient();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testServer?.Dispose();
            _client?.Dispose();
        }

        [TestMethod]
        public void Home_Heartbeat_ShouldReturnOk()
        {
            var response = _client.GetAsync("").Result;
            response.EnsureSuccessStatusCode();
            var message = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("Ok.", message);
        }

        [TestMethod]
        public void Messages_GetMessage_ShouldReturnHelloWorld()
        {
            var response = _client.GetAsync("api/messages").Result;
            response.EnsureSuccessStatusCode();
            var message = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("Hello World", message);
        }
    }
}
