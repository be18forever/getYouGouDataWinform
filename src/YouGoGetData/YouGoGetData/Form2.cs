using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouGoGetData.Classes;

namespace YouGoGetData
{
    public partial class ShopSearchForm : Form
    {
        public ShopSearchForm()
        {
            InitializeComponent();
            shopNameList.Items.Clear();
            shopNameList.DisplayMember = "name";        //显示   
            shopNameList.ValueMember = "name";
            shopNameList.DataSource = GlobalData.ShopList;
            shopNameList.SelectedIndex = 0;
        }

        private void shopSearchForm_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var shop = shopNameList.Text;
            var shopNameIndex = GlobalData.ShopList.Where(x => x.Name == shop).FirstOrDefault();
            if (shopNameIndex!=null)
            {
                GlobalData.ShopNameIndex = shopNameIndex.Index;
                GlobalData.searchForm.Hide();
            
            }

        }

        private void shopName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {


            var filterList = GlobalData.ShopList;
            //filterList= filterList.Where(x => x.Name.Contains(searchText.Text)).ToList();
            filterList= filterList.Where(x => x.Name.IndexOf(searchText.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            shopNameList.DataSource = null;
            shopNameList.Items.Clear();
            shopNameList.DisplayMember = "name";        //显示   
            shopNameList.ValueMember = "name";
            shopNameList.DataSource = filterList;
            if (filterList.Count>0)
            {
                shopNameList.SelectedIndex = 0;
            }
          
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            GlobalData.searchForm.Hide();
        }
    }
}
