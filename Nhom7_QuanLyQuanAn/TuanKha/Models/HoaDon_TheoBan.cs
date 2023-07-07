using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class HoaDon_TheoBan
    {
        public HoaDon_TheoBan(string name, int sl, float g, float tt = 0)
        {
            this.name = name;
            this.sl = sl;
            this.g = g;
            this.thanhtien = tt;
        }
        public HoaDon_TheoBan(DataRow r)
        {
            this.name = r["TENMA"].ToString();
            this.sl = (int)r["SOL"];
            this.g = (float)Convert.ToDouble(r["GIA"].ToString());
            this.thanhtien = (float)Convert.ToDouble(r["THANHTIEN"].ToString());
        }
        private string name;
        private int sl;
        private float g;

        public float G
        {
            get { return g; }
            set { g = value; }
        }
        public int Sl
        {
            get { return sl; }
            set { sl = value; }
        }
        private float thanhtien;

        public float Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
