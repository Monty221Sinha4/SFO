using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Html5;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
   public void WikiSearch()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki");
        driver.Manage().Window.Maximize();
        List<string> CentralLan = new List<string>();
        ReadOnlyCollection<IWebElement> Lan = driver.FindElements(By.ClassName("central -featured-lang"));
       foreach(IWebElement Lanagauge lang)
        {
            string lang = Lanagauge.Text;
            CentralLan.Add(lang);
        }
        string stop=";"



          SelectElement selectLanaguage = new SelectElement(driver.FindElement(By.Id("SearchLanaguage")));
        selectLanaguage.SelectByText("English");
        selectLanaguage.SelectByValue("Be");
        selectLanaguage.SelectByIndex(0);

        driver.Quit();
    }
}
