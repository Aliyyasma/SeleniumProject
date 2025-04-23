using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
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
    public class AlertsActionsAutoSuggestive
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new WebDriverManager.DriverConfigs.Impl.EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]
        public void frames()
        { IWebElement  frameScroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", frameScroll);
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
        }

        [Test]
        public void test_Alert()
        { String name = "Aliyya";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();

            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();

            StringAssert.Contains(name, alertText);
        }

        [Test]
        public void test_AutoSuggestiveDropDown()
        {
            driver.FindElement(By.CssSelector("#autocomplete")).SendKeys("ind");
            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach ( IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
            }
        }

        [Test]
        public void test_Actions()
        {
            driver.Url = "https://rahulshettyacademy.com/";
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
        }
    }
}
