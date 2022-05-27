using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace Automation
{
    public class Tests
    {
        public IWebDriver _driver;
        // public IWebDriver _driver2;
        private const string URL = "http://sportapisce.herokuapp.com/";
        private const string userName = "admin";
        private const string password = "Asd123!";

        [SetUp]
        public void Setup()
        {

            // var chromeService = ChromeDriverService.CreateDefaultService();
            //chromeService.SuppressInitialDiagnosticInformation = true;
            //if (!chromeService.IsRunning)
            //    chromeService.Start();

            // var firefoxService  = FirefoxDriverService.CreateDefaultService();
            // firefoxService.SuppressInitialDiagnosticInformation = true;
            // if (!firefoxService.IsRunning)
            //     firefoxService.Start();


            //ChromeOptions options = new ChromeOptions();
            //options.AddAdditionalChromeOption("network.proxy.http", "93.180.7.246");
            //options.AddAdditionalChromeOption("network.proxy.http_port", "8080");
            //options.AddAdditionalCapability(CapabilityType.WebSocketUrl, "http://127.0.0.1:4444");
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("headless");            
            ////options.BinaryLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //options.AddArguments("disable-infobars"); // disabling infobars
            //options.AddArguments("disable-extensions"); // disabling extensions
            //options.AddArgument("disable-gpu"); // applicable to windows os only
            options.AddArgument("disable-dev-shm-usage"); // overcome limited resource problems
            options.AddArgument("no-sandbox"); // Bypass OS security model
            options.AddArgument("whitelisted-ips");

            //string loc =  System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            // Start the child process.
            //var cliProcess = new System.Diagnostics.Process()
            //{
            //    StartInfo = new System.Diagnostics.ProcessStartInfo("sh", "sh --help")
            //    {
            //        UseShellExecute = false,
            //        RedirectStandardOutput = true
            //    }
            //};
            //cliProcess.Start();
            //string cliOut = cliProcess.StandardOutput.ReadToEnd();
            //Console.WriteLine(cliOut);
            //cliProcess.WaitForExit();
            //Console.WriteLine(cliOut);
            //cliProcess.Close();
            //Console.WriteLine(cliOut);
            string driverDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //_driver = new ChromeDriver(driverDirectory, options, TimeSpan.FromSeconds(10));
            //options.BinaryLocation = driverDirectory;
            options.AcceptInsecureCertificates = true;
            //Console.WriteLine("\n\n\tblahhhh\n\n");
            _driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
            Console.WriteLine("\n\n\tend\n\n");


            //_driver = new ChromeDriver(options);
            //_driver.Navigate().GoToUrl(PATH);

            // _driver2 = new FirefoxDriver(options);
        }

        [Test]
        public void VerifyLoginAndHomeAndLogout()        
        {

            const string title = "Home page - Sport Api S.C.E";
            // _driver.Url = URL;
            _driver.Navigate().GoToUrl(URL);
            _driver.FindElement(By.Id("Model_EmailOrUserName")).SendKeys(userName);
            //_driver.FindElement(By.Id("Model_EmailOrUserName")).SendKeys(userName);
            _driver.FindElement(By.Id("Model_Password")).SendKeys(password);
            _driver.FindElement(By.ClassName("btn-primary")).Click();            
            string HomeTitle = string.Copy(_driver.Title);
            Assert.AreEqual(HomeTitle, title);
            _driver.FindElement(By.Id("Logout")).Click();
            Assert.AreEqual(_driver.Title, "- Sport Api S.C.E");
           
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
