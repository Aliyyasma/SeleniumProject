using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NUnitTestProject1
{
    public class FunctionalTest
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void Dropdown()
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            IList<IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement radioButton in rdos)
            {if (radioButton.GetAttribute("value").Equals("user"))
                    radioButton.Click();
            }
        }
    }
}
