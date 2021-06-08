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


namespace prakDiendarbDienPlans.Tests
{
    [TestFixture]
    public class prakDiendarbDienPlansTests{


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

            bool isReadonly = praktKont.getDP().GetAttribute("readOnly").Equals("true");
            
            Xunit.Assert.True(isReadonly);
        }
        
        [Test]
        public void TestDer(){
            PraktIkdDarbs praktKont = new PraktIkdDarbs(_driver);
            praktKont.clickDPBtn();
            System.Threading.Thread.Sleep(2000);
            praktKont.clickDPchoose();

            string text = praktKont.getDP().GetAttribute("value");

            Xunit.Assert.False(String.IsNullOrEmpty(text));
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}