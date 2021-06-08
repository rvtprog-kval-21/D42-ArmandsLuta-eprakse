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
    public class SkolPrakseditNameSurnameNew{


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
        public void vards(){
            PraksesVad praksVad = new PraksesVad(_driver);

            IWebElement firstRow = praksVad.gettablefirstRow();
            firstRow.FindElement(By.CssSelector(".dropdown > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(praksVad.getEditFrame());
            bool isReadonly = praksVad.getVards().GetAttribute("readOnly").Equals("true");

            Xunit.Assert.True(isReadonly);
        }
        [Test]
        public void uzvards(){
            PraksesVad praksVad = new PraksesVad(_driver);

            IWebElement firstRow = praksVad.gettablefirstRow();
            firstRow.FindElement(By.CssSelector(".dropdown > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(praksVad.getEditFrame());
            bool isReadonly = praksVad.getUzvards().GetAttribute("readOnly").Equals("true");

            Xunit.Assert.True(isReadonly);
        }
        [Test]
        public void regkods(){
            PraksesVad praksVad = new PraksesVad(_driver);

            IWebElement firstRow = praksVad.gettablefirstRow();
            firstRow.FindElement(By.CssSelector(".dropdown > button")).Click();
            firstRow.FindElement(By.CssSelector("a[title='Rediģēt']")).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(praksVad.getEditFrame());
            bool isReadonly = praksVad.getUzvards().GetAttribute("readOnly").Equals("true");

            Xunit.Assert.True(isReadonly);
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}