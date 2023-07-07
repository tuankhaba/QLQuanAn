using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuanKha.Models;
namespace TuanKha.Methods
{
    public class LoaiMonAn_MeThod
    {
        private static LoaiMonAn_MeThod ins;

        public static LoaiMonAn_MeThod Ins
        {
            get { if (ins == null) ins = new LoaiMonAn_MeThod(); return LoaiMonAn_MeThod.ins; }
            private set { LoaiMonAn_MeThod.ins = value; }
        }
        public List<LoaiMonAn_Model> loadds_loaima()
        {
            List<LoaiMonAn_Model> lis = new List<LoaiMonAn_Model>();
            DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from LOAI");
            foreach (DataRow i in dt.Rows)
            {
                LoaiMonAn_Model a = new LoaiMonAn_Model(i);
                lis.Add(a);
            }
            return lis;
        }
        public List<LoaiMonAn_Model> Search(string Ten)
        {
            List<LoaiMonAn_Model> lisTTT = new List<LoaiMonAn_Model>();
            DataTable dtB = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from LOAI where TENL like N'%" + Ten + "%'");
            foreach (DataRow i in dtB.Rows)
            {
                LoaiMonAn_Model a = new LoaiMonAn_Model(i);
                lisTTT.Add(a);
            }
            return lisTTT;
        }
        public LoaiMonAn_Model loadds_loaima_TheoID(int id)
        {
            LoaiMonAn_Model loai = null;
            DataTable dt = XuLy_CauTruyVan.Instance.ExcuteQuery("select*from LOAI where MAL=" + id);
            foreach (DataRow i in dt.Rows)
            {
                loai = new LoaiMonAn_Model(i);
                return loai;

            }
            return loai;
        }
        public int MaLoai_Theo_id_MonAn(int id)
        {
            return (int)XuLy_CauTruyVan.Instance.Excute_Scalar("select LOAI.MAL from LOAI,MONAN where LOAI.MAL=MONAN.MAL and MAMA="+id+"");
        }


        public bool ThemLoaiMonAN(string TenLoai)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("insert into LOAI values(N'"+TenLoai+"')");
            return result > 0;
        }
        public bool XoaLoaiMonAN(int MaLoai)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("delete from LOAI where MAL=" + MaLoai + "");
            return result > 0;
        }
        public bool SuaLoaiMonAN(string TenLoai,int MaLoai)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("update LOAI set TENL=N'" + TenLoai + "' where MAL=" + MaLoai + "");
            return result > 0;
        }
    }
}
