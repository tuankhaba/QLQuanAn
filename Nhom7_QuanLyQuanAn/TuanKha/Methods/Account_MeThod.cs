using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TuanKha.Models;
namespace TuanKha.Methods
{
    public class Account_MeThod
    {
        private static Account_MeThod ins;

        public static Account_MeThod Ins
        {
            get { if (ins == null) ins = new Account_MeThod(); return ins; }
            set { ins = value; }
        }
        private Account_MeThod() { }
        public bool login(int user, string pass)
        {
            byte[] temp=ASCIIEncoding.ASCII.GetBytes(pass); 
            byte[] hastable= new MD5CryptoServiceProvider().ComputeHash(temp);
            //var listd = hastable.ToString();
            //listd.Reverse();
            string has = "";
            foreach(byte item in hastable)
            {
                has += item;
            }    
            string sql = "longin @user , @pass ";
            DataTable result = XuLy_CauTruyVan.Instance.ExcuteQuery(sql, new object[] { user, pass });
            return result.Rows.Count > 0;
        }
        public Account_Model GetAccountByManv(int manv)
        {
            DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from account where MANV=" + manv + "");
            foreach (DataRow r in dt.Rows)
            {
                Account_Model a = new Account_Model(r);
                return a;
            }
            return null;

        }
        public bool UpDate_TaiKhoan(int Manv, string Displayname, string Pass, string newPass)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("exec UpDate_ThongTin_Account @manv , @displayname , @pass , @newpass ", new object[] { Manv, Displayname, Pass, newPass });
            return result > 0;
        }



        public bool ThemTaiKhoan(int Manv,string TenTK,string Mk,int ChucVu)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("insert into account values("+Manv+",N'" + TenTK + "','"+Mk+"',"+ChucVu+")");
            return result > 0;
        }
        public bool XoaTaiKhoan(int MaNhanVien)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("delete from account where MANV=" + MaNhanVien + "");
            return result > 0;
        }
        public bool SuaTaiKhoan(int Manv,string TenLoai, string MK,int ChucVu)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("update account set displayname=N'" + TenLoai + "',pass='"+MK+"',chucv="+ChucVu+" where MANV=" + Manv + "");
            return result > 0;
        }
        public int Kt_ThongTinNhanVien(int Manv)
        {
            int result = (int)XuLy_CauTruyVan.Instance.Excute_Scalar("PRINT DBO.KiemTra_ThongTin_NV_CoTonTai("+Manv+")");
            return result;
        }
    }
}
