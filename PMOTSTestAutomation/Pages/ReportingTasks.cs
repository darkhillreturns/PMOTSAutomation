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
    public class ReportingTasks
    {
            private ExtentReports _extent;
            private ExtentTest test;

            public ReportingTasks(ExtentReports extentInstance)
            {
                _extent = extentInstance;
            }

            public void InitializeTest()
            {
                try
                {
                    test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public void FinalizeTest()
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);

                Status logstatus;

                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        break;
                    case TestStatus.Inconclusive:
                        logstatus = Status.Warning;
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        break;
                    default:
                        logstatus = Status.Pass;
                        break;
                }
                test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
                _extent.RemoveTest(test);
            }

            public void CleanUpReporting()
            {
                _extent.Flush();
            }
        
    }
}
