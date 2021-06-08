using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.macDala;
using eprakse.unregistered.Login;


namespace macDalaJaunsVards.Tests
{
    [TestFixture]
    public class macDalaJaunsVardsTests{


        IWebDriver _driver;

        [SetUp]
        public void SetUp() {
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");  
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
            Loginpage login = new Loginpage(_driver);
            login.goToPage();
            login.inputUsername("RVTAdmin");
            login.inputPassword("KriDru6709!");
            login.clickLogin();
            macDalapage macDalaNewLiet = new macDalapage(_driver);
            macDalaNewLiet.goToPage();

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void testNederBurti(){
            bool hasError = false;
            macDalapage macDalaNewLiet = new macDalapage(_driver);

            macDalaNewLiet.clickNewLiet();
            System.Threading.Thread.Sleep(1000);
            macDalaNewLiet.inputVards("ррвпрп");
            macDalaNewLiet.clickSaveNew();
            IList <IWebElement> errors = macDalaNewLiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vāŗdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            macDalapage macDalaNewLiet = new macDalapage(_driver);

            macDalaNewLiet.clickNewLiet();
            System.Threading.Thread.Sleep(1000);
            macDalaNewLiet.inputVards("Kristaps");
            macDalaNewLiet.clickSaveNew();
            IList <IWebElement> errors = macDalaNewLiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vāŗdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void testnedersimboli(){
            bool hasError = false;
            macDalapage macDalaNewLiet = new macDalapage(_driver);

            macDalaNewLiet.clickNewLiet();
            System.Threading.Thread.Sleep(1000);
            macDalaNewLiet.inputVards("%^*@#$()+-:;{}[]~`|\\<>");
            macDalaNewLiet.clickSaveNew();
            IList <IWebElement> errors = macDalaNewLiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vāŗdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }

        [Test]
        public void testnedercipari(){
            bool hasError = false;
            macDalapage macDalaNewLiet = new macDalapage(_driver);

            macDalaNewLiet.clickNewLiet();
            System.Threading.Thread.Sleep(1000);
            macDalaNewLiet.inputVards("31251356");
            macDalaNewLiet.clickSaveNew();
            IList <IWebElement> errors = macDalaNewLiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vāŗdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}