using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace eprakse.unregistered.Login{
    class Loginpage{

        IWebDriver webDriver; 
        public Loginpage(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement username => webDriver.FindElement(By.CssSelector("#Username"));
        private IWebElement password => webDriver.FindElement(By.CssSelector("#Password"));
        private IWebElement loginbttn => webDriver.FindElement(By.CssSelector("#submit-signin-local"));
        private IList <IWebElement> errors => webDriver.FindElements(By.CssSelector("#loginValidationSummary > ul > li"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/SignIn?returnUrl=%2Flv-LV%2FPieteikties%2Fskolas-pieteikums%2F");
        }

        public void inputUsername(string text){
            username.SendKeys(text);
        }

        public void inputPassword(string text){
            password.SendKeys(text);
        }

        public void clickLogin(){
            loginbttn.Click();
        }

        public IList <IWebElement> getErrors(){
            return errors;
        }
    }
}