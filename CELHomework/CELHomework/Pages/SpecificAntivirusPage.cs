using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace CELHomework.Pages
{
    class SpecificAntivirusPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "mesaj_custom")]
        private IWebElement popUpBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".buttons form .btn")]
        private IWebElement addToCartButton { get; set; }

        [FindsBy(How = How.Id, Using = "btngocart")]
        private IWebElement gotoCartButton { get; set; }

        public SpecificAntivirusPage(IWebDriver dr)
        {
            this.driver = dr;
            PageFactory.InitElements(driver, this);
        }

        public void dismissPopUp()
        {
            if (popUpBox.Displayed)
            {
                Assert.IsTrue(driver.FindElement(By.XPath(".//div[@id='mesaj_casuta']//a[@onclick='modal_close();return false;']")).Displayed);
                driver.FindElement(By.XPath(".//div[@id='mesaj_casuta']//a[@onclick='modal_close();return false;']")).Click();
            }
        }

        public void addItemToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(ExpectedConditions.ElementToBeClickable(addToCartButton));
//          se pare ca WebDriverWait nu functioneaza asa ca vom folosi Thread.Sleep :)

            Thread.Sleep(3000);
            addToCartButton.Click();
        }

        public void goToCartPage()
        {
            Thread.Sleep(3000);
            gotoCartButton.Click();
        }
    }
}
