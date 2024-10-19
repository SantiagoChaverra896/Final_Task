using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace Final_Task.Utilities
{
	public static class BrowserFactory
	{
		public static IWebDriver CreateDriver(string browserType)
		{
			IWebDriver driver;
			switch (browserType.ToLower())
			{
				case "chrome":
					driver = new ChromeDriver();
					break;
				case "edge":
					driver = new EdgeDriver();
					break;
				case "firefox":
					driver = new FirefoxDriver();
					break;
				default:
					throw new ArgumentException($"Browser type '{browserType}' is not supported.");
			}
			driver.Manage().Window.Maximize();
			return driver;
		}
	}
}
