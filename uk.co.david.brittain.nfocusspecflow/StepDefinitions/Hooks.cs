using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

//[assembly: Parallelizable(ParallelScope.Fixtures)] //Can only parallelise Features
//[assembly: LevelOfParallelism(4)] //Worker thread i.e. max amount of Features to run in Parallel

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


        [Before("@GUI")]
        public void Setup()
        {
            driver = new ChromeDriver();
            _scenarioContext["mydriver"] = driver;
        }

        [After("@GUI")]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
