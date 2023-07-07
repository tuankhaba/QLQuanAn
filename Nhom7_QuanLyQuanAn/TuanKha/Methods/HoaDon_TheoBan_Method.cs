using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuanKha.Models;
namespace TuanKha.Methods
{
    public class HoaDon_TheoBan_Method
    {
        private static HoaDon_TheoBan_Method ins;

        public static HoaDon_TheoBan_Method Ins
        {
            get { if (ins == null) ins = new HoaDon_TheoBan_Method(); return HoaDon_TheoBan_Method.ins; }
            set { HoaDon_TheoBan_Method.ins = value; }
        }
        private HoaDon_TheoBan_Method() { }
        public List<HoaDon_TheoBan> layds(int id)
        {
            List<HoaDon_TheoBan> lis = new List<HoaDon_TheoBan>();
            string e = "select MONAN.TENMA,ct.SOL,MONAN.GIA,ct.SOL*MONAN.GIA as 'THANHTIEN' from CHITIETMONAN ct,HOADON hd,MONAN where ct.MAHD=hd.MAHD and ct.MAMA=MONAN.MAMA and hd.TRANGTHAI=0 and hd.MABA=" + id;
            DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery(e);
            foreach (DataRow i in dt.Rows)
            {
                HoaDon_TheoBan n = new HoaDon_TheoBan(i);
                lis.Add(n);
            }
            return lis;

        }
    }
}
