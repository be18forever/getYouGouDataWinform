using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace YouGoGetData.Classes
{
    public   class DataHelper
    {
        private static IWebDriver _webDriver;
        private static WebDriverWait _wait;
        private static IJavaScriptExecutor _js;

        public DataHelper()
        {
     
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            _webDriver = new ChromeDriver(driverService);
            _wait=  new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _js=(IJavaScriptExecutor)_webDriver;
          
        }

    public   void login(string username,string password,string country)
        {
            // new DriverManager().SetUpDriver(new ChromeConfig());


            GlobalData.MainForm.LogMsg("准备登录");
            GlobalData.MainForm.LogMsg("开始自动填写账号密码");
            _webDriver.Manage().Timeouts().ImplicitWait.TotalSeconds.Equals(30);
          
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _webDriver.Navigate().GoToUrl("https://app.yollgo.com/#/account/login");  //driver.Url = "http://www.baidu.com"是一样的
           
            var source = _webDriver.PageSource;
            var account = By.XPath("/html/body/div[1]/ion-nav-view/ion-nav-view/ion-view/ion-content/div[1]/div/div[2]/ion-list/div/label[2]/input");
            var key = By.XPath("/html/body/div[1]/ion-nav-view/ion-nav-view/ion-view/ion-content/div[1]/div/div[2]/ion-list/div/label[3]/input");
            var loadinded = false;
            while (!loadinded)
            {
                try
                {
                    Thread.Sleep(1000);
                    _webDriver.FindElement(account).SendKeys(username);
                    _webDriver.FindElement(key).SendKeys(password);
                    //driver.FindElement(account).SendKeys("3663575520");
                    //driver.FindElement(key).SendKeys("123456");
                    loadinded = true;
                }
                catch (Exception)
                {

                }

            }
            Thread.Sleep(2000);
            _webDriver.FindElement(By.Id("_label-0")).Click();

            Thread.Sleep(1000);

            var countryList = _wait.Until((d) =>
            {
                try
                {
                    return _webDriver.FindElements(By.XPath("/html/body/div[6]/div[2]/ion-modal-view/ion-content/div[1]/ion-list/div/ion-item"));
                }
                catch (Exception ex)
                {
                    return null;
                }
            });
            //wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[6]/div[2]/ion-modal-view/ion-content/div[1]/ion-list/div/ion-item")));
            //var countryList = driver.FindElements(By.XPath("/html/body/div[6]/div[2]/ion-modal-view/ion-content/div[1]/ion-list/div/ion-item"));
            //Thread.Sleep(2000);
            Thread.Sleep(3000);
            foreach (var item in countryList)
            {
                if (country.Contains(item.Text.Split('+')[0]))
                {

                    _wait.Until(ExpectedConditions.ElementToBeClickable(item));
                    Thread.Sleep(2000);
                    item.Click();
                    break;
                }
            }
            var loginBtn = _wait.Until((d) =>
            {
                return _webDriver.FindElement(By.XPath("/html/body/div[1]/ion-nav-view/ion-nav-view/ion-view/ion-content/div[1]/div/div[2]/div/button"));

            });
            _wait.Until(ExpectedConditions.ElementToBeClickable(loginBtn));
            Thread.Sleep(2000);
            loginBtn.Click();
            getDatas();
        }

        public static void getDatas()
        {
            var firstTime = 0;
            while (true)
            {
                try
                {


                 

                    if (firstTime > 0)
                    {
                        Thread.Sleep(5000);
                        _webDriver.Navigate().Refresh();
                    }
                    firstTime++;
                    Thread.Sleep(2000);
                    //获取店铺名称
                    GlobalData.MainForm.LogMsg("获取店铺名称");
                    _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[1]/ion-view/ion-content/div[1]/div[2]/div/div")));
                    var shopList = _wait.Until((d) =>
                    {
                        return _webDriver.FindElements(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[1]/ion-view/ion-content/div[1]/div[2]/div/div"));

                    });
                    var shopName = new List<string>();
                    foreach (var item in shopList)
                    {
                        shopName.Add(item.GetAttribute("innerText").Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                    }
                    var list = Country.getCountryList();

                    List<Shop> shops = new List<Shop>();
                    var countS = 0;
                    foreach (var item in shopName)
                    {
                        var shop = new Shop();
                        shop.Name = item;
                        shop.Index = countS;
                        shops.Add(shop);
                        countS++;
                    }

                    GlobalData.ShopList = shops;

                    var count = 0;
                    foreach (var item in shopName)
                    {
   
                        Console.WriteLine(count + ":" + item.ToString());
                        count++;
                    }

                    while (GlobalData.ShopNameIndex < 0)
                    {
                      
                    }
                 
                    var shopId = GlobalData.ShopNameIndex;
                    var shopListId = Convert.ToInt32(shopId);
                    shopList[GlobalData.ShopNameIndex].ClickOn(_js);
                    var chooseShopName = shopName[Convert.ToInt32(shopId.ToString())];
                    GlobalData.MainForm.LogMsg("你选择了:" + chooseShopName);
                    _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@ng-repeat='i in categorys']")));
                    var catalogList = _wait.Until((d) =>
                    {
                        return _webDriver.FindElements(By.XPath("//*[@ng-repeat='i in categorys']"));

                    });


                    #region 表格设置
                    HSSFWorkbook hssfworkbook;
                    hssfworkbook = new HSSFWorkbook();
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = WebConfigurationManager.AppSettings["Brandname"] + "System";
                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Subject = "Export Data";
                    hssfworkbook.SummaryInformation = si;
                    ISheet sheet1 = hssfworkbook.CreateSheet("sheet1");

                    ICellStyle style = hssfworkbook.CreateCellStyle();
                    style.Alignment = HorizontalAlignment.Center;
                    style.WrapText = false;
                    style.BorderTop = BorderStyle.Thin;
                    style.BorderLeft = BorderStyle.Thin;
                    style.BorderRight = BorderStyle.Thin;
                    style.BorderBottom = BorderStyle.Thin;
                    IFont font = hssfworkbook.CreateFont();
                    font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                    style.SetFont(font);
                    var row1 = sheet1.CreateRow(0);
                    row1.CreateCell(1).SetCellValue("包装数");
                    row1.CreateCell(2).SetCellValue("编号");
                    row1.CreateCell(3).SetCellValue("名称");
                    row1.CreateCell(4).SetCellValue("图片地址");
                    row1.CreateCell(5).SetCellValue("usercode");
                    row1.CreateCell(6).SetCellValue("装箱数量");
                    row1.CreateCell(7).SetCellValue("类型");
                    row1.CreateCell(8).SetCellValue("价格");
                    var index = 1;



                    #endregion



                    var catalogListCount = catalogList.Count;
                    var totalProducts = 0;
                    var productItems = 1;
                    //循环目录列表

                    //如果不是第一次,刷新后重新获取目录列表

                    _webDriver.Navigate().Refresh();

                    _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@ng-repeat='i in categorys']")));
                    catalogList = _wait.Until((d) =>
                    {
                        return _webDriver.FindElements(By.XPath("//*[@ng-repeat='i in categorys']"));

                    });
                    catalogList[0].ClickOn(_js);
                    try
                    {



                        _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@collection-repeat='i in products' and @style!='transform: translate3d(-9999px, -9999px, 0px); height: 0px; width: 0px;' ]")));
                    }
                    catch (Exception)
                    {


                    }




                    var existNextButton = true;
                    try
                    {
                        //顶部的目录按钮
                        var muluTitle = _wait.Until((d) =>
                        {

                            return _webDriver.FindElement(By.XPath("//div[@nav-bar='active']//div[@class='home-product-list']"));

                        });
                        muluTitle.Click();
                        Thread.Sleep(1000);

                        //顶部的点开后的目录列表
                        var muluList = _wait.Until((d) =>
                        {

                            return _webDriver.FindElements(By.XPath("//div[@class='modal-backdrop active']//*[@ng-repeat='father in fathercategorys']"));

                        });

                        for (int i = 0; i < muluList.Count; i++)
                        {

                            //点击目录按钮
                            try
                            {
                                muluTitle = _wait.Until((d) =>
                                {

                                    return _webDriver.FindElement(By.XPath("//div[@nav-bar='active']//div[@class='home-product-list']"));

                                });
                                Thread.Sleep(1000);
                                muluTitle.Click();
                                Thread.Sleep(2000);
                            }
                            catch
                            {
                            }

                            //点击目录分类
                            try
                            {
                                muluList = _wait.Until((d) =>
                                {

                                    return _webDriver.FindElements(By.XPath("//div[@class='modal-backdrop active']//*[@ng-repeat='father in fathercategorys']"));

                                });
                                muluList[i].ClickOn(_js);
                            }
                            catch
                            {

                            }

                            //点击目录分类子类列表
                            var childList = _wait.Until((d) =>
                            {

                                return _webDriver.FindElements(By.XPath("//div[@class='modal-backdrop active']//*[@ng-repeat='child in childcategorys']"));

                            });

                            for (int g = 0; g < childList.Count; g++)
                            {
                                try
                                {  //点击目录分类
                                    muluTitle = _wait.Until((d) =>
                                    {

                                        return _webDriver.FindElement(By.XPath("//div[@nav-bar='active']//div[@class='home-product-list']"));

                                    });
                                    Thread.Sleep(1000);
                                    muluTitle.Click();
                                    Thread.Sleep(500);
                                }
                                catch { }

                                //点击目录分类子类列表
                                try
                                {
                                    childList = _wait.Until((d) =>
                                    {

                                        return _webDriver.FindElements(By.XPath("//div[@class='modal-backdrop active']//*[@ng-repeat='child in childcategorys']"));

                                    });
                                    Thread.Sleep(1000);
                                    childList[g].ClickOn(_js);
                                }
                                catch { }

                                Thread.Sleep(1000);
                                //获取商品列表

                                var goodList = _wait.Until((d) =>
                                {
                                    // return driver.FindElements(By.XPath("//*[@collection-repeat='i in products' and @style!='transform: translate3d(-9999px, -9999px, 0px); height: 0px; width: 0px;' ]"));
                                    return _webDriver.FindElements(By.XPath("//ion-view[@nav-view='active']//*[not(contains(@style,'-9999px')) and @collection-repeat='i in products']"));
                                    //return driver.FindElements(By.XPath("//ion-view[@style='opacity: 1; transform: translate3d(0%, 0px, 0px);']//div[@collection-repeat='i in products']"));

                                });
                                while (goodList.Count == 0)
                                {
                                    goodList = _wait.Until((d) =>
                                    {
                                        // return driver.FindElements(By.XPath("//*[@collection-repeat='i in products' and @style!='transform: translate3d(-9999px, -9999px, 0px); height: 0px; width: 0px;' ]"));
                                        return _webDriver.FindElements(By.XPath("//ion-view[@nav-view='active']//*[not(contains(@style,'-9999px')) and @collection-repeat='i in products']"));
                                        //return driver.FindElements(By.XPath("//ion-view[@style='opacity: 1; transform: translate3d(0%, 0px, 0px);']//div[@collection-repeat='i in products']"));
                                    });
                                }
                                Thread.Sleep(1000);
                                var categoryName = _wait.Until((d) =>
                                {

                                    return _webDriver.FindElement(By.XPath("//div[@nav-bar='active']//div[@class='home-product-list']")).Text;

                                });

                                //遍历商品列表
                                for (int n = 0; n < goodList.Count; n++)
                                {
                                    try
                                    {
                                        GlobalData.MainForm.LogMsg("产品数量:" + productItems);
                                        goodList[n].ClickOn(_js);
                                    }
                                    catch (Exception ex)
                                    {

                                        continue;
                                    }
                                    sheet1.SetColumnWidth(0, 27 * 256);
                                    // Console.WriteLine("产品数量:" + productItems);

                                    var rown = sheet1.CreateRow(index++);

                                    var categoryNameList = _wait.Until((d) =>
                                    {
                                        return _webDriver.FindElement(By.XPath("//*[@ng-click='openMoreCategory()']"));

                                    });
                                    //Thread.Sleep(1800);
                                    categoryNameList = _webDriver.FindElement(By.XPath("//*[@ng-click='openMoreCategory()']"));

                                    //获取商品信息
                                    try
                                    {






                                        #region 获取产品内容部分


                                        //if (!Directory.Exists(dirpath))
                                        //{
                                        //    Directory.CreateDirectory(dirpath);

                                        Thread.Sleep(300);
                                        _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ion-view[@nav-view='active']//ion-slide[@data-index='1']")));
                                        // Thread.Sleep(1000);
                                        var barcodeParent = _wait.Until((d) =>
                                        {
                                            return _webDriver.FindElement(By.XPath("//ion-view[@nav-view='active']//ion-slide[@data-index='1']"));
                                        });
                                        Thread.Sleep(190);
                                        var childs = barcodeParent.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                                        var title = childs[0];

                                        var barcode = childs[1];
                                        var userCode = childs[1];
                                        if (childs[1].Split('(').Length > 1)
                                        {
                                            barcode = childs[1].Split('(')[1].Replace(")", "");
                                            userCode = childs[1].Split('(')[0];
                                        }
                                        //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view/ion-view[3]/div/div[1]/ion-slide[2]/ion-scroll/div/div/div/div[2]/div[1]/img")));
                                        _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@style,' translate(0px, 0px) translateZ(0px)')]//img")));
                                        var url = _wait.Until((d) =>
                                        {
                                            //return driver.FindElement(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view/ion-view[3]/div/div[1]/ion-slide[2]/ion-scroll/div/div/div/div[2]/div[1]/img")).GetAttribute("SRC");
                                            return _webDriver.FindElement(By.XPath("//*[contains(@style,' translate(0px, 0px) translateZ(0px)')]//div[@class='panel-bottom']//img")).GetAttribute("SRC");
                                        });
                                        var img = _wait.Until((d) =>
                                        {
                                            return _webDriver.FindElement(By.XPath("//*[@ng-click='BigPhoto.open(shopid, i, 600, 600, 1024, 1024)']"));

                                        });
                                        // driver.FindElement(By.XPath("//*[@ng-click='BigPhoto.open(shopid, i, 600, 600, 1024, 1024)']")).Text;


                                        //TakeScreenShotOfElement(driver, dirpath, imageName, img);
                                        var imgSaveDir = System.Environment.CurrentDirectory + "/downloadImgs";
                                        if (!Directory.Exists(imgSaveDir))
                                        {
                                            Directory.CreateDirectory(imgSaveDir);
                                        }
                                        var imgUrl = url;//img.GetAttribute("src");
                                        var imageName = imgUrl.Substring(imgUrl.LastIndexOf("/") + 1, imgUrl.Length - imgUrl.LastIndexOf("/") - 1);
                                        var imgFilePath = imgSaveDir + "/" + imageName + ".jpg";
                                        if (!File.Exists(imgFilePath))
                                        {
                                            using (WebClient webClient = new WebClient())
                                            {

                                                webClient.DownloadFile(imgUrl, imgFilePath);
                                            }
                                        }

                                        Thread.Sleep(100);
                                        if (File.Exists(imgFilePath))
                                        {
                                            //将图片文件读入一个字符串
                                            byte[] bytes = System.IO.File.ReadAllBytes(imgFilePath);
                                            int pictureIdx = hssfworkbook.AddPicture(bytes, NPOI.SS.UserModel.PictureType.JPEG);
                                            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
                                            HSSFClientAnchor anchor = new HSSFClientAnchor(10, 2, 0, 0, 0, productItems, 1, productItems + 1);
                                            //把图片插到相应的位置
                                            HSSFPicture pict = (HSSFPicture)patriarch.CreatePicture(anchor, pictureIdx);
                                        }
                                        productItems++;
                                        var baoZhuangShu = childs[2];
                                        var zhuangXiangShu = childs[2];

                                        if (childs[2].Split('/').Length == 2)
                                        {
                                            baoZhuangShu = childs[2].Split('/')[0].Split(':')[1];
                                            zhuangXiangShu = childs[2].Split('/')[1].Split(':')[1];
                                        }


                                        var price = childs[3];

                                        rown.Height = 100 * 20;
                                        rown.CreateCell(1).SetCellValue(baoZhuangShu);
                                        rown.CreateCell(2).SetCellValue(barcode);
                                        rown.CreateCell(3).SetCellValue(title);
                                        rown.CreateCell(4).SetCellValue(imgUrl);
                                        rown.CreateCell(5).SetCellValue(barcode);
                                        rown.CreateCell(6).SetCellValue(zhuangXiangShu);
                                        rown.CreateCell(7).SetCellValue(categoryName);
                                        rown.CreateCell(8).SetCellValue(price);
                                        _webDriver.Navigate().Back();


                                    }
                                    catch (Exception ex)
                                    {
                                        GlobalData.MainForm.LogMsg(ex.ToString());
                                        _webDriver.Navigate().Back();
                                        break;
                                    }
                                    #endregion
                                }

                                totalProducts += goodList.Count;

                                //try
                                //{
                                //    Thread.Sleep(300);
                                //    js.ExecuteScript("window.scrollTo(0,document.documentElement.clientHeight);");
                                //    var nextButton = driver.FindElement(By.ClassName("button-next"));
                                //    //Actions actions = new Actions(driver);
                                //    //actions.MoveToElement(nextButton);
                                //    //actions.Perform();
                                //    nextButton.ClickOn(js);
                                //    Thread.Sleep(300);
                                //}
                                //catch (Exception ex)
                                //{

                                //    existNextButton = false;
                                //    Console.WriteLine(ex.ToString());
                                //}
                            }
                        }

                        _webDriver.Navigate().Back();
                        _webDriver.Navigate().Back();
                    }
                    catch (Exception ex)
                    {
                        GlobalData.MainForm.LogMsg(ex.ToString());
                        _webDriver.Navigate().Back();
                    }





                    //3、写入，把内存中的workBook对象写入到磁盘上
                    var savePathPre = System.Environment.CurrentDirectory + "/excel";
                    if (!Directory.Exists(savePathPre))
                    {
                        Directory.CreateDirectory(savePathPre);
                    }
                    FileStream fsWrite = File.OpenWrite(System.Environment.CurrentDirectory + "/excel/" + chooseShopName + ".xls");  //导出时Excel的文件名
                    hssfworkbook.Write(fsWrite);
                    fsWrite.Close(); //关闭文件流
                    hssfworkbook.Close();  //关闭工作簿
                    fsWrite.Dispose(); //释放文件流

                    GlobalData.ShopNameIndex = -1;
                    _webDriver.Navigate().GoToUrl("https://app.yollgo.com/#/home/home");

                }
                catch (Exception ex)
                {
                    GlobalData.ShopNameIndex = -1;
                    GlobalData.MainForm.LogMsg(ex.ToString());
                    _webDriver.Navigate().GoToUrl("https://app.yollgo.com/#/home/home");
                }

            }
        }


 
    }
}
