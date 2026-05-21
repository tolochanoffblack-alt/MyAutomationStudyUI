using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace MyAutomationStudyUI.Core
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string downloadPath;

        [SetUp]
        public void SetUp()
        {
            downloadPath = Path.Combine(Directory.GetCurrentDirectory(), "TestDownloads");
            Directory.CreateDirectory(downloadPath);

            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", downloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        protected void DeleteFileIfExists(string fileName)
        {
            string filePath = Path.Combine(downloadPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        protected bool WaitForFileDownloaded(string fileName, int timeoutInSeconds = 20)
        {
            string filePath = Path.Combine(downloadPath, fileName);
            string tempFilePath = filePath + ".crdownload";

            DateTime endTime = DateTime.Now.AddSeconds(timeoutInSeconds);

            while (DateTime.Now < endTime)
            {
                bool fileExists = File.Exists(filePath);
                bool tempFileExists = File.Exists(tempFilePath);

                if (fileExists && !tempFileExists)
                {
                    return true;
                }

                Thread.Sleep(500);
            }

            return false;
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}