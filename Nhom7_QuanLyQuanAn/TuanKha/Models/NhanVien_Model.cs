using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class NhanVien_Model
    {
        public NhanVien_Model(int ma, string t, string sdt,DateTime ns,string gioitinh)
        {
            this.ma = ma;
            this.ten = t;
            this.ngays = ns;
            this.gioitinh=gioitinh;
            this.sdt = sdt;
        }
        public NhanVien_Model(DataRow r)
        {
            this.ma = (int)r["MANV"];
            this.ten = r["HOT"].ToString();
            this.ngays = (DateTime)r["NGAYS"];
            this.gioitinh = r["GIOIT"].ToString();
            this.sdt = r["SDT"].ToString();
        }
        private int ma;
        private DateTime ngays;

        public DateTime Ngays
        {
            get { return ngays; }
            set { ngays = value; }
        }
        public int Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        private string ten, sdt, gioitinh;

        public string Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

      

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }


    }
}
