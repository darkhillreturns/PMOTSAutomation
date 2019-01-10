using System;
using System.Configuration;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using log4net;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using PMOTSTestAutomation.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace PMOTSTestAutomation.Tests
{
    [TestFixture]
    public class CrossBrowserTest
    {
       
        private static IWebDriver driver;
        private static string browser = ConfigurationManager.AppSettings["browser"];
        private static string baseURL = ConfigurationManager.AppSettings["url"];
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ExtentReports rep = ReportingManager.Instance();
        ExtentTest test;

        private static ReportingTasks _reportingTasks;

        [SetUp]
        public static void Init()
        {
            DisposeDriverService.TestRunStartTime = DateTime.Now;
            ExtentReports rep = ReportingManager.Instance();

            try
            {
                switch (browser)
                {
                    case "Chrome":
                        {
                            driver = new ChromeDriver();
                            break;
                        }

                    case "IE":
                        {
                            driver = new InternetExplorerDriver();
                            break;
                        }

                    case "Firefox":
                        {
                            driver = new FirefoxDriver();
                            break;
                        }
                }

                Assert.AreNotEqual(" ", driver.Title);
                //_reportingTasks.InitializeTest();
            }
            catch (Exception e)
            {
                log.Error(e);
                Assert.Fail();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
        }


        [Test]
        public void BrowserTest()
        {
            test = rep.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Log(Status.Info, "Starting the Application Test");

            LogInPage validAdmin = new LogInPage(driver);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\kkierulf\Documents\QA Projects\PMOTSTestAutomation\PMOTSTestAutomation\Screenshots\CrossBrowserTestLogin.jpeg", ScreenshotImageFormat.Jpeg);
            validAdmin.FilldatafromCsv();

            //ExtentReports rep = ReportingManager.Instance();
            //_reportingTasks = new ReportingTasks(rep);
            //rep.AddSystemInfo("Browser", browser);

        }

        [TearDown]
        public void CloseAllBrowsers()
        {
            // _reportingTasks.CleanUpReporting();
            rep.Flush();
            DisposeDriverService.FinishHim(driver);

        }
    }
}
