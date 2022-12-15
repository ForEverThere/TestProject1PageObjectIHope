using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1PageObjectIHope;

public class DownLoadPage
{
    private IWebDriver _driver;

    public DownLoadPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public IWebElement _clickFlight => _driver.FindElement(By.XPath("/html/body/main/div/section[2]/div[3]/ul/li[1]/div/div[2]/div/div[1]/button/div/div[2]"));
    public IWebElement _mainCabin => _driver.FindElement(By.CssSelector("#btn-main-cabin"));
    public IWebElement _continueAsGuest => _driver.FindElement(By.XPath("/html/body/main/div/form/section[3]/button[1]"));
}