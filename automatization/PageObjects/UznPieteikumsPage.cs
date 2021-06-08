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

namespace eprakse.unregistered.uznemumaPieteikumsdomain{
    class uznemumaPieteikums{

        IWebDriver webDriver; 
        public uznemumaPieteikums(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement RegNr => webDriver.FindElement(By.CssSelector("#cr36b_name"));
        private IWebElement Nosauk => webDriver.FindElement(By.CssSelector("#cr36b_nosakums"));
        private IWebElement Majaslapa => webDriver.FindElement(By.CssSelector("#cr36b_domeins"));
        private IWebElement Nozare => webDriver.FindElement(By.CssSelector("#cr36b_nozare"));
        private IWebElement Region => webDriver.FindElement(By.CssSelector("#cr36b_regions"));
        private IWebElement Epasts => webDriver.FindElement(By.CssSelector("#cr36b_epasts"));
        private IWebElement Talrunis => webDriver.FindElement(By.CssSelector("#cr36b_talrunis"));
        private IWebElement Saglabat => webDriver.FindElement(By.CssSelector("#NextButton"));
        private IList <IWebElement> errors => webDriver.FindElements(By.CssSelector("#ValidationSummaryEntityFormView > ul > li"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/Pieteikties/uznemuma-pieteikums/");
        }

        public void inputRegNr(string text){
            RegNr.SendKeys(text);
        }

        public void inputNos(string text){
            Nosauk.SendKeys(text);
        }

        public void inputMajaslapa(string text){
            Majaslapa.SendKeys(text);
        }

        public void inputNozare(string text){
            Nozare.SendKeys(text);
        }

        public void inputRegions(string text){
            Region.SendKeys(text);
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