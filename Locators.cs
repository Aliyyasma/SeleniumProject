using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NUnitTestProject1
{
    public class Locators
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
        public void LocatorsIdentification()
        {
            //driver.FindElement(By.ClassName("signInBtn")).Click();
            //Thread.Sleep(3000);
            //String errorMessage = driver.FindElement(By.ClassName("error")).Text;
            //TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.FindElement(By.LinkText("Not Sure Where To Begin?"));
            String hrefattr = link.GetAttribute("href");
            String expectedUrl = "https://www.w3schools.com/where_to_start.asp";
            Assert.AreEqual(expectedUrl, hrefattr);
        }
    }
}
