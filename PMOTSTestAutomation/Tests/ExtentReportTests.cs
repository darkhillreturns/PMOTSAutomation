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
using PMOTSTestAutomation.Pages;


namespace PMOTSTestAutomation.Tests
{
    [TestFixture]
    public class ExtentReportTests
    {
        IWebDriver maindriver;
        private ExtentReports extent;
        private ExtentTest test;

        [Test]

        public void SampleReporting(string browserName)

        {

            //Start Report

            test = extent.CreateTest("SampleReporting"); //”SampleReporting” TestMethod name



            //Log 'info'

            test.Log(LogStatus.Info, "Sample Reporting demo");



            //Pass scenario

            Assert.AreEqual(10, 10);

            test.Log(LogStatus.Pass, "Test Passed");



            //Fail scenario

            Assert.IsTrue(false);



            test.Log(LogStatus.Fail, "Test Failed");

        }


    }
}
