using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace Csharp_Selenium_Screenshot
{
    public class ScreenshotCapture
    {
        string ssFileSavePath;
        IWebDriver driver;
       
        //Screenshot File storing Path
        public string ScreenshotFileSavingPath()
        {
            string currentDirectoryPath = Environment.CurrentDirectory;
            string actualPath = currentDirectoryPath.Substring(0, currentDirectoryPath.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            ssFileSavePath = projectPath + "\\Screenshots\\";
            return ssFileSavePath;
        }

        //Take Screenshot
        public void TakeScreenshot(string ImgName)
        {
            try
            {
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot scnshot = screenshotDriver.GetScreenshot();
                Thread.Sleep(4000);
                string sspath = ScreenshotFileSavingPath();
                if (!Directory.Exists(sspath))
                {
                    Directory.CreateDirectory(sspath);
                }
                scnshot.SaveAsFile(sspath + ImgName + "_" + DateTime.Now.ToString("d-M-yyyy") + " Time " + DateTime.Now.ToString("hhmmss tt") + ".png");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Capturing Screenshot " + ex.Message);
            }
        }
    }
}
