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

namespace TuanKha.UI
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        bool dangnhap(int usn, string pass)
        {
            return Account_MeThod.Ins.login(usn, pass);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dangnhap(int.Parse(textBox1.Text), textBox2.Text) == true)
            {
                
                Account_Model loginacc = Account_MeThod.Ins.GetAccountByManv(int.Parse(textBox1.Text));
                Form1 f = new Form1(loginacc);
                f.Manv = int.Parse(textBox1.Text);

                this.Hide();
                f.ShowDialog();
                this.Show();
                

            }
            else
                MessageBox.Show("Vui Lòng Kiểm Tra Lại Tài Khoản Hoặc Mật Khẩu");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát chương trình", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
