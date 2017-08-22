using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;


namespace CELHomework.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "title")]
        private IWebElement title { get; set; }
 
        [FindsBy(How = How.CssSelector, Using = ".categ_name.a1")]
        private IList<IWebElement> elementList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='http://www.cel.ro/antivirus/']")]
        private IWebElement antivirus { get; set; }

        //.categ_name.a1


        public HomePage(IWebDriver dr)
        {
            this.driver = dr;
            PageFactory.InitElements(driver, this);
        }

        public String getTitle()
        {
            return driver.FindElement(By.CssSelector("title")).Text;
        }

        public void clickElement(int index)
        {
            elementList[index-1].Click();

        }
        public void clickAntivirus()
        {
            antivirus.Click();
        }
    }
}
