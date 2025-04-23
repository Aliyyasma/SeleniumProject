using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NUnitTestProject1
{
    public class WindowHandler
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
        public void WindowHandle()
        {
            String email = "mentor@rahulshettyacademy.com";
            driver.FindElement(By.ClassName("blinkingText")).Click();
            String childWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindow);
            String text = driver.FindElement(By.ClassName("red")).Text;
            String[] splitText = text.Split("at");
            //TestContext.Progress.WriteLine(splitText[0]);
            String trimmedText = splitText[1].Trim();
            String[] finalText = trimmedText.Split(" ");

            Assert.AreEqual(email, finalText[0]);
        }

    }
}
