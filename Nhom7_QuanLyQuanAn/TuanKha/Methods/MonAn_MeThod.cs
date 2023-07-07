using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuanKha.UI;
using TuanKha.Models;
namespace TuanKha.Methods
{
    public class MonAn_MeThod
    {
        private static MonAn_MeThod ins;
        public static MonAn_MeThod Ins
        {
            get { if (ins == null) ins = new MonAn_MeThod(); return MonAn_MeThod.ins; }
            private set { MonAn_MeThod.ins = value; }
        }
        public List<MonAn_Model> loadds_loaima()
        {
            List<MonAn_Model> lisTTT = new List<MonAn_Model>();
            DataTable dtB = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from MONAN");
            foreach (DataRow i in dtB.Rows)
            {
                MonAn_Model a = new MonAn_Model(i);
                lisTTT.Add(a);
            }
            return lisTTT;
        }
        public List<MonAn_Model> Search(string Ten)
        {
            List<MonAn_Model> lisTTT = new List<MonAn_Model>();
            DataTable dtB = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from MONAN where TENMA like N'%" + Ten + "%'");
            foreach (DataRow i in dtB.Rows)
            {
                MonAn_Model a = new MonAn_Model(i);
                lisTTT.Add(a);
            }
            return lisTTT;
        }
        public bool ThemMonAN( string TenMon, float Gia, int Maloai)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("insert into MONAN values( N'" + TenMon + "', '" + Gia + "'," + Maloai + ")");
            return result > 0;
        }
        public bool XoaMonAN(int MaMon)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("delete from MONAN where MAMA="+MaMon+"");
            return result > 0;
        }
        public bool SuaMonAN(int MaMon,string TenMon,float Gia,int Mal)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("update MONAN set TENMA=N'"+TenMon+"',GIA="+Gia+",MAL="+Mal+"  where MAMA=" + MaMon + "");
            return result > 0;
        }
    }
}
