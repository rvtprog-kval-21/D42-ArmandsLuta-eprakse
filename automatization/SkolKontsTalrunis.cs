using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.SkolKontPiest;
using eprakse.unregistered.Login;


namespace skolKontTalrunis.Tests
{
    [TestFixture]
    public class skolKontTalrunisTests{


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
            SkolKontPiest skolotKont = new SkolKontPiest(_driver);
            skolotKont.goToPage();

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void testNederBurti(){
            bool hasError = false;
            SkolKontPiest skolotKont = new SkolKontPiest(_driver);

            skolotKont.inputTalrunis("ррвпрп");
            skolotKont.clickSave();
            IList <IWebElement> errors = skolotKont.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Tālrunis jāievada pareizi"){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            SkolKontPiest skolotKont = new SkolKontPiest(_driver);

            skolotKont.inputTalrunis("12345678");
            skolotKont.clickSave();
            IList <IWebElement> errors = skolotKont.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Tālrunis jāievada pareizi"){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void testnedersimboli(){
            bool hasError = false;
            SkolKontPiest skolotKont = new SkolKontPiest(_driver);

            skolotKont.inputTalrunis("asddgdh");
            skolotKont.clickSave();
            IList <IWebElement> errors = skolotKont.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Tālrunis jāievada pareizi"){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }

        [Test]
        public void testnedercipari(){
            bool hasError = false;
            SkolKontPiest skolotKont = new SkolKontPiest(_driver);

            skolotKont.inputTalrunis("5346576865467345123423");
            skolotKont.clickSave();
            IList <IWebElement> errors = skolotKont.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Tālrunis jāievada pareizi"){
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