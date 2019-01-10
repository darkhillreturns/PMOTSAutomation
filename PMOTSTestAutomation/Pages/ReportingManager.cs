using System;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace PMOTSTestAutomation.Pages
{
    public class ReportingManager
    {
        public static ExtentHtmlReporter htmlReporter;
        private static ExtentReports extent;

        private ReportingManager()
        {

        }

        public static ExtentReports Instance()
        {

                if (extent == null)
                {
                    string reportPath = @"C:\Users\kkierulf\Documents\QA Projects\PMOTSTestAutomation\PMOTSTestAutomation\Reports\Report.html";
                    htmlReporter = new ExtentHtmlReporter(reportPath);
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("OS", "Windows");
                    extent.AddSystemInfo("Environment", "QA");

                string extentConfigPath = @"C:\Users\kkierulf\Documents\QA Projects\PMOTSTestAutomation\PMOTSTestAutomation\extent-config.xml";
                    htmlReporter.LoadConfig(extentConfigPath);
                }

                return extent;

        }

    }
}
