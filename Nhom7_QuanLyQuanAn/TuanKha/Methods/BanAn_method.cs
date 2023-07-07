using DevExpress.Utils.DPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuanKha.Models;
namespace TuanKha.Methods
{
    internal class BanAn_method
    {
        private static BanAn_method ins;

        public static BanAn_method Ins
        {
            get { if (ins == null) ins = new BanAn_method(); return BanAn_method.ins; }
            private set { BanAn_method.ins = value; }
        }
        private BanAn_method() { }
        public List<BanAn_Model> load_tab_List()
        {
            List<BanAn_Model> lis = new List<BanAn_Model>();
            DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery("exec gettable");
            foreach (DataRow i in dt.Rows)
            {
                BanAn_Model t = new BanAn_Model(i);
                lis.Add(t);
            }
            return lis;
        }
        public List<BanAn_Model> load_tab_List_Search(string name)
        {
            List<BanAn_Model> lis = new List<BanAn_Model>();
            DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from BANAN where TENB like N'%"+name+"%'");
            foreach (DataRow i in dt.Rows)
            {
                BanAn_Model t = new BanAn_Model(i);
                lis.Add(t);
            }
            return lis;
        }
        public void swap_ban(int ma1, int ma2, int ma3)
        {
            XuLy_CauTruyVan.Instance.ExcuteQuery("swap @maba1 , @maba2 , @manv ", new object[] { ma1, ma2, ma3 });
        }

        public bool ThemBanAN(string TenLoai)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("insert into BANAN values(N'" + TenLoai + "',0)");
            return result > 0;
        }
        public bool XoaBanAN(int MaLoai)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("delete from BANAN where MABA=" + MaLoai + "");
            return result > 0;
        }
        public bool SuaBanAN(string TenLoai, int MaLoai)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("update BANAN set TENB=N'" + TenLoai + "' where MABA=" + MaLoai + "");
            return result > 0;
        }
    }
}
