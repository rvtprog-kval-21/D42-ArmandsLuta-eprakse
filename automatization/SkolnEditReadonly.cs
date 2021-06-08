using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.Skoln;
using eprakse.unregistered.Login;


namespace SkolnEdit.Tests{
    [TestFixture]
    public class SkolnEditReadOnlyTests{
        private bool hasError = false;

        IWebDriver _driver;

        [SetUp]
        public void SetUp() {
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--window-size=1920,1080");
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
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
        public void vards(){
            Skolnieki SkolnPage = new Skolnieki(_driver);

            new WebDriverWait(_driver, new TimeSpan(0,0,30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".navbar .navbar-inverse")));
            IWebElement firstRow = SkolnPage.gettablefirstRow();
            firstRow.FindElement(By.CssSelector("td:nth-child(8) > div > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getEditFrame());
            bool isReadonly = SkolnPage.getVards().GetAttribute("readOnly").Equals("true");

            Xunit.Assert.True(isReadonly);
        }
        [Test]
        public void uzvards(){
            Skolnieki SkolnPage = new Skolnieki(_driver);

            new WebDriverWait(_driver, new TimeSpan(0,0,30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".navbar .navbar-inverse")));
            IWebElement firstRow = SkolnPage.gettablefirstRow();
            firstRow.FindElement(By.CssSelector("td:nth-child(8) > div > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getEditFrame());
            bool isReadonly = SkolnPage.getUzvards().GetAttribute("readOnly").Equals("true");

            Xunit.Assert.True(isReadonly);
        }
        [Test]
        public void regkods(){
            Skolnieki SkolnPage = new Skolnieki(_driver);

            new WebDriverWait(_driver, new TimeSpan(0,0,30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".navbar .navbar-inverse")));
            IWebElement firstRow = SkolnPage.gettablefirstRow();
            firstRow.FindElement(By.CssSelector("td:nth-child(8) > div > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getEditFrame());
            bool isReadonly = SkolnPage.getRegKods().GetAttribute("readOnly").Equals("true");

            Xunit.Assert.True(isReadonly);
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}