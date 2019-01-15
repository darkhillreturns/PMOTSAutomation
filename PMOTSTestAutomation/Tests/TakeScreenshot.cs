using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
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
using System.IO;

namespace PMOTSTestAutomation.Tests
{
    public class TakeScreenshot
    {
        public static void CaptureScreenshot(IWebDriver maindriver, string screenShotName)
        {

            string localpath = "";
            var dateAndTime = DateTime.Now;
            int year = dateAndTime.Year;
            int month = dateAndTime.Month;
            int day = dateAndTime.Day;
            string date;

            try
            {
                Thread.Sleep(4000);
                date = String.Format("{0}{1}{2}", month, day, year);
                ITakesScreenshot ts = (ITakesScreenshot)maindriver;
                Screenshot screenshot = ts.GetScreenshot();
                localpath = @"C:\Users\kkierulf\Documents\QA Projects\PMOTSTestAutomation\PMOTSTestAutomation\Screenshots\" + screenShotName + "_" + date + ".Jpeg";
                Console.WriteLine(date);

                //screenshot.SaveAsFile(@"C:\Users\kkierulf\Documents\QA Projects\PMOTSTestAutomation\PMOTSTestAutomation\Screenshots\" + TestContext.CurrentContext.Test.Name + ".Jpeg);

                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            
        }
    }
}
