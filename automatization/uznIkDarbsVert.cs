using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.uznIkDarbs;
using eprakse.unregistered.Login;

namespace uznikDarb.Tests{
    [TestFixture]
    public class uznikDarbVertTest{

        IWebDriver _driver;

        [SetUp]
        public void SetUp() {
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("--window-size=1920,1080");
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
            //_driver = new ChromeDriver("D:\\eprakse azure\\d41-KristapsDruva-eprakse\\automatization\\WebDriver\\bin", chromeOptions);  
            Loginpage login = new Loginpage(_driver);
            login.goToPage();
            login.inputUsername("MargaTiltina");
            login.inputPassword("KriDru6709!");
            login.clickLogin();
            uznIkDarbs uznIkDarb = new uznIkDarbs(_driver);
            try {
            uznIkDarb.goToPage();
            } catch (UnhandledAlertException) {
                try {
                _driver.SwitchTo().Alert().Accept();
                } catch (NoAlertPresentException){

                }
            }

            System.Threading.Thread.Sleep(3000);

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void testDer(){
            bool hasError = false;
            uznIkDarbs uznIkDarb = new uznIkDarbs(_driver);

            IWebElement firstrow = uznIkDarb.getdataTableFirstRow();
            firstrow.FindElement(By.Name("vertejums")).Clear();
            firstrow.FindElement(By.Name("vertejums")).SendKeys("2");
            uznIkDarb.getSaveBtn().Click();
            hasError = uznIkDarb.isAlertPresent();

            Xunit.Assert.False(hasError);
        }
        [Test]
        public void testnederMinus(){
            bool hasError = false;
            uznIkDarbs uznIkDarb = new uznIkDarbs(_driver);

            IWebElement firstrow = uznIkDarb.getdataTableFirstRow();
            firstrow.FindElement(By.Name("vertejums")).Clear();
            firstrow.FindElement(By.Name("vertejums")).SendKeys("-32");;
            uznIkDarb.getSaveBtn().Click();
            hasError = uznIkDarb.isAlertPresent();

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void testNederTooBig(){
            bool hasError = false;
            uznIkDarbs uznIkDarb = new uznIkDarbs(_driver);

            IWebElement firstrow = uznIkDarb.getdataTableFirstRow();
            firstrow.FindElement(By.Name("vertejums")).Clear();
            firstrow.FindElement(By.Name("vertejums")).SendKeys("32");;
            uznIkDarb.getSaveBtn().Click();
            hasError = uznIkDarb.isAlertPresent();

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void testnederSimb(){
            bool hasError = false;
            uznIkDarbs uznIkDarb = new uznIkDarbs(_driver);

            IWebElement firstrow = uznIkDarb.getdataTableFirstRow();
            firstrow.FindElement(By.Name("vertejums")).Clear();
            firstrow.FindElement(By.Name("vertejums")).SendKeys("%^*@#$()+-:;{}[]~`|\\<>");;
            uznIkDarb.getSaveBtn().Click();
            hasError = uznIkDarb.isAlertPresent();

            Xunit.Assert.True(hasError);
        }
        [Test]
        public void testnederBurti(){
            bool hasError = false;
            uznIkDarbs uznIkDarb = new uznIkDarbs(_driver);

            IWebElement firstrow = uznIkDarb.getdataTableFirstRow();
            firstrow.FindElement(By.Name("vertejums")).Clear();
            firstrow.FindElement(By.Name("vertejums")).SendKeys("gadgg");;
            uznIkDarb.getSaveBtn().Click();
            hasError = uznIkDarb.isAlertPresent();

            Xunit.Assert.True(hasError);
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}