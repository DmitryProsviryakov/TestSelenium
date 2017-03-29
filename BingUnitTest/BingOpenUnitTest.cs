using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using NUnit.Framework;

namespace BingUnitTest
{
	/// <summary>
	/// Test class
	/// </summary>
	/// <typeparam name="TWebDriver">Test parameter - browser's driver</typeparam>
	[TestFixture(typeof(FirefoxDriver))]
	[TestFixture(typeof(ChromeDriver))]
	public class BingOpenUnitTest<TWebDriver> where TWebDriver : IWebDriver, new()
	{
		/// <summary>
		/// Browser's driver
		/// </summary>
		IWebDriver _driver;

		/// <summary>
		/// Object of Bing page object model
		/// </summary>
		BingPageObjectModel bing;		

		/// <summary>
		/// Initialization befor tests
		/// Initialize browser's driver
		/// Open bing.com
		/// Search "twitter" in bing
		/// </summary>
		[TestFixtureSetUp]
		public void TestSetup()
		{
			_driver = new TWebDriver();
			_driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
			bing = new BingPageObjectModel(_driver);
			bing.OpenBing();
			bing.Search("twitter");
		}

		/// <summary>
		/// Test for search result
		/// </summary>
		[Test]
		public void TestGetFirstLink()
		{
			string actualResult = bing.GetResultLinks().First().GetAttribute("href");

			Assert.IsNotEmpty(actualResult);
		}

		/// <summary>
		/// Close browser after test
		/// </summary>
		[TestFixtureTearDown]
		public void TearDown()
		{
			_driver.Dispose();
		}
	}
}
