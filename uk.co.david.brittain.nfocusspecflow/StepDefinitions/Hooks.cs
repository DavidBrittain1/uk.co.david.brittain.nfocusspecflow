using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace uk.co.david.brittain.nfocusspecflow.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext) 
        { 
            _scenarioContext = scenarioContext;

        }


        [Before]
        public void Setup()
        {
            driver = new ChromeDriver();
            _scenarioContext["mydriver"] = driver;
        }

        [After]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
