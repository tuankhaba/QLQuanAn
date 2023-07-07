using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuanKha.Methods;
namespace TuanKha.UI
{
    public partial class NhapHang_Gui : UserControl
    {
        public NhapHang_Gui()
        {
            InitializeComponent();
            Load_NhaCC();
        }
        void Load_NhaCC()
        {
            DataTable data = new DataTable();
            data = XuLy_CauTruyVan.Instance.ExcuteQuery("select * from NHACUNGCAP");
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "TENNCC";
            comboBox1.ValueMember = "MANCC";
            comboBox1.SelectedIndex = 1;
        }
        void Load_NguonThucPhamTheoNhaCC(int id)
        {
            DataTable data = new DataTable();
            data = XuLy_CauTruyVan.Instance.ExcuteQuery("select TENTP,NGUONCUNG.MATP from NGUONCUNG,THUCPHAM where THUCPHAM.MATP=NGUONCUNG.MATP and NGUONCUNG.MANCC=" + id);
            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "TENTP";
            comboBox2.ValueMember = "MATP";

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Load_NguonThucPhamTheoNhaCC((int)comboBox1.SelectedValue);
                listView1.Items.Clear();
            }
            catch
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
            foreach (ListViewItem i in listView1.Items)
                if (i.Text.Equals(comboBox2.SelectedValue.ToString()))
                {
                    i.SubItems[2].Text = (int.Parse(i.SubItems[2].Text) + int.Parse(numericUpDown1.Text)).ToString();
                    return;
                }
            textBox1.Text = (XuLy_CauTruyVan.Instance.Excute_Scalar("select TENTP from THUCPHAM where MATP=" + comboBox2.SelectedValue.ToString() + "")).ToString();
            ListViewItem item1 = new ListViewItem(new[] { comboBox2.SelectedValue.ToString(), textBox1.Text, numericUpDown1.Text });
            listView1.Items.Add(item1);
            //item.Text = comboBox2.SelectedValue.ToString();
            //subitem.Text = numericUpDown1.Text;
            //item.SubItems.Add(subitem);
            //listView1.Items.Add(item);
        }

        private void NhapHang_Gui_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem l in listView1.SelectedItems)
                    l.Remove();
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để xóa!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XuLy_CauTruyVan.Instance.ExcuteQuery("exec TaoPhieuDatHang @MaNCC ", new object[] { (int)comboBox1.SelectedValue });
            int Mapd = (int)XuLy_CauTruyVan.Instance.Excute_Scalar("select MAX(MAPD) from PHIEUDAT");
            foreach (ListViewItem i in listView1.Items)
            {
                XuLy_CauTruyVan.Instance.ExcuteQuery("insert into CHITIETPHIEUDAT values(" + Mapd + "," + i.Text + "," + int.Parse(i.SubItems[2].Text) + ")");
            }
            MessageBox.Show("Đặt Hàng Thành Công");
            listView1.Items.Clear();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
