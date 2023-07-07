using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuanKha.Models;
using TuanKha.Methods;
//using  System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TuanKha.UI
{
    public partial class CapNhat_UI : UserControl
    {
        public CapNhat_UI(Account_Model acc)
        {
            InitializeComponent();
            this.Show();
            this.longin=acc;
        }
        public int MaNV;
        private Account_Model longin;

        public Account_Model Longin
        {
            get { return longin; }
            set { longin = value; ThayDoi_ThongTin(longin); }
        }
        private void CapNhat_UI_Load(object sender, EventArgs e)
        {
            textBox1.Text=MaNV.ToString();
            textBox1.ReadOnly=true;
            
        }
        void UpDate_ThongTin()
        {
            int Manv = int.Parse(textBox1.Text);
            string DisPlayname = textBox2.Text;
            string Pass = textBox3.Text;
            string NewPass = textBox4.Text;
            string R_NewPass = textBox5.Text;
            if (!NewPass.Equals(R_NewPass))
            {
                MessageBox.Show("Vui lòng kiểm tra lại mật khẩu mới");
            }
            else
            {
                if (Account_MeThod.Ins.UpDate_TaiKhoan(Manv, DisPlayname, Pass, NewPass))
                {
                    MessageBox.Show("Cập Nhật Thành Công");
                    if (capnhat != null)
                    {
                        capnhat(this, new AccountEvent(Account_MeThod.Ins.GetAccountByManv(Manv)));
                    }
                }
                else
                {
                    MessageBox.Show("Cập Nhật Không Thành Công \nVui Lòng Kiểm Tra Lại Mật Khẩu");
                }
            }
        }
        void ThayDoi_ThongTin(Account_Model acc)
        {
            textBox1.Text = Longin.Manv.ToString();
            textBox2.Text = Longin.Displayname;
        }
        private event EventHandler<AccountEvent> capnhat;
        public event EventHandler<AccountEvent> Capnhat
        {
            add
            {
                capnhat += value;
            }
            remove
            {
                capnhat -= value;
            }
        }
        public class AccountEvent : EventArgs
        {
            private Account_Model acc;

            public Account_Model Acc
            {
                get { return acc; }
                set { acc = value; }
            }
            public AccountEvent(Account_Model acc)
            {
                this.Acc = acc;
            }

            public AccountEvent()
            {
                // TODO: Complete member initialization
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpDate_ThongTin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Focus();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
