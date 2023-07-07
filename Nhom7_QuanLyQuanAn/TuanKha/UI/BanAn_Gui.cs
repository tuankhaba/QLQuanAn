using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuanKha.Methods;
using TuanKha.Models;
using System.Data.SqlClient;
using System.Globalization;
namespace TuanKha.UI
{
    public partial class BanAn_Gui : UserControl
    {
        public int MaNhanVien;
        DataSet dt = new DataSet();
        public BanAn_Gui()
        {
            InitializeComponent();



        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        void load_List_BanAn()
        {
            flowLayoutPanel1.Controls.Clear();
            List<BanAn_Model> lis = BanAn_method.Ins.load_tab_List();
            foreach (BanAn_Model i in lis)
            {
                Button btn = new Button() { Width = 100, Height = 100 };
                btn.Click += Btn_Click; ;
                btn.Tag = i;
                string s = "Có Người";
                btn.BackgroundImage = global::TuanKha.Properties.Resources._060207072c1ef440ad0f;
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.BackColor = Color.Gray;
                if (i.Tt == 0)
                {
                    btn.BackgroundImage = global::TuanKha.Properties.Resources.cc2273095810804ed901;
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.BackColor = Color.Green;
                    s = "Trống";
                }
                btn.Text = i.Name + Environment.NewLine + s;
                flowLayoutPanel1.Controls.Add(btn);


            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int idban = ((sender as Button).Tag as BanAn_Model).Id;
            listView1.Tag = (sender as Button).Tag;
            HienThi_HD_TheoBan(idban);
        }
        void HienThi_HD_TheoBan(int id)
        {
            listView1.Items.Clear();
            List<HoaDon_TheoBan> lst = HoaDon_TheoBan_Method.Ins.layds(id);
            float tongtt = 0;
            foreach (HoaDon_TheoBan i in lst)
            {
                ListViewItem item = new ListViewItem(i.Name.ToString());
                item.SubItems.Add(i.Sl.ToString());
                item.SubItems.Add(i.G.ToString());
                item.SubItems.Add(i.Thanhtien.ToString());
                listView1.Items.Add(item);
                tongtt += i.Thanhtien;
            }
            textBox2.Text = tongtt.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BanAn_Model t = listView1.Tag as BanAn_Model;
                int ma = MaNhanVien;
                int mama = (int)comboBox2.SelectedValue;
                int mahd = HoaDon_Method.Ins.layhoadontheo_ID(t.Id);
                int sl = (int)numericUpDown1.Value;
                if (mahd == -1)
                {
                    KhachHang_MeThod.Ins.themkhachang();
                    HoaDon_Method.Ins.themhoadon(t.Id, ma, KhachHang_MeThod.Ins.lay_ID_max());
                    ChiTiet_HD_MeThod.Ins.themchitiethoadon(mama, HoaDon_Method.Ins.lay_ID_max(), sl);
                }
                else
                {
                    ChiTiet_HD_MeThod.Ins.themchitiethoadon(mama, mahd, sl);
                }
                //hienthihoadon(t.Id);
                HienThi_HD_TheoBan(t.Id);
                load_List_BanAn();
                MessageBox.Show("Gọi Món Thành Công");
            }
            catch
            {
                MessageBox.Show("Không đủ nguyên liệu để gọi món");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BanAn_Model t = listView1.Tag as BanAn_Model;
                int mahd_curent = HoaDon_Method.Ins.layhoadontheo_ID(t.Id);
                int gg = int.Parse(textBox1.Text);
                int makh = HoaDon_Method.Ins.layhoadontheo_MaKH(t.Id);
                double tongtien = Convert.ToDouble(textBox2.Text.Split(',')[0]);
                double tongtientra = tongtien - (tongtien / 100) * gg;
                if (mahd_curent != -1)
                {
                    if (MessageBox.Show(string.Format("Bạn có Chắc Thanh Toán {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá  \n {1} - {1} x ({2} / 100)= {3}", t.Name, tongtien, gg, tongtientra), "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        string ej = "select MONAN.TENMA,ct.SOL,MONAN.GIA,ct.SOL*MONAN.GIA as 'THANHTIEN' from CHITIETMONAN ct,HOADON hd,MONAN where ct.MAHD=hd.MAHD and ct.MAMA=MONAN.MAMA and hd.TRANGTHAI=0 and hd.MABA=" + t.Id;
                        DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery(ej);
                        TuanKha rp = new TuanKha();
                        rp.SetDataSource(dt);
                        IN f = new IN();
                        f.Size = new Size(1000, 1000);
                        CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                        crystalReportViewer.ReportSource = rp;
                        crystalReportViewer.Size = new Size(1000, 1000);
                        crystalReportViewer.Location = new Point(0, 0);
                        crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                        f.Controls.Add(crystalReportViewer);
                        f.Show();
                        HoaDon_Method.Ins.thanhtoabn(t.Id, (float)tongtientra, gg, makh);
                        MessageBox.Show("Thanh toán thành công!");
                        load_List_BanAn();
                        HienThi_HD_TheoBan(t.Id);

                    }
                }

            }
            catch
            {
                MessageBox.Show("chưa chọn bàn để thanh toán");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox a = sender as ComboBox;
            if (a.SelectedItem == null)
            {
                return;
            }
            LoaiMonAn_Model b = a.SelectedItem as LoaiMonAn_Model;
            id = b.Mal;
            Load_CB_Theo_MaLoai(id);
        }
        void Load_CB_Theo_MaLoai(int id)
        {
            DataTable data = new DataTable();
            data = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from MONAN where MAL=" + id);
            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "TENMA";
            comboBox2.ValueMember = "MAMA";
        }
        void loadds_loaima()
        {
            List<LoaiMonAn_Model> b = LoaiMonAn_MeThod.Ins.loadds_loaima();
            comboBox1.DataSource = b;
            comboBox1.DisplayMember = "TENL";
        }
        private void BanAn_Gui_Load(object sender, EventArgs e)
        {
            load_List_BanAn();
            loadds_loaima();
            numericUpDown1.Value = 1;
            Load_CB_Ban_Chuyen();
            textBox1.ReadOnly = true;
            int tam = 0;
            textBox1.Text = tam.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int ma1 = (listView1.Tag as BanAn_Model).Id;
                int ma2 = (int)comboBox3.SelectedValue;

                if (MessageBox.Show(string.Format("Bạn có Chắc chuyển  {0} qua bàn {1}", (listView1.Tag as BanAn_Model).Name, ma2), "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BanAn_method.Ins.swap_ban(ma1, ma2, MaNhanVien);
                    load_List_BanAn();
                }
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn bàn để chuyển");
            }
        }
        void Load_CB_Ban_Chuyen()
        {
            DataTable data = new DataTable();
            data = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from BANAN");
            comboBox3.DataSource = data;
            comboBox3.DisplayMember = "TENB";
            comboBox3.ValueMember = "MABA";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
