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


namespace praksesNotProf.Tests
{
    [TestFixture]
    public class skolKontprofTests{


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
            praksesNotPage skolotKont = new praksesNotPage(_driver);
            skolotKont.goToPage();

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void ismanualedit(){
            praksesNotPage prakNot = new praksesNotPage(_driver);

            bool isReadonly = prakNot.getProf().GetAttribute("readOnly").Equals("true");
            
            Xunit.Assert.True(isReadonly);
        }
        
        [Test]
        public void TestDer(){
            praksesNotPage prakNot = new praksesNotPage(_driver);
            
            prakNot.clickProfButton();
            System.Threading.Thread.Sleep(2000);
            prakNot.clickChoose();

            string text = prakNot.getProf().GetAttribute("value");

            Xunit.Assert.False(String.IsNullOrEmpty(text));
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}