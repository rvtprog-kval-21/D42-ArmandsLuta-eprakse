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

namespace eprakse.registered.skola.Skoln{
    class Skolnieki{

        IWebDriver webDriver;
        public Skolnieki(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement CreateNewBtn => webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[2]/div/div[1]/div/div[2]/a"));
        private IWebElement Table => webDriver.FindElement(By.CssSelector("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[2]/div/div[2]/table"));
        private IList <IWebElement> TableFirstRow => webDriver.FindElements(By.CssSelector("body > div.wrapper-body > div.page-copy > div > div > div > div > div > div > div > div.col-md-9 > div > div.view-grid.has-pagination > table > tbody > tr"));
        //create new
        private IWebElement NewIframe => webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[2]/div/div[8]/div/div/div[2]/iframe"));
        private IWebElement Vards => webDriver.FindElement(By.Id("cr36b_vards"));
        private IWebElement Uzvards => webDriver.FindElement(By.Id("cr36b_uzvards"));
        private IWebElement Talrn => webDriver.FindElement(By.Id("cr36b_talrunisreal"));
        private IWebElement Epasts => webDriver.FindElement(By.Id("cr36b_epasts"));
        private IWebElement RegKods => webDriver.FindElement(By.Id("cr36b_perskods"));
        private IWebElement NewSaglabat => webDriver.FindElement(By.XPath("/html/body/div[2]/div/form/div[3]/div/div[2]/input[1]"));
        private IWebElement GrupaBtn => webDriver.FindElement(By.XPath("/html/body/div[2]/div/form/div[3]/div/div[1]/div[2]/div/div/fieldset/table/tbody/tr[7]/td[1]/div[2]/div[1]/div[2]/button[2]"));
        private IWebElement GrupaChooseBttn => webDriver.FindElement(By.XPath("/html/body/div[2]/div/form/div[3]/div/div[1]/div[2]/div/div/fieldset/table/tbody/tr[7]/td[1]/div[2]/div[2]/div/section/div/div/div[3]/button[1]"));
        private IWebElement Grupa => webDriver.FindElement(By.Id("cr36b_grupas_name"));
        private IList <IWebElement> newErrors => webDriver.FindElements(By.CssSelector("#ValidationSummaryEntityFormControl_EntityFormView > ul > li"));
        //edit
        private IWebElement EditIframe => webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[2]/div/div[9]/div/div/div[2]/iframe"));
        private IWebElement EditSaglabat => webDriver.FindElement(By.CssSelector("#UpdateButton"));
        private IWebElement EditGroupBtn => webDriver.FindElement(By.XPath("/html/body/div[2]/div/form/div[3]/div/div[1]/div[2]/div/div/fieldset/table/tbody/tr[6]/td[1]/div[2]/div[1]/div/button[2]"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/skolas-dati-skolnieki/");
        }

        public IList <IWebElement> getNewErrors(){
            return newErrors;
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
        public IWebElement getRegKods(){
            return RegKods;
        }
        public IWebElement getChoosebtn(){
            return GrupaBtn;
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


        public IWebElement getEditGroupBtn(){
            return EditGroupBtn;
        }

        public IWebElement getGrupa(){
            return Grupa;
        }

        public IWebElement getGrupaChoicebtn(){
            return GrupaChooseBttn;
        }
    }
}