using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YouGoGetData.Classes
{
  public static  class Extension
    {
        public static void ClickOn(this IWebElement webElement, IJavaScriptExecutor js)
        {

            String script = "return arguments[0].scrollIntoView();";
            js.ExecuteScript(script, webElement);
            Thread.Sleep(500);
            webElement.Click();

        }
    }
}
