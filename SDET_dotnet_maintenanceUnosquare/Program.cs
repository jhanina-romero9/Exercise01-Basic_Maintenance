using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
            
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value + Keys.Enter);

        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//textarea[@class='gLFyf']");
        By GoogleSearIcon = By.XPath("//input[contains(@data-ved,'0ahUKEwit1oTT7LOFAxVOK7kGHZZZCm8Q4dUDCBE')]");
        //By UnoSquareGoogleResult = By.XPath("//div[@class='BYM4Nd']/div/div/div/div/div/div/span/a");
        By UnoSquareGoogleResult = By.XPath("//h3[contains(@class,'LC20lb MBeuO DKV0Md')][1]");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.Id("menu-item-8439");
        By PracticeAreas = By.Id("menu-item-8497");
        By ContactUs = By.XPath("(//a[contains(@class,'elementor-button elementor-button-link elementor-size-sm')])[8]");
        #endregion 
        static void Main(string[] args)
        {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            element = Browser.FindElement(program.GoogleSearchBar);

            program.SendText(element, "Unosquare");


            //element = Browser.FindElement(program.GoogleSearIcon);

            //program.Click(element);

            element = Browser.FindElement(program.UnoSquareGoogleResult);

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

            program.driver.Quit();
        }
    }
}
