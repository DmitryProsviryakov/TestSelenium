using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BingUnitTest
{
	/// <summary>
	/// Page Object model for Bing.com page
	/// </summary>
	public class BingPageObjectModel
	{
		/// <summary>
		/// Browser driver
		/// </summary>
		IWebDriver driver;
		
		/// <summary>
		/// Element for search textbox input
		/// </summary>
		IWebElement searchBox;

		/// <summary>
		/// Element for search button input
		/// </summary>
		IWebElement searchButton;
		
		/// <summary>
		/// Locator for search textbox input
		/// </summary>
		By searchBoxLocator = By.Id("sb_form_q");
		
		/// <summary>
		/// Locator for search button input
		/// </summary>
		By searchButtonLocator = By.Id("sb_form_go");

		/// <summary>
		/// Locator for link's in search result page
		/// </summary>
		By resultLinkLocator = By.CssSelector("#b_results .b_title a");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_driver">Reference to driver of test browser</param>
		public BingPageObjectModel(IWebDriver _driver)
		{
			driver = _driver;
		}

		/// <summary>
		/// Method for open page "http://www.bing.com/" and initialize defaultt bing elements,
		/// which displayd on all bing pages
		/// </summary>
		public void OpenBing()
		{
			driver.Url = "http://www.bing.com/";
			searchBox = driver.FindElement(searchBoxLocator);
			searchButton = driver.FindElement(searchButtonLocator);
		}

		/// <summary>
		/// Method for set some string to search textbox and find information about this in bing
		/// </summary>
		/// <param name="query">search query</param>
		public void Search(string query)
		{
			searchBox.SendKeys(query);

			searchButton.Click();
		}

		/// <summary>
		/// Method for find all result links in the page
		/// </summary>
		/// <returns>List of web elements</returns>
		public IEnumerable<IWebElement> GetResultLinks()
		{
			return driver.FindElements(resultLinkLocator);
		}

		/// <summary>
		/// Method for close browser and is's driver
		/// </summary>
		public void Close()
		{
			driver.Dispose();
		}
	}
}
