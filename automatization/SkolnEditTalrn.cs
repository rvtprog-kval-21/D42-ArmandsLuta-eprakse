using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using SeleniumExtras.WaitHelpers;
//page object
using eprakse.registered.skola.Skoln;
using eprakse.unregistered.Login;


namespace Skoln.Tests{
    [TestFixture]
    public class SkolPraksTalrEdit{

        IWebDriver _driver;

        [SetUp]
        public void SetUp() {
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--window-size=1920,1080");
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
            //_driver = new ChromeDriver("D:\\eprakse azure\\d41-KristapsDruva-eprakse\\automatization\\WebDriver\\bin", chromeOptions);  
            Loginpage login = new Loginpage(_driver);
            login.goToPage();
            login.inputUsername("RVTAdmin");
            login.inputPassword("KriDru6709!");
            login.clickLogin();
            Skolnieki SkolnPage = new Skolnieki(_driver);
            SkolnPage.goToPage();
            System.Threading.Thread.Sleep(3000);

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }
        [Test]
        public void TestDer(){
            bool hasError = false;

            Skolnieki SkolnPage = new Skolnieki(_driver);

            new WebDriverWait(_driver, new TimeSpan(0,0,30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".navbar .navbar-inverse")));
            IWebElement firstRow = SkolnPage.gettablefirstRow();
            firstRow.FindElement(By.CssSelector(".dropdown > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getEditFrame());
            SkolnPage.getTalr().Clear();
            SkolnPage.getTalr().SendKeys("12345678");
            SkolnPage.getEditSagl().Click();
            System.Threading.Thread.Sleep(500);
            IList <IWebElement> errors = SkolnPage.getNewErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jābūt pareizi ierakstītam tālrunim. Piem: 14332152"){
                    hasError = true;
                }
            }

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void TestCipari(){
            bool hasError = false;
            Skolnieki SkolnPage = new Skolnieki(_driver);


            new WebDriverWait(_driver, new TimeSpan(0,0,30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".navbar .navbar-inverse")));
            IWebElement firstRow = SkolnPage.gettablefirstRow();
            firstRow.FindElement(By.CssSelector("td:nth-child(8) > div > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getEditFrame());
            SkolnPage.getTalr().Clear();
            SkolnPage.getTalr().SendKeys("531231231231234354");
            SkolnPage.getEditSagl().Click();
            IList <IWebElement> errors = SkolnPage.getNewErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jābūt pareizi ierakstītam tālrunim. Piem: 14332152"){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestSimboli(){
            bool hasError = false;
            Skolnieki SkolnPage = new Skolnieki(_driver);

            new WebDriverWait(_driver, new TimeSpan(0,0,30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".navbar .navbar-inverse")));
            IWebElement firstRow = SkolnPage.gettablefirstRow();
            firstRow.FindElement(By.CssSelector("td:nth-child(8) > div > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getEditFrame());
            SkolnPage.getTalr().Clear();
            SkolnPage.getTalr().SendKeys("%^*@#$()+-:;{}[]~`|\\<>");
            SkolnPage.getEditSagl().Click();
            IList <IWebElement> errors = SkolnPage.getNewErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jābūt pareizi ierakstītam tālrunim. Piem: 14332152"){
                    hasError = true;
                }
            }

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void TestKrievs(){
            bool hasError = false;
            Skolnieki SkolnPage = new Skolnieki(_driver);

            new WebDriverWait(_driver, new TimeSpan(0,0,30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".navbar .navbar-inverse")));
            IWebElement firstRow = SkolnPage.gettablefirstRow();
            firstRow.FindElement(By.CssSelector("td:nth-child(8) > div > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getEditFrame());
            SkolnPage.getTalr().Clear();
            SkolnPage.getTalr().SendKeys("dasdaga");
            SkolnPage.getEditSagl().Click();
            IList <IWebElement> errors = SkolnPage.getNewErrors();
            foreach(IWebElement e in errors) {
                if(e.Text == "Jābūt pareizi ierakstītam tālrunim. Piem: 14332152"){
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