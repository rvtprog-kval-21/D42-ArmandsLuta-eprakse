using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.PraksesNotikums;
using eprakse.unregistered.Login;


namespace praksesNotSakDat.Tests
{
    [TestFixture]
    public class praksesNotSakDat{


        IWebDriver _driver;

        [SetUp]
        public void SetUp() {
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");  
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
            Loginpage login = new Loginpage(_driver);
            login.goToPage();
            login.inputUsername("EdgarsLiepa");
            login.inputPassword("KriDru6709!");
            login.clickLogin();
            praksesNotPage PrakNot = new praksesNotPage(_driver);
            PrakNot.goToPage();

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void nederSimb(){
            bool hasError = false;
            praksesNotPage PrakNot = new praksesNotPage(_driver);

            PrakNot.inputSakumDat("12/12/2020");
            PrakNot.clickSave();
            IList <IWebElement> errors = PrakNot.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Sākuma datums ir obligāts lauks."){
                    hasError = true;
                }
            }
            
            Xunit.Assert.True(hasError);
        }
        
        [Test]
        public void nederAlf(){
            bool hasError = false;
            praksesNotPage PrakNot = new praksesNotPage(_driver);
            
            PrakNot.inputSakumDat("12-12-2020");
            PrakNot.clickSave();
            IList <IWebElement> errors = PrakNot.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Sākuma datums ir obligāts lauks."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }

        [Test]
        public void der(){
            bool hasError = false;
            praksesNotPage PrakNot = new praksesNotPage(_driver);
            
            PrakNot.inputSakumDat("12.12.2020");
            PrakNot.clickSave();
            IList <IWebElement> errors = PrakNot.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Sākuma datums ir obligāts lauks."){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}