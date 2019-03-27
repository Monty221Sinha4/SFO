using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Html5;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace TestProject1
{
    [TestClass]
    public class TestProject
    {
        [TestMethod]
        public void TwitterMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.Twitter.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("searchinput")).SendKeys("Selenium");
            driver.FindElement(By.ClassName("Icon Icon--medium Icon-search")).Click();
            driver.Quit();
        }
        [TestMethod]
        public void ChromeMethod()
        {
            string ActualResult;
            string ExecptedResult = "Bing";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            ActualResult = driver.Title;
            if (ActualResult.Contains(ExecptedResult))
            {
                Console.WriteLine("Test Passed");
                Assert.IsTrue(true, "Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }
            driver.Close();
            driver.Quit();
        }
        [TestMethod]
        public void FireFoxMethod()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Manage().Window.Maximize();
            driver.Close();
            driver.Quit();
        }
        [TestMethod]
        public void IEMethod()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Manage().Window.Maximize();
            driver.Close();
            driver.Quit();
        }
       [TestMethod]
       public void WikiMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki");
            driver.Manage().Window.Maximize();
            List<string> textofAnchor = new List<string>();
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("b"));
            foreach(IWebElement anchor in anchorLists)
            {
                textofAnchor.Add(anchor.Text);
            }
            string stop = "";
           
            driver.FindElement(By.Name("search")).SendKeys("Selenium");
            driver.FindElement(By.XPath("//*[@id='ooui - php - 1']")).Click();

            driver.Quit();

        }
    }
}
