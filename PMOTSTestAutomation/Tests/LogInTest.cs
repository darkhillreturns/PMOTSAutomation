using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

using log4net;
using PMOTSTestAutomation.Pages;

namespace PMOTSTestAutomation.Tests
{ 
    [TestFixture]
    public class LogInTest
    {
        IWebDriver maindriver;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string baseURL = ConfigurationManager.AppSettings["url"];
        
        ExtentReports rep = ReportingManager.Instance();
        ExtentTest test;

        //private static ReportingTasks test;

        [SetUp]
        public void InitializeBrowser()
        {
            ExtentReports rep = ReportingManager.Instance();
            DisposeDriverService.TestRunStartTime = DateTime.Now;

            maindriver = new ChromeDriver();
            maindriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            maindriver.Navigate().GoToUrl(baseURL);

        }

        #region Test Attributes

        [Test]
        public void LogInValidAdminAccount()
        {

            test = rep.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Log(Status.Info, "Starting the Application Test");

            //test.InitializeTest();
            maindriver.Manage().Window.Maximize();

            LogInPage validAdmin = new LogInPage(maindriver);
            validAdmin.FilldatafromCsv();

            TakeScreenshot.CaptureScreenshot(maindriver, TestContext.CurrentContext.Test.Name);
            
        }


        [Test]
        public void Should_StayOnLoginPage_WhenNoLoginDetailsAreInputted()
        {
            test = rep.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Log(Status.Info, "Starting the Application Test");

            LogInPage validAdmin = new LogInPage(maindriver);
            maindriver.Manage().Window.Maximize();

            validAdmin.ClickLogInBtn();
            Assert.AreEqual(validAdmin.GetInvalidLoginErrorMessage(), "Invalid username or password.");
            TakeScreenshot.CaptureScreenshot(maindriver, TestContext.CurrentContext.Test.Name);

            Assert.IsTrue(validAdmin.IsAtPage());
            Thread.Sleep(2000);
        }

        #endregion

        [TearDown]
        public void CloseAllBrowsers()
        {
            rep.Flush();
            DisposeDriverService.FinishHim(maindriver);
        }
    }
}
