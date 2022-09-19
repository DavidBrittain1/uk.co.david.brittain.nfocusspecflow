using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;

namespace uk.co.david.brittain.nfocusspecflow.StepDefinitions
{

    [Binding]
    public class APISteps
    {
        private readonly ScenarioContext _scenarioContext;

        RestClient client;
        RestResponse response;
        public APISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"I request user number (.*)")]
        public void WhenIRequestUserNumber(int p0)
        {
            // Options object to pass to RestClient on creation
            RestClientOptions clientOptions = new RestClientOptions("http://localhost:2002/api");

            // Create the client
            client = new RestClient(clientOptions)
            {
                Authenticator = new HttpBasicAuthenticator("edge", "edgewords")
            };

            RestRequest request = new RestRequest("users/" + p0, Method.Get);

            response = client.Execute(request);
        }

        [Then(@"I get a (.*) response code")]
        public void ThenIGetAResponseCode(int receivedStatusCode)
        {
            int status = (int)response.StatusCode;
            Assert.That(status, Is.EqualTo(receivedStatusCode), "Wrong Status"); // NUnit Assertion Style
            status.Should().Be(receivedStatusCode); // Fluent Assertion Style
        }

        [Then(@"the user is '(.*)'")]
        public void ThenTheUserIs(string name)
        {
            Assert.That(response.Content, Does.Contain(name), "Wrong User");
            response.Content.Should().Contain(name);
        }
    }
}

