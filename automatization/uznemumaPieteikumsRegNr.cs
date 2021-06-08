using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.unregistered.uznemumaPieteikumsdomain;

namespace uznPietTestRegNr.Tests{
    [TestFixture]
    public class uznemumaPieteikumsRegTesft{

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

            uznPiet.inputRegNr("вфывфыв");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Reģistrācijas Nr. nav derīgs."){
                    hasError = true;
                }
            }
            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputRegNr("40003053029");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Reģistrācijas Nr. nav derīgs."){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void testNederTikaiBurti(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputRegNr("dADADA");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Reģistrācijas Nr. nav derīgs."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void testNederSimboli(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputRegNr("%^*@#$()+/-:;{}[]~`|\\<>");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Reģistrācijas Nr. nav derīgs."){
                    hasError = true;
                }
            }


            Xunit.Assert.True(hasError);
        }
        [Test]
        public void testNederParakDaudzCip(){
            bool hasError = false;
            uznemumaPieteikums uznPiet = new uznemumaPieteikums(_driver);

            uznPiet.inputRegNr("565468468798795466532165498979");
            uznPiet.clickSave();
            IList <IWebElement> errors = uznPiet.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Reģistrācijas Nr. nav derīgs."){
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