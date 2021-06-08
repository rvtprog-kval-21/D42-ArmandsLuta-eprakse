using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.unregistered.skolasPieteikums;


namespace skolaspieteikumsMajas.Tests{
    [TestFixture]
    public class skolaspieteikumsMajasTests{


        IWebDriver _driver;

        [SetUp]
        public void SetUp() {
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");  
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
            _driver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/Pieteikties/skolas-pieteikums/");  
            _driver.Manage().Window.Maximize();  
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void testNederBurti(){
            bool hasError = false;
            skolasPieteikums skolPiet = new skolasPieteikums(_driver);

            skolPiet.inputMajaslapa("hortusdigital");
            skolPiet.inputEpasts("kristaps.d@hortusdigital");
            skolPiet.clickSave();
            IList <IWebElement> errors = skolPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jaieraksta pareiza mājaslapa. Piem: hortusdigital.com"){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            skolasPieteikums skolPiet = new skolasPieteikums(_driver);

            skolPiet.inputMajaslapa("hortusdigital.com");
            skolPiet.inputEpasts("kristaps.d@hortusdigital.com");
            skolPiet.clickSave();
            IList <IWebElement> errors = skolPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jaieraksta pareiza mājaslapa. Piem: hortusdigital.com"){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void testnedersimboli(){
            bool hasError = false;
            skolasPieteikums skolPiet = new skolasPieteikums(_driver);

            skolPiet.inputMajaslapa("%^*@#$()+-:;{}[]~`|\\<>.lv");
            skolPiet.inputEpasts("kristaps.d@%^*@#$()+-:;{}[]~`|\\<>.lv");
            skolPiet.clickSave();
            IList <IWebElement> errors = skolPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jaieraksta pareiza mājaslapa. Piem: hortusdigital.com"){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void testnederArabic(){
            bool hasError = false;
            skolasPieteikums skolPiet = new skolasPieteikums(_driver);

            skolPiet.inputMajaslapa("だが男だ.lv");
            skolPiet.inputEpasts("kristaps.d@だが男だ.lv");
            skolPiet.clickSave();
            IList <IWebElement> errors = skolPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jaieraksta pareiza mājaslapa. Piem: hortusdigital.com"){
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