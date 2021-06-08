using NUnit.Framework;
using System;
using System.Diagnostics;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.Skoln;
using eprakse.unregistered.Login;


namespace SkolnCreate.Tests{
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
            Skolnieki SkolnPage = new Skolnieki(_driver);
            SkolnPage.goToPage();
            System.Threading.Thread.Sleep(1000);

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }
        [Test]
        public void TestDer(){
            bool hasError = false;
            Skolnieki SkolnPage = new Skolnieki(_driver);

            SkolnPage.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getNewIframe());
            SkolnPage.getVards().SendKeys("Kristaps");
            SkolnPage.getNewSave().Click();
            IList <IWebElement> errors = SkolnPage.getNewErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vārdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                    break;
                }
            }

            Xunit.Assert.False(hasError);
        }
        
        [Test]
        public void TestCipari(){
            bool hasError = false;
            Skolnieki SkolnPage = new Skolnieki(_driver);

            SkolnPage.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getNewIframe());
            SkolnPage.getVards().SendKeys("54354");
            SkolnPage.getNewSave().Click();
            System.Threading.Thread.Sleep(500);
            IList <IWebElement> errors = SkolnPage.getNewErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vārdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                    break;
                }
            }

            Xunit.Assert.True(hasError);
        }

        [Test]
        public void TestSimboli(){
            bool hasError = false;
            Skolnieki SkolnPage = new Skolnieki(_driver);

            SkolnPage.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getNewIframe());
            SkolnPage.getVards().SendKeys("%^*@#$()+-:;{}[]~`|\\<>");
            SkolnPage.getNewSave().Click();
            IList <IWebElement> errors = SkolnPage.getNewErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vārdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                    break;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestKrievs(){
            bool hasError = false;
            Skolnieki SkolnPage = new Skolnieki(_driver);

            SkolnPage.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getNewIframe());
            SkolnPage.getVards().SendKeys("вфыв");
            SkolnPage.getNewSave().Click();
            IList <IWebElement> errors = SkolnPage.getNewErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Vārdam jābūt uzrakstītam ar latīņu alfabētu."){
                    hasError = true;
                    break;
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