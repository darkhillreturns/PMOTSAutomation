using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace PMOTSTestAutomation.Pages
{
    public class LogInPage
    {
        private IWebDriver driver;
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LogInPage(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        #region LogInPage Objects

        private IWebElement UserName
        {
            get
            {
                return this.driver.FindElement(By.Id("username"),10);
            }
        }

        private IWebElement Password
        {
            get
            {
                return this.driver.FindElement(By.Id("password"),10);
            }
        }

        private IWebElement LogInBtn
        {
            get
            {
                return this.driver.FindElement(By.Id("kc-login"),10);
            }
        }

        private IWebElement SuccessLogIn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='content-label']"),10);
            }
        }

        private IWebElement InvalidUsernamePasswordError
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='kc-feedback-text']"), 10);
            }
        }
        #endregion

        #region LogInPage Methods

        public void TypeUserName (string username)
        {
            UserName.SendKeys(username);
        }

        public void TypePassword(string password)
        {
            Password.SendKeys(password);
        }

        public void ClickLogInBtn()
        {
            LogInBtn.Click();
        }

        public void ValidateMessage()
        {
            try
            {
                Assert.AreEqual("Review Requests", SuccessLogIn.Text);
            }
            catch (Exception e)
            {
                log.Error(e);
                Assert.Fail();
            }
        }

        public bool IsAtPage()
        {
            return LogInBtn.Displayed;
        }

        public string GetInvalidLoginErrorMessage()
        {
            return InvalidUsernamePasswordError.Text;
        }
       

        public ReviewRequestsPage FilldatafromCsv()
        {
            string filePath = @"C:\Users\kkierulf\Documents\QA Projects\PMOTSTestAutomation\PMOTSTestAutomation\TestDataAccess\runFile.csv";
            List<string> data = new List<string>();
            data = Servers.general.LoadCsvFile(filePath);

            for (int i = 0; i < data.Count; i++)
            {
                var values = data[i].Split(';');
                TypeUserName(values[0]);
                TypePassword(values[1]);
                ClickLogInBtn();
                ValidateMessage();
            }

            return new ReviewRequestsPage(driver);
        }

        #endregion   
    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }

            return driver.FindElement(by);
        }
    }
}
