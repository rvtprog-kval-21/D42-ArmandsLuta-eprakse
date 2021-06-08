using NUnit.Framework;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
//page object
using eprakse.registered.skola.macDala;
using eprakse.unregistered.Login;


namespace macDalaeditVardsUzv.Tests
{
    [TestFixture]
    public class macDalaVardsUzvTests{

        IWebDriver _driver;

        [SetUp]
        public void SetUp(){
            ChromeOptions chromeOptions = new ChromeOptions();  
            chromeOptions.AddArgument("disable-infobars");  
            _driver = new ChromeDriver("D:\\a\\1\\s\\automatization\\WebDriver\\bin", chromeOptions);  
            Loginpage login = new Loginpage(_driver);
            login.goToPage();
            login.inputUsername("RVTAdmin");
            login.inputPassword("KriDru6709!");
            login.clickLogin();
            macDalapage macDalaNewLiet = new macDalapage(_driver);
            macDalaNewLiet.goToPage();

            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void testReadonlyVards(){
            macDalapage editLiet = new macDalapage(_driver);

            IWebElement firstRow = editLiet.getFirstTableRow();
            firstRow.FindElement(By.XPath("//*[@id='dataTable']/table/tbody/tr[1]/td[5]/div/button")).Click();
            firstRow.FindElement(By.XPath("//*[@id='dataTable']/table/tbody/tr[1]/td[5]/div/ul/li[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
            bool isReadonly = editLiet.geteditVards().GetAttribute("readOnly").Equals("true");

            Xunit.Assert.True(isReadonly);
        }
        [Test]
        public void TestReadonlyUzv(){
            macDalapage editLiet = new macDalapage(_driver);

            IWebElement firstRow = editLiet.getFirstTableRow();
            firstRow.FindElement(By.XPath("//*[@id='dataTable']/table/tbody/tr[1]/td[5]/div/button")).Click();
            firstRow.FindElement(By.XPath("//*[@id='dataTable']/table/tbody/tr[1]/td[5]/div/ul/li[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
            bool isReadonly = editLiet.geteditUzvards().GetAttribute("readOnly").Equals("true");

            Xunit.Assert.True(isReadonly);
        }

        [TearDown]
        public void TearDown(){
            _driver.Quit();
        }
    }
}