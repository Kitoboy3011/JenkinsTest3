using JenkinsTest3.PageObject;
using JenkinsTest3.Utils;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest3.Test
{
    [TestFixture]
    class Test
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        WebDriverUtils webDriverUtils = new WebDriverUtils();
        ChromeDriver Driver;

        [SetUp]
        public void SetUp()
        {
            logger.Info("Тест-кейс " + TestContext.CurrentContext.Test.ClassName);
            Driver = webDriverUtils.InitDriver();
            Driver.Navigate().GoToUrl("https://santehnika-online.ru/");
        }
        [Test]
        public void TransitionToMixerCatalogPage()
        {
            logger.Info("Тест " + TestContext.CurrentContext.Test.Name);
            HomePage homePage = new HomePage(Driver);
            MixerCatalogPage mixerCatalogPage = homePage.ClickOnMixerButton();
            Assert.IsTrue(mixerCatalogPage.IsOpen());
        }
        [Test]
        public void TransitionToStworkiCollectionPage()
        {
            logger.Info("Тест " + TestContext.CurrentContext.Test.Name);
            HomePage homePage = new HomePage(Driver);
            StworkiCollectionPage stworkiCollectionPage = homePage.ClickOnStworkiCollectionButton();
            Assert.IsTrue(stworkiCollectionPage.IsOpen());
        }
        [TearDown]
        public void TearDown()
        {
            logger.Info("Делаю скриншот страницы");
            ScreenshotCaster(Driver);
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure
            || TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                logger.Info("Тест не пройден" + TestContext.CurrentContext.Result.Message + "\n"
                + TestContext.CurrentContext.Result.StackTrace);
            }
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                logger.Info("Тест пройден успешно");
            }
            webDriverUtils.CloseDriver(Driver);
            logger.Info("Скриншоты загружены в C:\\Users\\isa4e\\source\\repos\\JenkinsTest3\\JenkinsTest3\\bin\\Debug\\logs\\");
        }
        public void ScreenshotCaster(ChromeDriver Driver)
        {
            ITakesScreenshot ssDriver = Driver;
            Screenshot screenshot = ssDriver.GetScreenshot();
            screenshot.SaveAsFile("C:\\Users\\isa4e\\source\\repos\\JenkinsTest3\\JenkinsTest3\\bin\\Debug\\logs\\" + TestContext.CurrentContext.Test.Name + ".jpg");
        }
    }
}
