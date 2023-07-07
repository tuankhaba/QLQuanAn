using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuanKha.Models;
namespace TuanKha.Methods
{
    public class ChiTiet_HD_MeThod
    {
        private static ChiTiet_HD_MeThod ins;

        public static ChiTiet_HD_MeThod Ins
        {
            get { if (ins == null) ins = new ChiTiet_HD_MeThod(); return ChiTiet_HD_MeThod.ins; }
            private set { ChiTiet_HD_MeThod.ins = value; }
        }
        private ChiTiet_HD_MeThod() { }
        public List<ChiTiet_HD_Model> layds_cthd(int id)
        {
            List<ChiTiet_HD_Model> lis = new List<ChiTiet_HD_Model>();
            DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from CHITIETMONAN where MAHD=" + id);
            foreach (DataRow i in dt.Rows)
            {
                ChiTiet_HD_Model d = new ChiTiet_HD_Model(i);
                lis.Add(d);
            }
            return lis;
        }
        public void themchitiethoadon(int mb, int mnv, int mkh)
        {
            XuLy_CauTruyVan.Instance.ExcuteNonQuery("exec addchitiethoadon @maban , @manv , @makh ", new object[] { mb, mnv, mkh });
        }
    }
}
