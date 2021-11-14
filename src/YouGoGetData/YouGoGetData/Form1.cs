using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouGoGetData.Classes;

namespace YouGoGetData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Form_Base_MouseDown;
            initCountrySelectInit();
            userName.Text = "3661128489";
            password.Text = "3661128489";
            GlobalData.MainForm = this;
        }

       


        [DllImport("user32.dll")]  //需添加using System.Runtime.InteropServices
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Form_Base_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }   
        private void initCountrySelectInit()
        {
            var list = Country.getCountryList();
            countrySelects.Items.Clear();
            countrySelects.DisplayMember = "name";        //显示   
            countrySelects.ValueMember = "name";
            countrySelects.DataSource = list;
            countrySelects.SelectedIndex = 0;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (userName.Text.Trim()=="" || password.Text.Trim()=="")
            {

                LogMsg("请输入账号密码");
            }
            else
            {
                GlobalData.MainForm.LogMsg("开始执行");
                GlobalData.MainForm.LogMsg("准备启动浏览器，请稍等");
                GlobalData.UserName = userName.Text;
                GlobalData.Password = password.Text;
                GlobalData.CountryName = countrySelects.Text;


                Task task1 = Task.Run(() => startLogin());
                Task task2 = Task.Run(() => getShopListTask());

            }
        }
        public void getShopListTask()
        {
            while (GlobalData.ShopList == null)
            {


            }
            GlobalData.MainForm.LogMsg("获取到店铺列表，请选择.");
    
            ShopSearchForm shopSearchForm = new ShopSearchForm();
            GlobalData.searchForm = shopSearchForm;
            GlobalData.searchForm.ShowDialog();


        }
             //MethodInvoker mi = new MethodInvoker(() =>
                 //{
                 //    LogMsg("获取到店铺列表，请选择:");
                 //});


        public void startLogin()
        {
            DataHelper dataHelper = new DataHelper();
            dataHelper.login(GlobalData.UserName, GlobalData.Password, GlobalData.CountryName);
        }

        //记录信息
        public void LogMsg(string msg)
        {
            MethodInvoker mi = new MethodInvoker(() =>
            {
                infoWindow.AppendText(string.Empty);
                infoWindow.AppendText(DateTime.Now.ToString("HH:mm:ss   "));
                infoWindow.AppendText(msg);

                infoWindow.AppendText("\n");
                //设定光标所在位置 
                infoWindow.SelectionStart = infoWindow.TextLength;
                //滚动到当前光标处 
                infoWindow.ScrollToCaret();
                //更新富文本
                infoWindow.Update();
            });
            this.BeginInvoke(mi);
        }

    }
}
