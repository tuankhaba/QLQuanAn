using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TuanKha.Methods;
using DevExpress.XtraEditors.Filtering.Templates;

namespace TuanKha.UI
{
    public partial class NhanVien_Gui : UserControl
    {
        DataSet dt=new DataSet();
        public NhanVien_Gui()
        {
            InitializeComponent();
            load_DTG_NhanVien();
            databingding(dt.Tables["NHANVIEN"]);
        }
       void load_DTG_NhanVien()
        {
            dt.Tables.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select*from NHANVIEN",XuLy_CauTruyVan.Instance.s);
            da.Fill(dt,"NHANVIEN");
            dataGridView1.DataSource= dt.Tables["NHANVIEN"];
        }
        void load_DTG_NhanVien_Search(string name)
        {
            dt.Tables.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select*from NHANVIEN where HOT like N'%"+name+"%'", XuLy_CauTruyVan.Instance.s);
            da.Fill(dt, "NHANVIEN");
            dataGridView1.DataSource = dt.Tables["NHANVIEN"];
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        void databingding(DataTable r)
        {
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox1.DataBindings.Clear();
            maskedTextBox1.DataBindings.Clear();

            //textBox1.DataBindings.Add();
            textBox2.DataBindings.Add("Text", r, "MANV");
            textBox3.DataBindings.Add("Text", r, "HOT");
            textBox1.DataBindings.Add("Text", r, "GIOIT");
            textBox4.DataBindings.Add("Text", r, "SDT");
            maskedTextBox1.DataBindings.Add("Text",r,"NGAYS");
            

        }
        private void NhanVien_Gui_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            load_DTG_NhanVien();
            databingding(dt.Tables["NHANVIEN"]);
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            load_DTG_NhanVien_Search(textBox5.Text);
            databingding(dt.Tables["NHANVIEN"]);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                maskedTextBox1.Text =
                DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString())
                .ToString("MM/dd/yyyy");

            }
            catch
            {
                maskedTextBox1.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TenLoai = textBox3.Text;
                
                
                if (NhanVien_Method.Ins.ThemNhanVien(int.Parse(textBox2.Text),textBox3.Text,DateTime.Parse(maskedTextBox1.Text),textBox1.Text,textBox4.Text,int.Parse(textBox6.Text)))
                {
                    MessageBox.Show("Thêm Nhân Viên  Thành Công");
                    load_DTG_NhanVien();
                    databingding(dt.Tables["NHANVIEN"]);
                }
                else
                {
                    MessageBox.Show("Đã có NHân Viên tồn tại");
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
                if (NhanVien_Method.Ins.XoaNhanVien(MaLoai))
                {
                    MessageBox.Show("Xóa Nhân Viên Thành Công");
                    load_DTG_NhanVien();
                    databingding(dt.Tables["NHANVIEN"]);
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
                string tam = string.Format("{0:dd/MM/yyyy}", maskedTextBox1.Text);

                if (NhanVien_Method.Ins.SuaNhanVien(int.Parse(textBox2.Text), textBox3.Text,textBox1.Text, textBox4.Text, int.Parse(textBox6.Text)))
                {
                    MessageBox.Show("Sửa Nhân Viên Thành Công");
                    load_DTG_NhanVien();
                    databingding(dt.Tables["NHANVIEN"]);
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
