using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Methods
{
    public class NhanVien_Method
    {
        private static NhanVien_Method ins;

        public static NhanVien_Method Ins
        {
            get { if (ins == null) ins = new NhanVien_Method(); return ins; }
            set { ins = value; }
        }
        public NhanVien_Method() { }
        public bool ThemNhanVien(int Manv, string TenTK,DateTime ns, string gt,string SDT, int ChucVu)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("insert into NHANVIEN values(N'"+TenTK+"','"+ns+"',N'"+gt+"','"+SDT+"',"+ChucVu+")");
            return result > 0;
        }
        public bool XoaNhanVien(int MaNhanVien)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("delete from NHANVIEN where MANV=" + MaNhanVien + "");
            return result > 0;
        }
        public bool SuaNhanVien(int ma, string TenTK, string gt, string SDT, int ChucVu)
        {
            int result = XuLy_CauTruyVan.Instance.ExcuteNonQuery("update NHANVIEN set HOT=N'" + TenTK + "',GIOIT=N'" + gt + "',SDT='"+SDT+"',TRANGTHAI="+ChucVu+" where MANV=" + ma + "");
            return result > 0;
        }
    }
}
