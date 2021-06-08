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

namespace eprakse.registered.skola.PraksesNotikums{
    class praksesNotPage{

        IWebDriver webDriver;
        public praksesNotPage(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement Nosaukums => webDriver.FindElement(By.CssSelector("#cr36b_nosaukums"));
        private IWebElement SakumaDatums => webDriver.FindElement(By.CssSelector("#cr36b_sakumadatums_datepicker_description"));
        private IWebElement BeiguDatums => webDriver.FindElement(By.CssSelector("#cr36b_beigudatums_datepicker_description"));
        private IWebElement Stundas => webDriver.FindElement(By.CssSelector("#cr36b_stundas"));
        private IWebElement ProfesijasButton => webDriver.FindElement(By.XPath("//*[@id='EntityFormControl_e379b0fc16f4ea11a815000d3ab8cd41_EntityFormView']/div[2]/div/div/fieldset/table/tbody/tr[7]/td[1]/div[2]/div[1]/div[2]/button[2]"));
        private IWebElement SaveButton => webDriver.FindElement(By.CssSelector("#InsertButton"));
        private IWebElement chooseBttn => webDriver.FindElement(By.XPath("//*[@id='cr36b_profesijas_lookupmodal']/div/section/div/div/div[3]/button[1]"));
        private IWebElement profText => webDriver.FindElement(By.XPath("//*[@id='cr36b_profesijas_name']"));
        private IList <IWebElement> errors => webDriver.FindElements(By.CssSelector("#ValidationSummaryEntityFormControl_e379b0fc16f4ea11a815000d3ab8cd41_EntityFormView > ul > li"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/prakses-notikumi/prakses-notikuma-izveide/");
        }

        public void inputNosaukums(string text){
            Nosaukums.SendKeys(text);
        }

        public void inputSakumDat(string text){
            SakumaDatums.SendKeys(text);
        }

        public void inputBeigDat(string text){
            BeiguDatums.SendKeys(text);
        }

        public void inputStundas(string text){
            Stundas.SendKeys(text);
        }

        public void clickProfButton(){
            ProfesijasButton.Click();
        }

        public void clickChoose(){
            chooseBttn.Click();
        }
        
        public void clickSave(){
            SaveButton.Click();
        }
        public IList <IWebElement> getErrors(){
            return errors;
        }

        public IWebElement getProf(){
            return profText;
        }
    }
}