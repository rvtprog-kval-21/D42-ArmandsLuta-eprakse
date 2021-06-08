using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.unregistered.uznemumaPieteikumsdomain;


namespace uznemumaPieteikumsDomain.Tests{
    [TestFixture]
    public class uznemumaPieteikumsDomainTests{

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

            uznPiet.inputMajaslapa("раырр");
            uznPiet.inputEpasts("kristaps.druva@раырр");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jāievada pareiza mājaslapa: majaslapa.lv"){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputMajaslapa("rvt.com");
            uznPiet.inputEpasts("kristaps.druva@rvt.com");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jāievada pareiza mājaslapa: majaslapa.lv"){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void testnedersimboli(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputMajaslapa("%^*@#$()+-:;{}[]~`|\\<>.lv");
            uznPiet.inputEpasts("kristaps.druva@%^*@#$()+-:;{}[]~`|\\<>.lv");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jāievada pareiza mājaslapa: majaslapa.lv"){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void testnavupdomain(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputMajaslapa("rvt");
            uznPiet.inputEpasts("kristaps.druva@rvt");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jāievada pareiza mājaslapa: majaslapa.lv"){
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