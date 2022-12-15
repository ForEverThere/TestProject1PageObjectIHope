using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1PageObjectIHope;

public class MainPage
{
    private readonly IWebDriver _driver;
    public MainPage(IWebDriver driver)
    {
        _driver = driver;
    }
    private IWebElement _tripType => _driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div/div/div[1]/form/div[2]/div[1]/div[2]/label/span[1]"));
    private IWebElement _fromField => _driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div/div/div[1]/form/div[3]/div[1]/div/label/input"));
    private IWebElement _fromList => _driver.FindElement(By.XPath("/html/body/ul[1]/li/a"));
    private IWebElement _toField => _driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div/div/div[1]/form/div[3]/div[2]/div/label/input"));
    private IWebElement _toList => _driver.FindElement(By.XPath("/html/body/ul[2]/li[1]/a"));
    private IWebElement _dateField => _driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div/div/div[1]/form/div[4]/div[1]/div/label/input"));
    private IWebElement _searchButton => _driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div/div/div[1]/form/div[4]/div[4]/div/input"));

    
    private IWebElement _dropDownMenu => _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div/ul/li[6]/div[1]/a"));
    private IWebElement _countryMenu => _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div/ul/li[6]/div[2]/form/label[1]/select"));
    private IWebElement _countryElement => _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div/ul/li[6]/div[2]/form/label[1]/select/option[30]"));
    private IWebElement _languageMenu => _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div/ul/li[6]/div[2]/form/label[2]/select"));
    private IWebElement _languageElement => _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div/ul/li[6]/div[2]/form/label[2]/select/option[1]"));
    private IWebElement _selectLanguage => _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div/ul/li[6]/div[2]/form/input[1]"));
    public MainPage InsertData(string from = "Barcelona", string to = "Philadelphia", string date = "12/18/2022")
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        _tripType.Click();
        _fromField.SendKeys(from);
        wait.Until(_ => _fromList);
        _fromList.Click();
        _toField.SendKeys(to);
        wait.Until(_ => _toList);
        _toList.Click();
        _dateField.SendKeys(date);
        _searchButton.Click();
        return new MainPage(_driver);
    }

    public DownLoadPage Clicks()
    {
        var downloadPage = new DownLoadPage(_driver);
        var waitLong = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        waitLong.Until((_ => downloadPage._clickFlight));
        downloadPage._clickFlight.Click();
        waitLong.Until((_ => downloadPage._mainCabin));
        downloadPage._mainCabin.Click();
        downloadPage._continueAsGuest.Click();
        waitLong.Until((_ => _driver.FindElement(By.XPath("/html/body/main/div/form/h1"))));
        return new DownLoadPage(_driver);
    }

    public MainPage Localization()
    {
        var waitLong = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        _dropDownMenu.Click();
        _countryMenu.Click();
        _countryElement.Click();
        waitLong.Until(_ => _languageMenu);
        _languageMenu.Click();
        waitLong.Until(_ => _languageElement);
        _languageElement.Click();
        _selectLanguage.Click();
        return new MainPage(_driver);
    }
}