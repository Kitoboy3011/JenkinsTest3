using JenkinsTest3.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest3.PageObject
{
    class HomePage : BasePageObject
    {
        private readonly ChromeDriver Driver;
        public HomePage(ChromeDriver driver)
        {
            this.Driver = driver;
        }

        private IWebElement MixerCard => Driver.FindElement(By.CssSelector("a[href='/smesiteli/']"));

        private IWebElement CollectionBlock => Driver.FindElement(By.CssSelector("div[class='index-block-container index-popular-collections']"));
        private IWebElement StworkiCollectionBanner => CollectionBlock.FindElement(By.CssSelector("a[aria-label='1 / 10']"));

        public MixerCatalogPage ClickOnMixerButton()
        {
            logger.Info("Нажатие на кнопку Смесители");
            MixerCard.ClickOnElement();
            return new MixerCatalogPage(Driver);
        }
        public StworkiCollectionPage ClickOnStworkiCollectionButton()
        {
            logger.Info("Нажатие на баннер Коллеция Дублин Stworki");
            StworkiCollectionBanner.ClickOnElement();
            return new StworkiCollectionPage(Driver);
        }
    }
}
