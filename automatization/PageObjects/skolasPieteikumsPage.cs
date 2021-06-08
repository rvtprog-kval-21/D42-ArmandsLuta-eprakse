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

namespace eprakse.unregistered.skolasPieteikums{
    class skolasPieteikums{

        IWebDriver webDriver; 
        public skolasPieteikums(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement Nosaukums => webDriver.FindElement(By.CssSelector("#cr36b_nosaukums"));
        private IWebElement Majaslapa => webDriver.FindElement(By.CssSelector("#cr36b_domeins"));
        private IWebElement Epasts => webDriver.FindElement(By.CssSelector("#cr36b_epasts"));
        private IWebElement Talrunis => webDriver.FindElement(By.CssSelector("#cr36b_kontakttalrunis"));
        private IWebElement Saglabat => webDriver.FindElement(By.CssSelector("#NextButton"));
        private IList <IWebElement> errors => webDriver.FindElements(By.CssSelector("#ValidationSummaryEntityFormView > ul > li"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/Pieteikties/skolas-pieteikums/");
        }

        public void inputNosaukums(string text){
            Nosaukums.SendKeys(text);
        }

        public void inputMajaslapa(string text){
            Majaslapa.SendKeys(text);
        }

        public void inputEpasts(string text){
            Epasts.SendKeys(text);
        }

        public void inputTalrunis(string text){
            Talrunis.SendKeys(text);
        }

        public void clickSave(){
            Saglabat.Click();
        }

        public IList <IWebElement> getErrors(){
            return errors;
        }
    }
}