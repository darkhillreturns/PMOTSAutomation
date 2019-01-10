using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace PMOTSTestAutomation.Pages
{
    public class ReviewRequestsPage
    {
        private IWebDriver driver;

        public ReviewRequestsPage (IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        #region ReviewRequestsPage Objects

        private IWebElement AddRequestBtn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='btn btn-success']"),10);
            }
        } 

        private IWebElement FilterBtn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='glyphicon glyphicon-filter']"),10);
            }
        }
        #endregion

    }
}