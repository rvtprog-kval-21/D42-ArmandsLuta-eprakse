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

namespace eprakse.registered.skola.PraksVad{
    class PraksesVad{

        IWebDriver webDriver;
        public PraksesVad(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement CreateNewBtn => webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[1]/div/div[2]/a"));
        private IWebElement Table => webDriver.FindElement(By.CssSelector("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[2]/table"));
        private IList <IWebElement> TableFirstRow => webDriver.FindElements(By.CssSelector("body > div.wrapper-body > div.page-copy > div > div > div > div > div > div > div > div.view-grid > table > tbody > tr"));
        //create new
        private IWebElement NewIframe => webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[8]/div/div/div[2]/iframe"));
        private IWebElement Vards => webDriver.FindElement(By.Id("cr36b_vards"));
        private IWebElement Uzvards => webDriver.FindElement(By.Id("cr36b_uzvards"));
        private IWebElement Talrn => webDriver.FindElement(By.Id("cr36b_talrunis"));
        private IWebElement Epasts => webDriver.FindElement(By.Id("cr36b_epasts"));
        private IWebElement NewSaglabat => webDriver.FindElement(By.XPath("/html/body/div[2]/div/form/div[3]/div/div[2]/input[1]"));
        private IList <IWebElement> Errors => webDriver.FindElements(By.CssSelector("#ValidationSummaryEntityFormControl_EntityFormView > ul > li"));
        //edit
        private IWebElement EditIframe => webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[9]/div/div/div[2]/iframe"));
        private IWebElement EditSaglabat => webDriver.FindElement(By.CssSelector("#UpdateButton"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/skolas-administracijas-panelis/skolas-dati/");
        }

        public IList <IWebElement> getErrors(){
            return Errors;
        }

        public IWebElement getVards(){
            return Vards;
        }

        public IWebElement getUzvards(){
            return Uzvards;
        }

        public IWebElement getTalr(){
            return Talrn;
        }

        public IWebElement getEpasts(){
            return Epasts;
        }

        public IWebElement getNewSave(){
            return NewSaglabat;
        }

        public IWebElement getEditSagl(){
            return EditSaglabat;
        }

        public IWebElement getCreateNewBtn(){
            return CreateNewBtn;
        }

        public IWebElement getTable(){
            return Table;
        }

        public IWebElement gettablefirstRow(){
            return TableFirstRow[0];
        }

        public IWebElement getNewIframe(){
            return NewIframe;
        }
        public IWebElement getEditFrame(){
            return EditIframe;
        }
    }
}