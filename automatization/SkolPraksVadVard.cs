using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.PraksVad;
using eprakse.unregistered.Login;


namespace SkolPraksVad.Tests{
    [TestFixture]
    public class SkolPraksVadNew{


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
            PraksesVad praksVad = new PraksesVad(_driver);
            praksVad.goToPage();
            System.Threading.Thread.Sleep(1000);

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            PraksesVad praksVad = new PraksesVad(_driver);

            praksVad.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(praksVad.getNewIframe());
            praksVad.getVards().SendKeys("Kristaps");
            praksVad.getNewSave().Click();
            IList <IWebElement> errors = praksVad.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vārdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
                [Test]
        public void TestCipari(){
            bool hasError = false;
            PraksesVad praksVad = new PraksesVad(_driver);

            praksVad.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(praksVad.getNewIframe());
            praksVad.getVards().SendKeys("54354");
            praksVad.getNewSave().Click();
            IList <IWebElement> errors = praksVad.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vārdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
                [Test]
        public void TestSimboli(){
            bool hasError = false;
            PraksesVad praksVad = new PraksesVad(_driver);

            praksVad.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(praksVad.getNewIframe());
            praksVad.getVards().SendKeys("%^*@#$()+-:;{}[]~`|\\<>");
            praksVad.getNewSave().Click();
            IList <IWebElement> errors = praksVad.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vārdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
                [Test]
        public void TestKrievs(){
            bool hasError = false;
            PraksesVad praksVad = new PraksesVad(_driver);

            praksVad.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(praksVad.getNewIframe());
            praksVad.getVards().SendKeys("вфыв");
            praksVad.getNewSave().Click();
            IList <IWebElement> errors = praksVad.getErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vārdam jābūt uzrakstītam ar latīņu alfabētu."){
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