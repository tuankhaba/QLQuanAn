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
    public partial class ThongTin : UserControl
    {
        public int Manv;
        private Account_Model longin;

        public Account_Model Longin
        {
            get { return longin; }
            set { longin = value;}
        }
        public ThongTin(Account_Model acc)
        {
            InitializeComponent();
            this.Longin = acc;
            
        }
        void Load_ThonTin_NV(int id )
        {
            DataTable data = new DataTable();
            data = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from NHANVIEN where MANV="+id+"");
            if(data.Rows.Count > 0 )
            {
                foreach(DataRow i in data.Rows)
                {
                    NhanVien_Model nv = new NhanVien_Model(i);
                    textBox1.Text = nv.Ma.ToString();
                    textBox2.Text=nv.Ten.ToString();
                    textBox3.Text=nv.Gioitinh.ToString();
                    textBox4.Text=nv.Sdt.ToString();
                    maskedTextBox1.Text = string.Format("{0:dd/MM/yyyy}", nv.Ngays);
                }
            }
        }
        private void ThongTin_Load(object sender, EventArgs e)
        {
            Load_ThonTin_NV(Manv);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
