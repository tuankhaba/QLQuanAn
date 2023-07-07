namespace TuanKha
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.form_trangchu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.trangchu_nghiepvu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.trangchu_taikhoan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.taikhoan_thongtin = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.taikhoan_capnhat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.form_admin = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.admin_Thongke = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.admin_danhmuc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.admin_thucan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.admin_banan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.admin_ql_taikhoan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.admin_ql_nhanvien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Appearance.BackColor = System.Drawing.Color.White;
            this.fluentDesignFormContainer1.Appearance.Options.UseBackColor = true;
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(224, 31);
            this.fluentDesignFormContainer1.Margin = new System.Windows.Forms.Padding(21, 20, 21, 20);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(948, 493);
            this.fluentDesignFormContainer1.TabIndex = 0;
            this.fluentDesignFormContainer1.Click += new System.EventHandler(this.fluentDesignFormContainer1_Click);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.Cyan;
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.form_trangchu,
            this.form_admin});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(21, 20, 21, 20);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(224, 493);
            this.accordionControl1.TabIndex = 1;
            // 
            // form_trangchu
            // 
            this.form_trangchu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.trangchu_nghiepvu,
            this.trangchu_taikhoan});
            this.form_trangchu.Expanded = true;
            this.form_trangchu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("form_trangchu.ImageOptions.Image")));
            this.form_trangchu.Name = "form_trangchu";
            this.form_trangchu.Text = "Trang Chu";
            this.form_trangchu.Click += new System.EventHandler(this.form_trangchu_Click);
            // 
            // trangchu_nghiepvu
            // 
            this.trangchu_nghiepvu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("trangchu_nghiepvu.ImageOptions.Image")));
            this.trangchu_nghiepvu.Name = "trangchu_nghiepvu";
            this.trangchu_nghiepvu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.trangchu_nghiepvu.Text = "Nghiệp Vụ";
            this.trangchu_nghiepvu.Click += new System.EventHandler(this.trangchu_nghiepvu_Click);
            // 
            // trangchu_taikhoan
            // 
            this.trangchu_taikhoan.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.taikhoan_thongtin,
            this.taikhoan_capnhat,
            this.accordionControlElement4});
            this.trangchu_taikhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("trangchu_taikhoan.ImageOptions.Image")));
            this.trangchu_taikhoan.Name = "trangchu_taikhoan";
            this.trangchu_taikhoan.Text = "Tài Khoản";
            this.trangchu_taikhoan.Click += new System.EventHandler(this.trangchu_taikhoan_Click);
            // 
            // taikhoan_thongtin
            // 
            this.taikhoan_thongtin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("taikhoan_thongtin.ImageOptions.Image")));
            this.taikhoan_thongtin.Name = "taikhoan_thongtin";
            this.taikhoan_thongtin.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.taikhoan_thongtin.Text = "Thông Tin ";
            this.taikhoan_thongtin.Click += new System.EventHandler(this.taikhoan_thongtin_Click);
            // 
            // taikhoan_capnhat
            // 
            this.taikhoan_capnhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("taikhoan_capnhat.ImageOptions.Image")));
            this.taikhoan_capnhat.Name = "taikhoan_capnhat";
            this.taikhoan_capnhat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.taikhoan_capnhat.Text = "Cập Nhật";
            this.taikhoan_capnhat.Click += new System.EventHandler(this.taikhoan_capnhat_Click);
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement4.ImageOptions.Image")));
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement4.Text = "Đăng xuất";
            this.accordionControlElement4.Click += new System.EventHandler(this.accordionControlElement4_Click);
            // 
            // form_admin
            // 
            this.form_admin.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.admin_Thongke,
            this.admin_danhmuc,
            this.admin_thucan,
            this.admin_banan,
            this.admin_ql_taikhoan,
            this.admin_ql_nhanvien,
            this.accordionControlElement1,
            this.accordionControlElement2,
            this.accordionControlElement3});
            this.form_admin.Expanded = true;
            this.form_admin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("form_admin.ImageOptions.Image")));
            this.form_admin.Name = "form_admin";
            this.form_admin.Text = "Admin";
            this.form_admin.Click += new System.EventHandler(this.form_admin_Click);
            // 
            // admin_Thongke
            // 
            this.admin_Thongke.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("admin_Thongke.ImageOptions.Image")));
            this.admin_Thongke.Name = "admin_Thongke";
            this.admin_Thongke.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.admin_Thongke.Text = "Thống Kê";
            this.admin_Thongke.Click += new System.EventHandler(this.admin_Thongke_Click);
            // 
            // admin_danhmuc
            // 
            this.admin_danhmuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("admin_danhmuc.ImageOptions.Image")));
            this.admin_danhmuc.Name = "admin_danhmuc";
            this.admin_danhmuc.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.admin_danhmuc.Text = "Danh Mục";
            this.admin_danhmuc.Click += new System.EventHandler(this.admin_danhmuc_Click);
            // 
            // admin_thucan
            // 
            this.admin_thucan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("admin_thucan.ImageOptions.SvgImage")));
            this.admin_thucan.Name = "admin_thucan";
            this.admin_thucan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.admin_thucan.Text = "Thức Ăn";
            this.admin_thucan.Click += new System.EventHandler(this.admin_thucan_Click);
            // 
            // admin_banan
            // 
            this.admin_banan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("admin_banan.ImageOptions.Image")));
            this.admin_banan.Name = "admin_banan";
            this.admin_banan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.admin_banan.Text = "Bàn Ăn";
            this.admin_banan.Click += new System.EventHandler(this.admin_banan_Click);
            // 
            // admin_ql_taikhoan
            // 
            this.admin_ql_taikhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("admin_ql_taikhoan.ImageOptions.Image")));
            this.admin_ql_taikhoan.Name = "admin_ql_taikhoan";
            this.admin_ql_taikhoan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.admin_ql_taikhoan.Text = "Quản Lý Tài Khoản";
            this.admin_ql_taikhoan.Click += new System.EventHandler(this.admin_ql_taikhoan_Click);
            // 
            // admin_ql_nhanvien
            // 
            this.admin_ql_nhanvien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("admin_ql_nhanvien.ImageOptions.Image")));
            this.admin_ql_nhanvien.Name = "admin_ql_nhanvien";
            this.admin_ql_nhanvien.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.admin_ql_nhanvien.Text = "Quản Lý Nhân Viên";
            this.admin_ql_nhanvien.Click += new System.EventHandler(this.admin_ql_nhanvien_Click);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Text = "Xem Kho Thực Phẩm";
            this.accordionControlElement1.Click += new System.EventHandler(this.accordionControlElement1_Click);
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement2.ImageOptions.Image")));
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Nhập Hàng";
            this.accordionControlElement2.Click += new System.EventHandler(this.accordionControlElement2_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement3.ImageOptions.Image")));
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Text = "Nhà cung cấp";
            this.accordionControlElement3.Click += new System.EventHandler(this.accordionControlElement3_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barButtonItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1172, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 2;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barButtonItem1});
            this.fluentFormDefaultManager1.MaxItemId = 4;
            // 
            // Form1
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 524);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1367, 637);
            this.MinimumSize = new System.Drawing.Size(1367, 637);
            this.Name = "Form1";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement form_trangchu;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement trangchu_nghiepvu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement trangchu_taikhoan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement taikhoan_thongtin;
        private DevExpress.XtraBars.Navigation.AccordionControlElement taikhoan_capnhat;
        private DevExpress.XtraBars.Navigation.AccordionControlElement form_admin;
        private DevExpress.XtraBars.Navigation.AccordionControlElement admin_Thongke;
        private DevExpress.XtraBars.Navigation.AccordionControlElement admin_danhmuc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement admin_thucan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement admin_banan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement admin_ql_taikhoan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement admin_ql_nhanvien;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
    }
}

