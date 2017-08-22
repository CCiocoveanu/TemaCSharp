using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;


namespace CELHomework.Pages
{
    class AntivirusPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".productListingWrapper span[itemprop = 'name']")]
        private IList<IWebElement> anitivirusLits { get; set; }      

        [FindsBy(How = How.CssSelector, Using = ".breadCrumb b")]
        private IList<IWebElement> pathList { get; set; }

        public AntivirusPage(IWebDriver dr)
        {
            this.driver = dr;
            PageFactory.InitElements(driver, this);
        }

        public void clickAntivirus(String name)
        {
            foreach(var antivirus in anitivirusLits)
            {
                if (antivirus.Text.Contains(name))
                {
                    Assert.That(antivirus.Text, Contains.Substring("Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite"));
                    antivirus.Click();
                    break;
                }
            }
        }

        public List<string> getPathList()
        {
            List<string> list = new List<string>();
            foreach(var path in pathList)
            {
                list.Add(path.Text);
            }
            return list;
        }
        
    }
}           
