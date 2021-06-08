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
    public class SkolnCreateNewGrupa{

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
        public void ismanualedit(){
            Skolnieki SkolnPage = new Skolnieki(_driver);

            SkolnPage.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Frame(SkolnPage.getNewIframe());
            bool isReadonly = SkolnPage.getGrupa().GetAttribute("readOnly").Equals("true");
            
            Xunit.Assert.True(isReadonly);
        }
        
        [Test]
        public void TestDer(){
            Skolnieki SkolnPage = new Skolnieki(_driver);

            SkolnPage.getCreateNewBtn().Click();
            System.Threading.Thread.Sleep(1000);
            _driver.SwitchTo().Frame(SkolnPage.getNewIframe());
            SkolnPage.getChoosebtn().Click();
            System.Threading.Thread.Sleep(2000);
            SkolnPage.getGrupaChoicebtn().Click();

            string text = SkolnPage.getGrupa().GetAttribute("value");

            Xunit.Assert.False(String.IsNullOrEmpty(text));
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}