using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class KhachHang_Model
    {
        public KhachHang_Model(int ma, string t, string dc, string sdt)
        {
            this.ma = ma;
            this.ten = t;
            this.dch = dc;
            this.sdt = sdt;
        }
        public KhachHang_Model(DataRow r)
        {
            this.ma = (int)r["MAKH"];
            this.ten = r["TENKH"].ToString();
            this.dch = r["DIAC"].ToString();
            this.sdt = r["SDT"].ToString();
        }
        private int ma;

        public int Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        private string ten, dch, sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string Dch
        {
            get { return dch; }
            set { dch = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
    }
}
