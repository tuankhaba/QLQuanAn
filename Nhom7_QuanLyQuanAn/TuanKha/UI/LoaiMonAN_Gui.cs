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
    public partial class LoaiMonAN_Gui : UserControl
    {
        DataSet dt = new DataSet();
        public LoaiMonAN_Gui()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TenLoai = textBox3.Text;
                if (LoaiMonAn_MeThod.Ins.ThemLoaiMonAN(TenLoai))
                {
                    MessageBox.Show("Thêm Loại Món Thành Công");
                    Load_DataG_LoaiMonAn();
                }
                else
                {
                    MessageBox.Show("Đã có mã loại món ăn tồn tại");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Hệ Thống");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLoai = int.Parse(textBox2.Text);
                if (LoaiMonAn_MeThod.Ins.XoaLoaiMonAN(MaLoai))
                {
                    MessageBox.Show("Xóa Loại Món Thành Công");
                    Load_DataG_LoaiMonAn();
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

                if (LoaiMonAn_MeThod.Ins.SuaLoaiMonAN(TenLoai,MaLoai))
                {
                    MessageBox.Show("Sửa Loại Món Thành Công");
                    Load_DataG_LoaiMonAn();
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
            Load_DataG_LoaiMonAn();
        }
        public void Load_DataG_LoaiMonAn()
        {
            dt.Clear();
            dataGridView1.DataSource = null;
            SqlDataAdapter da = new SqlDataAdapter("select*from LOAI", XuLy_CauTruyVan.Instance.s);
            da.Fill(dt,"LOAI");
            dataGridView1.DataSource = dt.Tables["LOAI"];
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoaiMonAN_Gui_Load(object sender, EventArgs e)
        {
            Load_DataG_LoaiMonAn();
            databingding(dt.Tables["LOAI"]);
            
        }
        void databingding(DataTable r)
        {
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();

            //textBox1.DataBindings.Add();
            textBox2.DataBindings.Add("Text", r, "MAL");
            textBox3.DataBindings.Add("Text", r, "TENL");

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        void load_DataG_Search(string name)
        {
            dataGridView1.DataSource = LoaiMonAn_MeThod.Ins.Search(name);
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            load_DataG_Search(textBox1.Text);
        }
    }
}
