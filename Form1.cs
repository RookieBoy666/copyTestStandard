using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace copyTestStandard
{
    public partial class Form1 : Form
    {
        public string connStr = "Data Source=192.168.88.6;Initial Catalog = HSFabricTrade_HZFE; Persist Security Info = True;User ID = zjp; Password =123456 ;Connect Timeout = 8";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(old.Text))
                {
                MessageBox.Show("原测试名不能为空！");
                return;

            }
            if (string.IsNullOrEmpty(newTest.Text))
                {
                MessageBox.Show("新测试名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(sCreator.Text))
                {
                MessageBox.Show("创建人不能为空！");
                return;
            }
            try
            {
                string sql = "EXEC dbo.copyTestStandard '" + old.Text.Trim().ToString() + "'," + "'" + newTest.Text.Trim().ToString() + "','" + sCreator.Text.Trim().ToString() + "'";
                SqlConnection Sqlconn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, Sqlconn);
                // SqlCommand getsModelcmd=new SqlCommand(getsModel, Sqlconn);
                Sqlconn.Open();

                cmd.ExecuteNonQuery();//更新qmRawInspectHdr的重量
                Sqlconn.Close();
                MessageBox.Show("复制成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "复制失败！");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            sCreator.Text = "王丽";
        }
    }
}
