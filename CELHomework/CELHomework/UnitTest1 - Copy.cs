using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using CELHomework.Pages;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace CELHomework
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\cciocoveanu");
            driver.Navigate().GoToUrl("http://cel.ro");

            HomePage homePage = new HomePage(driver);
            AntivirusPage antivirusPage = new AntivirusPage(driver);
            SpecificAntivirusPage specificantivirus = new SpecificAntivirusPage(driver);
            CartPage cartPage = new CartPage(driver);

            List<string> testList = new List<string>();
            testList.Add("CEL.ro");
            testList.Add("Software");
            testList.Add("Antivirus");

            Assert.That(driver.Title, Contains.Substring("CEL"));           
            homePage.clickElement(8);
            homePage.clickAntivirus();

            Assert.That(driver.Title, Contains.Substring("Antivirus"));
            Assert.IsTrue(antivirusPage.getPathList().SequenceEqual(testList));
            antivirusPage.clickAntivirus("Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite");

            Assert.That(driver.Title, Contains.Substring("Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite"));
            specificantivirus.dismissPopUp();
            specificantivirus.addItemToCart();
            specificantivirus.goToCartPage();

            Assert.That(driver.Title, Contains.Substring("Continut cos"));
            cartPage.setAmount(3);
            Assert.AreEqual(cartPage.getFinalPrice(), 300);

            Thread.Sleep(1000);
            driver.Close();
        }
    }
}
