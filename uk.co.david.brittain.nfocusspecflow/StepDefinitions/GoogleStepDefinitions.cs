using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using static uk.co.david.brittain.nfocusspecflow.StepDefinitions.Hooks;


namespace uk.co.david.brittain.nfocusspecflow.StepDefinitions
{
    [Binding]

    public class GoogleStepDefinitions
    {

        string title;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public GoogleStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["mydriver"];
        }

        [Given(@"Google is open")] // Alternative phrasing
        [Given(@"(?:I|i) am on the (?i)Google(?-i) Homepage")] // Google is case insensitive
        public void GivenIAmOnTheGoogleHomepage()
        {

            _driver.Url = "https://google.co.uk";
            IWebElement acceptButton = _driver.FindElement(By.CssSelector("#L2AGLb"));
            //driver.FindElement(By.XPath)
            acceptButton.Click();
            _scenarioContext["pagetitle"] = _driver.Title;
        }

        //[When(@"I search for '(.*)'")]
        //public void WhenISearchForDavidBrit(string searchTerm)
        //{
        //    Console.WriteLine(title);
        //    _driver.FindElement(By.CssSelector("input[name=q]")).SendKeys(searchTerm + Keys.Enter);
        //}

        [Then(@"'(.*)' is the top result")]
        public void ThenDavidBritIsTheTopResult(string searchResult)
        {
            Thread.Sleep(1000);
            string topsearch = _driver.FindElement(By.CssSelector("div#rso > div:first-of-type")).Text;
            Assert.That(topsearch, Does.Contain(searchResult), "Not in the top result");
            topsearch.Should().Contain("DavidBrit");
        }

        [Then(@"I see in the results")]
        public void ThenISeeInTheResults(Table table)
        {
            string searchResults = _driver.FindElement(By.Id("rso")).Text;
            foreach (var row in table.Rows)
            {
                Assert.That(searchResults, Does.Contain(row["url"]), "Didn't find url");
                Assert.That(searchResults, Does.Contain(row["title"]), "Title is missing");
            }
        }

        // Test

    }
}