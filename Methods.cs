using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using static SFSTest.Locators;

namespace SFSTest
{

    class Methods
    {
        public static ChromeDriver driver;
        public static WebDriverWait wait;
        public static void GoToStartPage()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(webSite);
        }
        public static void SearchFromPage(string search)
        {
            driver.FindElementByXPath(SearchBox).SendKeys(search);
            driver.FindElementByXPath(SearchButton).Click();

        }
        public static void SearchProcess()
        {
            try
            {
                WaitForElement(SearchIndicator);
            }
            catch
            {
                getScreenShot("Error search ");
                throw new ArgumentException("Searching failed");
            }
        }
        public static void RadioIsChecked(string text)
        {
            string xPath = String.Format(RadioName, text);
            WaitForElement(xPath);
            string checking = driver.FindElementByXPath(xPath).GetAttribute("checked");
            if ((checking != "true")&&(isElementPresent(xPath)))
            {
                getScreenShot("Error radiobutton ");
                throw new ArgumentException($"radiobutton with text '{text}' isn't checked");
            }
        }
        public static void ChecksSumOfResults()
        {
            IEnumerable<int> rowResults =
                from element in driver.FindElementsByXPath(SearchTableResults)
                where (int.TryParse(element.Text, out int res))
                select int.Parse(element.Text);
            int sumRowResults = rowResults.Sum();

            string ActualSumMessage = String.Format(SearchResultMessage, sumRowResults);
            if (!driver.FindElementByXPath(SearchSumResults).Text.Equals(ActualSumMessage))
            {
                getScreenShot("Error sum of the result ");
                throw new ArgumentException($"Sum of the result is incorrect, actual sum is '{sumRowResults}'");
            }
        }
        public static void CheckLocation(string expected)
        {
            string actual = driver.Url;
            if (!actual.Equals(expected))
            {
                getScreenShot("Error page location ");
                throw new ArgumentException($"Actual location is '{actual}' which is not an expected one '{expected}'");
            }
        }
        public static void CheckSearchTitle(string input)
        {
            if (!driver.FindElementByXPath(SearchInput).Text.Equals($"«{input}»"))
            {
                getScreenShot("Error search title ");
                throw new ArgumentException($"Input '{input}' isn't presence in search title");
            }
        }
        private static bool isElementPresent(string xPath)
        {
            try
            {
                driver.FindElementByXPath(xPath);
                return true;
            }
            catch
            {
                getScreenShot("Error presence of the element ");
                throw new ArgumentException($"element isn't present, its XPath '{xPath}'");
            }
        }
        private static void WaitForElement(string xPath)
        {
            wait.Until(ExpectedConditions.ElementExists((By.XPath(xPath))));
        }
        private static void getScreenShot(string title)
        {
            string dir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
            string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(dir + "\\Screenshots\\" + Runname + ".jpg");
        }
        public static void TearDown()
        {
            driver.Close();
        }


    }

}