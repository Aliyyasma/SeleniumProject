using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
namespace NUnitTestProject1
{
    public class SortWebTables
    {

        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new WebDriverManager.DriverConfigs.Impl.EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void SortTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByText("20");

            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }
            TestContext.Progress.WriteLine("Before Sorting");
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            a.Sort();
            TestContext.Progress.WriteLine("After Sorting");
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();

            ArrayList b = new ArrayList();
            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);
            }

            Assert.AreEqual(a,b);

        }
    }
}
