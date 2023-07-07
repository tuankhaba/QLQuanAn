using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuanKha.Methods;

namespace TuanKha.UI
{
    public partial class TaiKhoan_Gui : UserControl
    {
        DataSet dt = new DataSet();
        public TaiKhoan_Gui()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string TenLoai = textBox3.Text;
                if (Account_MeThod.Ins.ThemTaiKhoan(int.Parse(textBox2.Text),TenLoai,textBox4.Text,int.Parse(textBox5.Text)))
                {
                    MessageBox.Show("Thêm Loại Món Thành Công");
                    Load_DataG_TaiKhoan();
                }
                else
                {
                    MessageBox.Show("Đã có mã món ăn tồn tại");
                }
            }
            catch
            {
                MessageBox.Show("Chưa Tồn Tại Thông Tin Nhân Viên");
            }
        }

        private void TaiKhoan_Gui_Load(object sender, EventArgs e)
        {
            Load_DataG_TaiKhoan();
            databingding(dt.Tables["account"]);
        }
        void databingding(DataTable r)
        {
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();

            //textBox1.DataBindings.Add();
            textBox2.DataBindings.Add("Text", r, "MANV");
            textBox3.DataBindings.Add("Text", r, "displayname");
            textBox4.DataBindings.Add("Text", r, "pass");
            textBox5.DataBindings.Add("Text", r, "chucv");

        }
        public void Load_DataG_TaiKhoan()
        {
            dt.Clear();
            //dataGridView1.DataSource.Clear();

            SqlDataAdapter da = new SqlDataAdapter("select*from account", XuLy_CauTruyVan.Instance.s);
            da.Fill(dt, "account");
            dataGridView1.DataSource = dt.Tables["account"];
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLoai = int.Parse(textBox2.Text);
                if (Account_MeThod.Ins.XoaTaiKhoan(int.Parse(textBox2.Text)))
                {
                    MessageBox.Show("Xóa Loại Món Thành Công");
                    Load_DataG_TaiKhoan();
                }
                else
                {
                    MessageBox.Show("Không Thể Xóa Do Lỗi Ràng Buộc Khóa Ngoại");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Hệ Thống");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLoai = int.Parse(textBox2.Text);
                string TenLoai = textBox3.Text;

                if (Account_MeThod.Ins.SuaTaiKhoan(int.Parse(textBox2.Text),TenLoai,textBox4.Text,int.Parse(textBox5.Text)))
                {
                    MessageBox.Show("Sửa Món Thành Công");
                    Load_DataG_TaiKhoan();
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Hệ Thống");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Load_DataG_TaiKhoan();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void Load_DataG_TaiKhoan_Search(string name)
        {
            dt.Clear();
            //dataGridView1.DataSource.Clear();

            SqlDataAdapter da = new SqlDataAdapter("select*from account where displayname like N'%"+name+"%'", XuLy_CauTruyVan.Instance.s);
            da.Fill(dt, "account");
            dataGridView1.DataSource = dt.Tables["account"];
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Load_DataG_TaiKhoan_Search(textBox1.Text);
        }
    }
}
