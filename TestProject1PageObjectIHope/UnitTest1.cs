using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1PageObjectIHope;

public class Tests
{
    private IWebDriver _driver;
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://www.aa.com/");
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        var _mainPage = new MainPage(_driver);
        _mainPage.InsertData().Clicks();
        Assert.AreEqual("Passengers",_driver.FindElement(By.XPath("/html/body/main/div/form/h1")).Text);
    }

    [Test]
    public void Test2()
    {
        var _mainpage = new MainPage(_driver);
        _mainpage.Localization();
        Assert.AreEqual("https://www.americanairlines.fr/intl/fr/index.jsp", _driver.Url);
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Close();
    }
}
