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

namespace eprakse.registered.skola.AdminPanel{
    class AdminPanelPage{

        IWebDriver webDriver;
        public AdminPanelPage(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement linkSkolDati => webDriver.FindElement(By.CssSelector("#Username"));
        private IWebElement linkPrakProg => webDriver.FindElement(By.CssSelector("#Password"));
        private IWebElement Saglabat => webDriver.FindElement(By.CssSelector("#InsertButton"));
        private IList <IWebElement> errors => webDriver.FindElements(By.CssSelector("#loginValidationSummary > ul > li"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/SignIn?returnUrl=%2Flv-LV%2FPieteikties%2Fskolas-pieteikums%2F");
        }


        public IList <IWebElement> getErrors(){
            return errors;
        }
    }
}