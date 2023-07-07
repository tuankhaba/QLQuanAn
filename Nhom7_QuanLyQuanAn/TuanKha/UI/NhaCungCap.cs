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
using System.Windows.Forms.DataVisualization.Charting;

namespace TuanKha.UI
{
    public partial class NhaCungCap : UserControl
    {
        DataSet ds = new DataSet();

        public NhaCungCap()
        {
            InitializeComponent();
            LoadCBX();
            comboBox2.SelectedIndex = -1;
        }
        public void LoadCBX()
        {
            ds.Clear();
            string strsel = "select * from PHIEUDAT where MAPD not in (select MAPD from PHIEUGIAO)";
            SqlDataAdapter da_Khoa = new SqlDataAdapter(strsel, XuLy_CauTruyVan.Instance.s);

            da_Khoa.Fill(ds, "PHIEUDAT");
            comboBox1.DataSource = ds.Tables["PHIEUDAT"];
            comboBox1.DisplayMember = "MAPD";
            comboBox1.ValueMember = "MAPD";

        }
        void LoadDuLieuDataG(int MaPD)
        {
            string strsel = "select t.MATP, TENTP, d.SOL from CHITIETPHIEUDAT d, THUCPHAM t where d.MATP = t.MATP and MAPD = " + MaPD;
            SqlDataAdapter da_Khoa = new SqlDataAdapter(strsel, XuLy_CauTruyVan.Instance.s);
            DataSet dsa = new DataSet();
            dataGridView1.DataBindings.Clear();
            comboBox2.DataBindings.Clear();
            da_Khoa.Fill(dsa, "CHITIETPHIEUDAT");
            if (dataGridView1.Controls != null)
                dataGridView1.Controls.Clear();
            dataGridView1.DataSource = dsa.Tables["CHITIETPHIEUDAT"];
            comboBox2.SelectedText = "";
            comboBox2.DataSource = dsa.Tables["CHITIETPHIEUDAT"];
            comboBox2.DisplayMember = "TENTP";
            comboBox2.ValueMember = "MATP";
        }
        public void databingding(DataTable r)
        {
            comboBox1.DataBindings.Add("Text", r, "TENTP");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox2.SelectedIndex==-1)
                {
                    MessageBox.Show("Chưa Chọn Thực Phẩm Để Giao");
                    return;
                }    
                string str = "select SOL from CHITIETPHIEUDAT where MAPD = " + int.Parse(comboBox1.SelectedValue.ToString()) + " and MATP = " + int.Parse(comboBox2.SelectedValue.ToString());
                int sl = (int)XuLy_CauTruyVan.Instance.Excute_Scalar(str);
                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                foreach (ListViewItem i in listView1.Items)
                    if (i.Text.Equals(comboBox2.SelectedValue.ToString()))
                    {
                        int slthem = (int.Parse(i.SubItems[2].Text) + int.Parse(numericUpDown1.Text));
                        i.SubItems[1].Text = comboBox2.Text.ToString();
                        i.SubItems[2].Text = slthem > sl ? sl.ToString() : slthem.ToString();
                        return;
                    }
                int slmoi = int.Parse(numericUpDown1.Text);
                slmoi = slmoi > sl ? sl : slmoi;
                //textBox1.Text = (XuLy_CauTruyVan.Instance.Excute_Scalar("select TENTP from THUCPHAM where MATP=" + comboBox2.SelectedValue.ToString() + "")).ToString();
                ListViewItem item1 = new ListViewItem(new[] { comboBox2.SelectedValue.ToString(), comboBox2.SelectedText, slmoi.ToString() });
                listView1.Items.Add(item1);
            }
            catch { }
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
                MessageBox.Show("Bạn chưa chọn thực phẩm để xóa!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XuLy_CauTruyVan.Instance.ExcuteQuery("exec TaoPhieuGiaoHang @MaPD ", new object[] { (int)comboBox1.SelectedValue });
            int Mapg = (int)XuLy_CauTruyVan.Instance.Excute_Scalar("select MAX(MAPG) from PHIEUGIAO");
            int sc = dataGridView1.Rows.Count;
            int sl = 0;

            for (int i = 0; i < sc - 1; i++)
            {
                sl += int.Parse(dataGridView1.Rows[i].Cells["SOL"].Value.ToString());
            }
            int sl2 = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sl2 += int.Parse(listView1.Items[i].SubItems[2].Text);
            }
            if (sl == sl2)
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    XuLy_CauTruyVan.Instance.ExcuteQuery("insert into CHITIETPHIEUGIAO values(" + Mapg + "," + i.Text + "," + int.Parse(i.SubItems[2].Text) + ")");
                }
                MessageBox.Show("Giao hàng thành công!");
                LoadCBX();
                dataGridView1.DataSource = null;
                listView1.Items.Clear();

            }
            else
            {
                MessageBox.Show("Số Lượng Chưa Đủ Không Thể Giao");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDuLieuDataG(int.Parse(comboBox1.SelectedValue.ToString()));
                listView1.Items.Clear();
            }
            catch { }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
