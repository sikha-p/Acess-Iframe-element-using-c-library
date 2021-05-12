using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json;

namespace IFrameHandling
{
    public class Class1
    {
        IWebDriver driver;
        public void OpenWindow(string browserDriver, string htmlFilePath)
        {
            if (browserDriver == "googlechrome")
            {
                driver = new ChromeDriver(Environment.CurrentDirectory);  
            }
            else if (browserDriver == "firefox")
            {
                driver = new FirefoxDriver(Environment.CurrentDirectory);
            }
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = htmlFilePath;
        }

        public void manageIframe(string IFrameId, string inputJson)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[id =" + IFrameId + "]")));
            string json = inputJson;//"[{Id:'input1',Value:'Input 1'},{Id:'input2',Value:'Input 2'}]";
            InputElement[] Inputs = JsonConvert.DeserializeObject<InputElement[]>(json);
            foreach (InputElement element in Inputs)
            {
                By Locator = By.Id(element.Id);
                IWebElement inputEle = driver.FindElement(Locator);
                inputEle.SendKeys(element.Value);
            }
        }

        public string HandleIFrame(string browserDriver, string htmlFilePath, string IFrameId, string inputJson)
        {
            if (browserDriver == "googlechrome")
            {
                IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory);
                driver.Manage().Window.Maximize();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Url = htmlFilePath;
                driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[id =" + IFrameId + "]")));
                string json = inputJson;//"[{Id:'input1',Value:'Input 1'},{Id:'input2',Value:'Input 2'}]";
                InputElement[] Inputs = JsonConvert.DeserializeObject<InputElement[]>(json);
                foreach (InputElement element in Inputs)
                {
                    By Locator = By.Id(element.Id);
                    IWebElement inputEle = driver.FindElement(Locator);
                    inputEle.SendKeys(element.Value);
                }
                return "Success";
            }
            if(browserDriver == "firefox")
            {
                IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);
                driver.Manage().Window.Maximize();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Url = htmlFilePath;
                driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[id =" + IFrameId + "]")));
                string json = inputJson;//"[{Id:'input1',Value:'Input 1'},{Id:'input2',Value:'Input 2'}]";
                InputElement[] Inputs = JsonConvert.DeserializeObject<InputElement[]>(json);
                foreach (InputElement element in Inputs)
                {
                    By Locator = By.Id(element.Id);
                    IWebElement inputEle = driver.FindElement(Locator);
                    inputEle.SendKeys(element.Value);
                }
                return "Success";
            }
            return "Success";

        }


       
    }
}
