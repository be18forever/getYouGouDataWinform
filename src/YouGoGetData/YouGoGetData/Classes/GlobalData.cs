using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouGoGetData.Classes
{
  public static  class GlobalData
    {

        public static string ShopName { get; set; }
        public static int ShopNameIndex { get; set; } = -1;
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string CountryName { get; set; }
        public static ShopSearchForm searchForm { get; set; }
         public static List<Shop> ShopList { get; set; }
         public static Form1 MainForm { get; set; }



    }
}
