using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.SkolKontPiest;
using eprakse.unregistered.Login;


namespace skolKontSkolas.Tests
{
    [TestFixture]
    public class skolKontSkolasTests{


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
            SkolKontPiest skolotKont = new SkolKontPiest(_driver);
            skolotKont.goToPage();

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void ismanualedit(){

            SkolKontPiest skolotKont = new SkolKontPiest(_driver);

            bool isReadonly = skolotKont.getSkolasText().GetAttribute("readOnly").Equals("true");
            
            Xunit.Assert.True(isReadonly);
        }
        
        [Test]
        public void TestDer(){

            SkolKontPiest skolotKont = new SkolKontPiest(_driver);
            
            skolotKont.clickSkolaSearch();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => skolotKont.getLookupModal());
            System.Threading.Thread.Sleep(1000);
            skolotKont.clickChoose();

            string text = skolotKont.getSkolasText().GetAttribute("value");

            Xunit.Assert.False(String.IsNullOrEmpty(text));
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}