using System;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace PMOTSTestAutomation.Tests
{
    public class DisposeDriverService
    {
            // This class will close all the browsers opened by WebDriver
            // as this is a common problem in InternetExplorerDriver and OperaDriver.
            private static readonly List<string> _processesToCheck = new List<string>
            {
                "opera",
                "chrome",
                "firefox",
                "ie",
                "gecko",
                "phantomjs",
                "edge",
                "microsoftwebdriver",
                "webdriver"
            };

            public static DateTime? TestRunStartTime { get; set; }

            public static void FinishHim(IWebDriver driver)
            {
                driver?.Dispose();
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    try
                    {
                        Debug.WriteLine(process.ProcessName);
                        if (process.StartTime > TestRunStartTime)
                        {
                            var shouldKill = false;
                            foreach (var processName in _processesToCheck)
                            {
                                if (process.ProcessName.ToLower().Contains(processName))
                                {
                                    shouldKill = true;
                                    break;
                                }
                            }
                            if (shouldKill)
                            {
                                process.Kill();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }
            }
        

    }
}
