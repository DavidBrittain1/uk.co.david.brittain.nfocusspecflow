using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.david.brittain.nfocusspecflow.StepDefinitions
{
    [Binding]
    public class Moresteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        public Moresteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["mydriver"];
        }

        [When(@"I search for '(.*)'")]
        public void WhenISearchForDavidBrit(string searchTerm)
        {
            Console.WriteLine((string)_scenarioContext["pagetitle"]);
            _driver.FindElement(By.CssSelector("input[name=q]")).SendKeys(searchTerm + Keys.Enter);
        }
    }
}