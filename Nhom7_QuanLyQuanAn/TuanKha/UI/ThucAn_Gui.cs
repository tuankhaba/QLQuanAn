using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuanKha.Models;
using TuanKha.Methods;
namespace TuanKha.UI
{
    public partial class ThucAn_Gui : UserControl
    {
        BindingSource ff = new BindingSource();
        public ThucAn_Gui()
        {
            InitializeComponent();
        
            
        }

        private void ThucAn_Gui_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ff;
            load_LoaiMonAn_Cbb(comboBox1);
            Load_DataG_MonAn();
            databingding();
        }
        void databingding()
        {
            textBox2.Clear();
            textBox3.Clear();
            numericUpDown1.ResetText();
            numericUpDown1.Maximum = 10000000000;
            numericUpDown1.Minimum = 0;
            //textBox1.DataBindings.Add();
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Ma"));
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Ten"));
            numericUpDown1.DataBindings.Add(new Binding("Value", dataGridView1.DataSource, "Gia"));

        }
        
        private void load_LoaiMonAn_Cbb(ComboBox cb)
        {
            cb.DataSource = LoaiMonAn_MeThod.Ins.loadds_loaima();
            cb.DisplayMember = "TENL";
            cb.ValueMember = "MAL";
        }

        private void Load_DataG_MonAn()
        {
            ff.DataSource = MonAn_MeThod.Ins.loadds_loaima();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = LoaiMonAn_MeThod.Ins.MaLoai_Theo_id_MonAn(int.Parse(textBox2.Text.ToString()));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Load_DataG_MonAn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TenMon = textBox3.Text;
                float Gia = (float)numericUpDown1.Value;
                int MaLoai = (int)comboBox1.SelectedValue;
                if (MonAn_MeThod.Ins.ThemMonAN(TenMon, Gia, MaLoai))
                {
                    MessageBox.Show("Thêm Món Thành Công");
                    Load_DataG_MonAn();
                }
                else
                {
                    MessageBox.Show("Đã có mã món ăn tồn tại");
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
                int MaMon = int.Parse(textBox2.Text);
                if (MonAn_MeThod.Ins.XoaMonAN(MaMon))
                {
                    MessageBox.Show("Xóa Món Thành Công");
                    Load_DataG_MonAn();
                }
                else
                {
                    MessageBox.Show("Đã có mã món ăn tồn tại");
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
                int MaMon = int.Parse(textBox2.Text);
                string TenMon = textBox3.Text;
                float Gia = (float)numericUpDown1.Value;
                int MaLoai = (int)comboBox1.SelectedValue;
                if (MonAn_MeThod.Ins.SuaMonAN(MaMon,TenMon, Gia, MaLoai))
                {
                    MessageBox.Show("Sửa Món Thành Công");
                    Load_DataG_MonAn();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        void load_DataG_Search(string name)
        {
            ff.DataSource = MonAn_MeThod.Ins.Search(name);
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            load_DataG_Search(textBox1.Text);
        }
    }
}
