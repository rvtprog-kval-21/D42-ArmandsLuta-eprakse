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


namespace prakDiendarbPraks.Tests
{
    [TestFixture]
    public class prakDiendarPraksTests{


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
                } catch (NoAlertPresentException){

                }
            }

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void ismanualedit(){
            PraktIkdDarbs praktKont = new PraktIkdDarbs(_driver);
            bool isReadonly = praktKont.getPrak().GetAttribute("readOnly").Equals("true");
            
            Xunit.Assert.True(isReadonly);
        }
        
        [Test]
        public void TestDer(){
            PraktIkdDarbs praktKont = new PraktIkdDarbs(_driver);
            praktKont.clickPrakBtn();
            System.Threading.Thread.Sleep(1000);
            praktKont.clickPrakChoose();

            string text = praktKont.getPrak().GetAttribute("value");

            Xunit.Assert.False(String.IsNullOrEmpty(text));
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}