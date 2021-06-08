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

namespace eprakse.registered.skola.PraktIkdDarbs{
    class PraktIkdDarbs{

        IWebDriver webDriver;
        public PraktIkdDarbs(IWebDriver driver){
            this.webDriver = driver;
        }

        private IWebElement DarbuSaku => webDriver.FindElement(By.CssSelector("#cr36b_darbusakureal"));
        private IWebElement DarbuBeidzu => webDriver.FindElement(By.CssSelector("#cr36b_darbubeidzureal"));
        private IWebElement Komentars => webDriver.FindElement(By.CssSelector("#cr36b_praktikantakomentars"));
        private IWebElement SaveButton => webDriver.FindElement(By.CssSelector("#InsertButton"));
        //dienas plans
        private IWebElement dienasPlansBtn => webDriver.FindElement(By.XPath("/html/body/form/div[3]/div[2]/div/div/div/div/div/div[3]/div/div[1]/div[2]/div/div/fieldset[2]/table/tbody/tr/td[2]/div[2]/div[1]/div[2]/button[2]"));
        private IWebElement dienasChooseBtn => webDriver.FindElement(By.XPath("//*[@id='cr36b_skolniekastundas_lookupmodal']/div/section/div/div/div[3]/button[1]"));
        private IWebElement dienasText => webDriver.FindElement(By.XPath("//*[@id='cr36b_skolniekastundas_name']"));
        //skol prakse
        private IWebElement prakseBtn => webDriver.FindElement(By.XPath("/html/body/form/div[3]/div[2]/div/div/div/div/div/div[3]/div/div[1]/div[2]/div/div/fieldset[4]/table/tbody/tr[2]/td[1]/div[2]/div[1]/div[2]/button[2]"));
        private IWebElement prakseChooseBtn => webDriver.FindElement(By.XPath("//*[@id='cr36b_skolniekaprakse_lookupmodal']/div/section/div/div/div[3]/button[1]"));
        private IWebElement prakseText => webDriver.FindElement(By.XPath("//*[@id='cr36b_skolniekaprakse_name']"));
        //errors
        private IList <IWebElement> errors => webDriver.FindElements(By.CssSelector("#ValidationSummaryEntityFormControl_348ae3444d0deb11a813000d3ab8cd41_EntityFormView > ul > li"));

        public void goToPage(){
            webDriver.Navigate().GoToUrl("https://epraksedev.powerappsportals.com/lv-LV/profils");
        }

        public void inputDarbuSaku(string text){
            DarbuSaku.SendKeys(text);
        }

        public void inputDarbuBeidzu(string text){
            DarbuBeidzu.SendKeys(text);
        }

        public void inputKomentars(string text){
            Komentars.SendKeys(text);
        }
//DP func
        public void clickDPBtn(){
            dienasPlansBtn.Click();
        }

        public void clickDPchoose(){
            dienasChooseBtn.Click();
        }

        public IWebElement getDP(){
            return dienasText;
        }
//Praks func

        public void clickPrakBtn(){
            prakseBtn.Click();
        }

        public void clickPrakChoose(){
            prakseChooseBtn.Click();
        }

        public IWebElement getPrak(){
            return prakseText;
        }
//generic
        public void clickSave(){
            SaveButton.Click();
        }

        public IList <IWebElement> getErrors(){
            return errors;
        }
    }
}