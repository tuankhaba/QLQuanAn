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
    public partial class DoanhThu_Gui : UserControl
    {
        public DoanhThu_Gui()
        {
            InitializeComponent();
        }



        private void DoanhThu_Gui_Load(object sender, EventArgs e)
        {
            load_combox();
            load_ThongKeMatDinh();
            load_doanhthu(dateTimePicker1.Value, dateTimePicker2.Value);
            comboBox1.SelectedIndex = -1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        void load_ThongKeMatDinh()
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1).AddDays(-1);
        }
        void load_doanhthu(DateTime checkin, DateTime checkout)
        {
            dataGridView1.Controls.Clear();
            dataGridView1.DataSource = HoaDon_Method.Ins.get_view_Doanhthu(checkin, checkout);
            int sc = dataGridView1.Rows.Count;
            double thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
            {
                thanhtien += double.Parse(dataGridView1.Rows[i].Cells["Tổng Tiền"].Value.ToString());
            }
            textBox1.Text = thanhtien.ToString();
        }
        void load_combox()
        {
            comboBox1.DataSource = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from account");
            comboBox1.DisplayMember = "MANV";
            comboBox1.ValueMember = "MANV";
        }
        void load_doanhthu_NV(int manv)
        {
            dataGridView1.Controls.Clear();
            dataGridView1.DataSource = HoaDon_Method.Ins.get_view_Doanhthu_NV(manv);
            int sc = dataGridView1.Rows.Count;
            double thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
            {
                thanhtien += double.Parse(dataGridView1.Rows[i].Cells["Tổng Tiền"].Value.ToString());
            }
            textBox1.Text = thanhtien.ToString();
        }
        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_doanhthu(dateTimePicker1.Value, dateTimePicker2.Value);
            if (comboBox1.SelectedIndex != -1)
            {
                load_doanhthu_NV((int)comboBox1.SelectedValue);
                comboBox1.SelectedIndex = -1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
