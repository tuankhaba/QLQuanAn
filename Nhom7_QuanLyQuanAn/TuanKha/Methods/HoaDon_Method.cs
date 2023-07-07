using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuanKha.Models;
namespace TuanKha.Methods
{
    public class HoaDon_Method
    {
        private static HoaDon_Method ins;

        public static HoaDon_Method Ins
        {
            get { if (ins == null) ins = new HoaDon_Method(); return HoaDon_Method.ins; }
            private set { HoaDon_Method.ins = value; }
        }
        private HoaDon_Method() { }
        public void thanhtoabn(int id, float tongtt, int gg, int makh)
        {
            XuLy_CauTruyVan.Instance.ExcuteNonQuery("update HOADON set TRANGTHAI=1,GIOR=GETDATE(),GIAMGIA=" + gg + ",TONGTT=" + tongtt + " where MABA=" + id + " and MAKH=" + makh);
        }
        public int layhoadontheo_ID(int id)
        {
            DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from HOADON where TRANGTHAI=0 and MABA=" + id);
            if (dt.Rows.Count > 0)
            {
                HoaDon_Model hd = new HoaDon_Model(dt.Rows[0]);
                return hd.Id;
            }
            return -1;
        }
        public int layhoadontheo_MaKH(int id)
        {
            return (int)XuLy_CauTruyVan.Instance.Excute_Scalar("select MAX(MAKH) from HOADON where MABA=" + id);

        }
        public void themhoadon(int mb, int mnv, int mkh)
        {
            XuLy_CauTruyVan.Instance.ExcuteNonQuery("exec addhoadon @maban , @manv , @makh ", new object[] { mb, mnv, mkh });
        }
        public int lay_ID_max()
        {
            return (int)XuLy_CauTruyVan.Instance.Excute_Scalar("select MAX(HOADON.MAHD) from HOADON");
        }
        public DataTable get_view_Doanhthu(DateTime giov, DateTime gior)
        {
            return XuLy_CauTruyVan.Instance.ExcuteQuery("get_view_doanhthu @giov , @gior", new object[] { giov, gior });
        }

        public DataTable get_view_Doanhthu_NV(int manv)
        {
            return XuLy_CauTruyVan.Instance.ExcuteQuery("get_view_doanhthu_NhanVien @MaNV ", new object[] { manv });
        }
        //public List<HoaDon_Model> get_view_Doanhthu(DateTime giov, DateTime gior)
        //{
        //    List<HoaDon_Model> lis = new List<HoaDon_Model>();
        //    DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery("get_view_doanhthu @giov , @gior", new object[] { giov, gior });
        //    foreach (DataRow i in dt.Rows)
        //    {
        //        HoaDon_Model t = new HoaDon_Model(i);
        //        lis.Add(t);
        //    }
        //    return lis;
        //}
    }
}
