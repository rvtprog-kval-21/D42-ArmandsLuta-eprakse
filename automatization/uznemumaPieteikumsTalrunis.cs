using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.unregistered.uznemumaPieteikumsdomain;


namespace uznPietTalrunis.Tests{
    [TestFixture]
    public class uznemumaPieteikumsTalrunis{

        IWebDriver _driver;

        [SetUp]
        public void SetUp() {
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");  
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
            _driver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/Pieteikties/uznemuma-pieteikums/");  
            _driver.Manage().Window.Maximize();  
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void testNederBurti(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputTalrunis("gfdgsdf");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Nederīgs telefona Nr. Jābūt 8 cipariem."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputTalrunis("12345678");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Nederīgs telefona Nr. Jābūt 8 cipariem."){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void testnedertoomanynumb(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputTalrunis("3213151351354564");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Nederīgs telefona Nr. Jābūt 8 cipariem."){
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