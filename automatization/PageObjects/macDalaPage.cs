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

namespace eprakse.registered.skola.macDala{
    class macDalapage{

        IWebDriver webDriver;
        public macDalapage(IWebDriver driver){
            this.webDriver = driver;
        }
        //newliet create
        private IWebElement NewLietBttn => webDriver.FindElement(By.XPath("/html/body/form/div[3]/div[2]/div/div/div[2]/div/div[1]/button"));
        private IWebElement Vards => webDriver.FindElement(By.CssSelector("#firstname"));
        private IWebElement Uzvards => webDriver.FindElement(By.CssSelector("#lastname"));
        private IWebElement MobTalr => webDriver.FindElement(By.CssSelector("#mobilephone"));
        private IWebElement Epasts => webDriver.FindElement(By.CssSelector("#emailaddress1"));
        private IWebElement SaveButton => webDriver.FindElement(By.CssSelector("#InsertButton"));
        //edit liet
        private IWebElement DropdownBtn => webDriver.FindElement(By.XPath("//*[@id='dataTable']/table/tbody/tr[1]/td[5]/div/button"));
        private IWebElement dropdownRedigetLiet => webDriver.FindElement(By.XPath("//*[@id='dataTable']/table/tbody/tr[1]/td[5]/div/ul/li[1]/a"));
        private IWebElement dropdownDeaktLiet => webDriver.FindElement(By.XPath("//*[@id='dataTable']/table/tbody/tr[1]/td[5]/div/ul/li[2]/a"));
        private IList <IWebElement> errors => webDriver.FindElements(By.CssSelector("#ValidationSummaryEntityFormControl_0b58a68f412eeb11a813000d3ab7cb08_EntityFormView > ul > li"));
        private IWebElement RedVard => webDriver.FindElement(By.CssSelector("#Vards"));
        private IWebElement RedUzvard => webDriver.FindElement(By.CssSelector("#Uzvards"));
        private IWebElement RedTalr => webDriver.FindElement(By.CssSelector("#Tālrunis"));
        private IWebElement RedEpas => webDriver.FindElement(By.CssSelector("#E-pasts"));
        private IWebElement saveEditBtn => webDriver.FindElement(By.CssSelector("#saveEdit"));
        //get table rows
        private IList <IWebElement> tableRows => webDriver.FindElements(By.CssSelector("#dataTable > table > tbody > tr"));
        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/macibu-dala/");
        }
        //new liet
        public void inputVards(string text){
            Vards.SendKeys(text);
        }

        public void inputUzvards(string text){
            Uzvards.SendKeys(text);
        }

        public void inputTalrunis(string text){
            MobTalr.SendKeys(text);
        }

        public void inputEpasts(string text){
            Epasts.SendKeys(text);
        }

        public void clickSaveNew(){
            SaveButton.Click();
        }

        public void clickNewLiet(){
            NewLietBttn.Click();
        }
        //edit Liet
        public IWebElement geteditVards(){
            return RedVard;
        }

        public IWebElement geteditUzvards(){
            return RedUzvard;
        }
        
        public IWebElement geteditTalr(){
            return RedTalr;
        }
        
        public IWebElement geteditEpasts(){
            return RedEpas;
        }

        public IWebElement getFirstTableRow(){
            return tableRows[0];
        }
        
        public void editSave(){
            saveEditBtn.Click();
        }

        public IList <IWebElement> getErrors(){
            return errors;
        }

    }
}