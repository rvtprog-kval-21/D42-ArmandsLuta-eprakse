using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace eprakse.registered.skola.uznIkDarbs{
    class uznIkDarbs{

        IWebDriver webDriver;
        public uznIkDarbs(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement datatable => webDriver.FindElement(By.CssSelector("#dataTable"));
        private IList <IWebElement> datatableFirstRow => webDriver.FindElements(By.CssSelector("#dataTable > table > tbody > tr"));
        private IWebElement searchDate => webDriver.FindElement(By.CssSelector("#DienasFiltrs"));
        private IWebElement SearchBttn => webDriver.FindElement(By.CssSelector("#DienIeraSearch"));
        private IWebElement SaveButton => webDriver.FindElement(By.CssSelector("#VertKomSave"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/profils");
        }

        public IWebElement getdataTable(){
            return datatable;
        }

        public IWebElement getdataTableFirstRow(){
            return datatableFirstRow[0];
        }

        public IWebElement getSearchDate(){
            return searchDate;
        }
        
        public IWebElement getSearchBtn(){
            return SearchBttn;
        }

        public IWebElement getSaveBtn(){
            return SaveButton;
        }

        public bool isAlertPresent() { 
            try { 
                webDriver.SwitchTo().Alert(); 
                return true; 
            }
            catch (NoAlertPresentException) { 
                return false; 
            }
        } 
    }
}