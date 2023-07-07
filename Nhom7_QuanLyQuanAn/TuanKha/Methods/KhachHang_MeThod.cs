using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Methods
{
    public class KhachHang_MeThod
    {
        private static KhachHang_MeThod ins;

        public static KhachHang_MeThod Ins
        {
            get { if (ins == null) ins = new KhachHang_MeThod(); return ins; }
            set { ins = value; }
        }
        public KhachHang_MeThod() { }
        public void themkhachang()
        {
            XuLy_CauTruyVan.Instance.ExcuteNonQuery("exec themkhachhang");
        }
        public int lay_ID_max()
        {
            return (int)XuLy_CauTruyVan.Instance.Excute_Scalar("select MAX(KHACHHANG.MAKH) from KHACHHANG");
        }
    }
}
