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
    public partial class EDIT_BanAN_Gui : UserControl
    {
        DataSet dt = new DataSet();
        public EDIT_BanAN_Gui()
        {
            InitializeComponent();
        }

        private void EDIT_BanAN_Gui_Load(object sender, EventArgs e)
        {
            Load_DataG_BANAn();
            databingding(dt.Tables["BANAN"]);
        }
        
        public void Load_DataG_BANAn()
        {
            dt.Clear();
            dataGridView1.DataSource = null;
            SqlDataAdapter da = new SqlDataAdapter("select MABA,TENB from BANAN", XuLy_CauTruyVan.Instance.s);
            da.Fill(dt, "BANAN");
            dataGridView1.DataSource = dt.Tables["BANAN"];
        }
        void databingding(DataTable r)
        {
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();

            //textBox1.DataBindings.Add();
            textBox2.DataBindings.Add("Text", r, "MABA");
            textBox3.DataBindings.Add("Text", r, "TENB");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string TenLoai = textBox3.Text;
                if (BanAn_method.Ins.ThemBanAN(TenLoai))
                {
                    MessageBox.Show("Thêm Bàn Thành Công");
                    Load_DataG_BANAn();
                }
                else
                {
                    MessageBox.Show("Đã có Bàn Ăn tồn tại");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Hệ Thống");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int MaLoai = int.Parse(textBox2.Text);
                if (BanAn_method.Ins.XoaBanAN(MaLoai))
                {
                    MessageBox.Show("Xóa Bàn Thành Công");
                    Load_DataG_BANAn();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                int MaLoai = int.Parse(textBox2.Text);
                string TenLoai = textBox3.Text;

                if (BanAn_method.Ins.SuaBanAN(TenLoai, MaLoai))
                {
                    MessageBox.Show("Sửa Bàn ĂN Thành Công");
                    Load_DataG_BANAn();
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            Load_DataG_BANAn();
        }
        void load_DTG_Search(string name)
        {
            dt.Clear();
            
            SqlDataAdapter da = new SqlDataAdapter("select MABA,TENB from BANAN where TENB like N'%"+name+"%'", XuLy_CauTruyVan.Instance.s);
            da.Fill(dt, "BANAN");
            dataGridView1.DataSource = dt.Tables["BANAN"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            load_DTG_Search(textBox1.Text);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
