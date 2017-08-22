using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace CELHomework.Pages
{
    class CartPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".productListing-data.cantitate>input[type = 'text']")]
        private IWebElement quantityField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".pret_total_final")]
        private IWebElement finalPriceElement { get; set; }

        public CartPage(IWebDriver dr)
        {
            this.driver = dr;
            PageFactory.InitElements(driver, this);
        }

        public void setAmount(int amount)
        {
            quantityField.Clear();
            quantityField.SendKeys(amount.ToString());
            quantityField.Submit();
        }

        public int getFinalPrice()
        {
            return Int32.Parse(finalPriceElement.Text);
        }
    }
}

