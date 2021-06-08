using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.PraktIkdDarbs;
using eprakse.unregistered.Login;


namespace praktIkdDarbSak.Tests{
    [TestFixture]
    public class praktIkdDarbSakTests{


        IWebDriver _driver;

        [SetUp]
        public void SetUp() {
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");  
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
            Loginpage login = new Loginpage(_driver);
            login.goToPage();
            login.inputUsername("LielaisKristaps");
            login.inputPassword("KriDru6709!");
            login.clickLogin();
            PraktIkdDarbs praktKont = new PraktIkdDarbs(_driver);
            try {
            praktKont.goToPage();
            } catch (UnhandledAlertException) {
                try {
                _driver.SwitchTo().Alert().Accept();
                } catch (NoAlertPresentException){}
            }

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void testNederBurti(){
            bool hasError = false;
            PraktIkdDarbs dienIer = new PraktIkdDarbs(_driver);

            dienIer.inputDarbuSaku("%^*@#$()+-:;{}[]~`|\\<>");
            dienIer.clickSave();
            IList <IWebElement> errors = dienIer.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Laikam jābūt ievadītām pareizi, piem: \"13:20\""){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            PraktIkdDarbs dienIer = new PraktIkdDarbs(_driver);

            dienIer.inputDarbuSaku("12:20");
            dienIer.clickSave();
            IList <IWebElement> errors = dienIer.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Laikam jābūt ievadītām pareizi, piem: \"13:20\""){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void testnedersimboli(){
            bool hasError = false;
            PraktIkdDarbs dienIer = new PraktIkdDarbs(_driver);

            dienIer.inputDarbuSaku("323:3211");
            dienIer.clickSave();
            IList <IWebElement> errors = dienIer.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Laikam jābūt ievadītām pareizi, piem: \"13:20\""){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }

        [Test]
        public void testnederAlfabets(){
            bool hasError = false;
            PraktIkdDarbs dienIer = new PraktIkdDarbs(_driver);

            dienIer.inputDarbuSaku("asdasdasd");
            dienIer.clickSave();
            IList <IWebElement> errors = dienIer.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Laikam jābūt ievadītām pareizi, piem: \"13:20\""){
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