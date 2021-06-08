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

namespace eprakse.registered.skola.SkolKontPiest{
    class SkolKontPiest{
        IWebDriver webDriver;
        public SkolKontPiest(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement Vards => webDriver.FindElement(By.CssSelector("#cr36b_vards"));
        private IWebElement Uzvards => webDriver.FindElement(By.CssSelector("#cr36b_uzvards"));
        private IWebElement Talrunis => webDriver.FindElement(By.CssSelector("#cr36b_talrunis"));
        private IWebElement skolasText => webDriver.FindElement(By.CssSelector("#cr36b_skolas_name"));
        private IWebElement ChooseBttn => webDriver.FindElement(By.XPath("//*[@id='cr36b_skolas_lookupmodal']/div/section/div/div/div[3]/button[1]"));
        private IWebElement SkolasButton => webDriver.FindElement(By.XPath("//*[@id='EntityFormControl_6adc5ffe210aeb11a813000d3ab8cd41_EntityFormView']/div[2]/div/div/fieldset/table/tbody/tr[5]/td[1]/div[2]/div[1]/div[2]/button[2]"));
        private IWebElement Saglabat => webDriver.FindElement(By.CssSelector("#InsertButton"));
        private IWebElement lookupModalEntityGrid => webDriver.FindElement(By.CssSelector("#cr36b_skolas_lookupmodal > div > section > div > div > div.modal-body > div.entity-grid"));
        private IList <IWebElement> errors => webDriver.FindElements(By.CssSelector("#ValidationSummaryEntityFormControl_6adc5ffe210aeb11a813000d3ab8cd41_EntityFormView > ul > li"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/skolas-administracijas-panelis/piesaistit-prakses-vaditaju/");
        }

        public void inputVards(string text){
            Vards.SendKeys(text);
        }

        public void inputUzvards(string text){
            Uzvards.SendKeys(text);
        }

        public void inputTalrunis(string text){
            Talrunis.SendKeys(text);
        }

        public void clickSkolaSearch(){
            SkolasButton.Click();
        }

        public void clickFirstSelected(){
            IList <IWebElement> tableRows = lookupModalEntityGrid.FindElements(By.CssSelector("table > tbody > tr"));
            tableRows.First().Click();
        }

        public void clickSave(){
            Saglabat.Click();
        }

        public void clickChoose(){
            ChooseBttn.Click();
        }

        public IWebElement getSkolasText(){
            return skolasText;
        }

        public IWebElement getLookupModal(){
            return lookupModalEntityGrid;
        }

        public IList <IWebElement> getErrors(){
            return errors;
        }
    }
}