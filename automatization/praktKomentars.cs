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


namespace praktIkdKoment.Tests{
    [TestFixture]
    public class praktIkdKomentTests{


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

        /*[Test]
        public void testNederBurti(){
            PraktIkdDarbs dienIer = new PraktIkdDarbs(_driver);

            dienIer.inputKomentars("%^*@#$()+-:;{}[]~`|\\<>");
            dienIer.clickSave();
            IList <IWebElement> errors = dienIer.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Komentāram jābūt ierakstītam ar atļautiem simboliem."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }*/
        [Test]
        public void TestDer(){
            bool hasError = false;
            PraktIkdDarbs dienIer = new PraktIkdDarbs(_driver);

            dienIer.inputKomentars("gkjahskdh lajghlashdjh  asāšāšēdc");
            dienIer.clickSave();
            IList <IWebElement> errors = dienIer.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Komentāram jābūt ierakstītam ar atļautiem simboliem."){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }/*
        [Test]
        public void testnedersimboli(){
            PraktIkdDarbs dienIer = new PraktIkdDarbs(_driver);

            dienIer.inputKomentars("вафып");
            dienIer.clickSave();
            IList <IWebElement> errors = dienIer.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Komentāram jābūt ierakstītam ar atļautiem simboliem."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }*/

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}