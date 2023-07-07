using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TuanKha.UI;
using TuanKha.Models;
using TuanKha.Methods;
//using  System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TuanKha
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public  int Manv;
        public Form1(Account_Model acc)
        {
            InitializeComponent();
            //form_admin.Visible = false;
            //form_admin.Elements.Clear();

            this.Longin = acc;
            if (longin.Chucvu == 0)
            {
                form_admin.Visible = false;
            }
            else
            {
                form_admin.Visible = true;
            }
            


        }
        BanAn_Gui Ban;

        private void form_trangchu_Click(object sender, EventArgs e)
        {

        }

        private void trangchu_nghiepvu_Click(object sender, EventArgs e)
        {
            if(Ban==null)
            {
                Ban=new BanAn_Gui();
                Ban.MaNhanVien = Manv;
                Ban.Dock= DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(Ban);
                Ban.BringToFront();


            }
            else
            {
                Ban.BringToFront();
            }
        }

        private void trangchu_taikhoan_Click(object sender, EventArgs e)
        {

        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void form_admin_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Account_Model longin;

        public Account_Model Longin
        {
            get { return longin; }
            set { longin = value; KT_Loai_Tk(); }
        }
        void KT_Loai_Tk()
        {

            taikhoan_thongtin.Text += "(" + longin.Displayname + ")";
        }
        ThongTin thontin;
        private void taikhoan_thongtin_Click(object sender, EventArgs e)
        {
            Account_Model loginacc = Account_MeThod.Ins.GetAccountByManv(Manv);
            if (thontin == null)
            {
                thontin = new ThongTin(loginacc);
                thontin.Manv = Manv;
                thontin.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(thontin);
                thontin.BringToFront();


            }
            else
            {
                thontin.BringToFront();
            }
        }
        CapNhat_UI capnhat;
        private void taikhoan_capnhat_Click(object sender, EventArgs e)
        {
            Account_Model loginacc = Account_MeThod.Ins.GetAccountByManv(Manv);
            //CapNhat_UI f = new CapNhat_UI(loginacc);
            //f.MaNV = Manv;
            if (capnhat == null)
            {
                capnhat = new CapNhat_UI(loginacc);
                capnhat.Capnhat += Capnhat_Capnhat;
                capnhat.MaNV=Manv;
                capnhat.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(capnhat);
                capnhat.BringToFront();


            }
            else
            {
                capnhat.BringToFront();
            }
        }

        private void Capnhat_Capnhat(object sender, CapNhat_UI.AccountEvent e)
        {
            taikhoan_thongtin.Text = "Thông Tin (" + e.Acc.Displayname + ")";
        }
        ThucAn_Gui thucan;
        private void admin_thucan_Click(object sender, EventArgs e)
        {
            if (thucan == null)
            {

               
                thucan= new ThucAn_Gui();
                thucan.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(thucan);
                thucan.BringToFront();


            }
            else
            {
                thucan.BringToFront();
            }

        }
        LoaiMonAN_Gui loaimonan;
        private void admin_danhmuc_Click(object sender, EventArgs e)
        {
            if (loaimonan == null)
            {


                loaimonan = new LoaiMonAN_Gui();
                loaimonan.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(loaimonan);
                loaimonan.BringToFront();


            }
            else
            {
                loaimonan.BringToFront();
            }
        }
        DoanhThu_Gui doanhthu;
        private void admin_Thongke_Click(object sender, EventArgs e)
        {
            if (doanhthu == null)
            {


                doanhthu = new DoanhThu_Gui();
                doanhthu.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(doanhthu);
                doanhthu.BringToFront();


            }
            else
            {
                doanhthu.BringToFront();
            }
        }
        EDIT_BanAN_Gui banan;
        private void admin_banan_Click(object sender, EventArgs e)
        {
            if (banan == null)
            {


                banan = new EDIT_BanAN_Gui();
                banan.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(banan);
                banan.BringToFront();


            }
            else
            {
                banan.BringToFront();
            }
        }
        TaiKhoan_Gui taikhoan;
        private void admin_ql_taikhoan_Click(object sender, EventArgs e)
        {
            if (taikhoan == null)
            {


                taikhoan = new TaiKhoan_Gui();
                taikhoan.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(taikhoan);
                taikhoan.BringToFront();


            }
            else
            {
                taikhoan.BringToFront();
            }
        }
        KhoThucPham_Gui kho;
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if (kho == null)
            {


                kho = new KhoThucPham_Gui();
                kho.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(kho);
                kho.BringToFront();


            }
            else
            {
                kho.BringToFront();
            }
        }
        NhapHang_Gui nhap;
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (nhap == null)
            {


                nhap = new NhapHang_Gui();
                nhap.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(nhap);
                nhap.BringToFront();


            }
            else
            {
                nhap.BringToFront();
            }
        }
        NhaCungCap fcc ;
        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            if (fcc == null)
            {


                fcc = new NhaCungCap();
                fcc.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(fcc);
                fcc.BringToFront();


            }
            else
            {
                fcc.BringToFront();
            }
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        NhanVien_Gui nv;
        private void admin_ql_nhanvien_Click(object sender, EventArgs e)
        {
            if (nv == null)
            {


                nv = new NhanVien_Gui();
                nv.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(nv);
                nv.BringToFront();


            }
            else
            {
                nv.BringToFront();
            }
        }
        //void KT_Loai_Tk(int chucVu)
        //{
        //    form_admin.Visible = chucVu !=1;

        //}
    }
}
