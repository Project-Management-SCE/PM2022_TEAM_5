using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Remote;
// using OpenQA.Selenium.Firefox;

namespace Automation
{
    public class Tests
    {
        public IWebDriver _driver;
        // public IWebDriver _driver2;
        private const string URL = "http://sportapisce.herokuapp.com/";
        private const string userName = "admin";
        private const string password = "Asd123!";
        private const string StandardUser = "standard22";
        private const string VipUser = "vip";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void VerifyLoginAndHomeAndLogout()        
        {
            const string title = "Home page - Sport Api S.C.E";
            _driver.Navigate().GoToUrl(URL);
            _driver.FindElement(By.Id("Model_EmailOrUserName")).SendKeys(userName);
            _driver.FindElement(By.Id("Model_Password")).SendKeys(password);
            _driver.FindElement(By.ClassName("btn-primary")).Click();
            string HomeTitle = string.Copy(_driver.Title);
            Assert.AreEqual(HomeTitle, title);
            Assert.NotNull(_driver.FindElements(By.XPath("//a[@href='#tennis']")));
            Assert.AreEqual(_driver.Title, "- Sport Api S.C.E");
        }
        [Test]
        public void VerifySoccerApi()
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.FindElement(By.Id("Model_EmailOrUserName")).SendKeys(userName);
            _driver.FindElement(By.Id("Model_Password")).SendKeys(password);
            _driver.FindElement(By.ClassName("btn-primary")).Click();            
            Assert.NotNull(_driver.FindElement(By.XPath("//div[@class='match']")));
        }

        [Test]
        public void VerifyStandardLimit()
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.FindElement(By.Id("Model_EmailOrUserName")).SendKeys(StandardUser);
            _driver.FindElement(By.Id("Model_Password")).SendKeys(password);
            _driver.FindElement(By.ClassName("btn-primary")).Click();
            Assert.NotNull(_driver.FindElements(By.Id("userpanel")));
            Assert.NotNull(_driver.FindElements(By.XPath("//a[@href='#soccer']")));
            Assert.IsFalse(_driver.FindElements(By.XPath("//a[@href='#tennis']")).Count>0);
            Assert.IsEmpty(_driver.FindElements(By.Id("leagues")));
            Assert.IsEmpty(_driver.FindElements(By.Id("favourite_team")));
            Assert.IsEmpty(_driver.FindElements(By.Id("adminpanel")));
        }

        [Test]
        public void VerifyVipLimit()
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.FindElement(By.Id("Model_EmailOrUserName")).SendKeys(VipUser);
            _driver.FindElement(By.Id("Model_Password")).SendKeys(password);
            _driver.FindElement(By.ClassName("btn-primary")).Click();
            Assert.NotNull(_driver.FindElements(By.Id("userpanel")));
            Assert.NotNull(_driver.FindElements(By.XPath("//a[@href='#soccer']")));
            Assert.NotNull(_driver.FindElements(By.XPath("//a[@href='#tennis']")));
            Assert.NotNull(_driver.FindElements(By.Id("leagues")));
            Assert.NotNull(_driver.FindElements(By.Id("favourite_team")));
            Assert.IsEmpty(_driver.FindElements(By.Id("adminpanel")));
        }

        [Test]
        public void VerifyAdminPanel()
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.FindElement(By.Id("Model_EmailOrUserName")).SendKeys(userName);
            _driver.FindElement(By.Id("Model_Password")).SendKeys(password);
            _driver.FindElement(By.ClassName("btn-primary")).Click();
            Assert.IsNotEmpty(_driver.FindElements(By.Id("adminPanel")));
            _driver.FindElement(By.Id("adminPanel")).Click();            
            _driver.FindElement(By.XPath("//a[@href='/EditNews']")).Click();
            _driver.FindElement(By.Id("Text")).SendKeys("text from automation test");
            _driver.FindElement(By.XPath("//button[text()='Edit News']")).Click();
            System.Threading.Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//a[text()='Home']")).Click();            
            Assert.AreEqual(_driver.FindElement(By.TagName("marquee")).Text, "text from automation test");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
