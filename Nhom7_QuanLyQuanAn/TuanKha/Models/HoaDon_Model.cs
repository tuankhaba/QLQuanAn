using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class HoaDon_Model
    {
        private int id, b, n, k, gg;

        public int Gg
        {
            get { return gg; }
            set { gg = value; }
        }

        public int K
        {
            get { return k; }
            set { k = value; }
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }
        private DateTime? gr, gv;
        private int trt;
        private DateTime nl;

        public DateTime Nl
        {
            get { return nl; }
            set { nl = value; }
        }

        public HoaDon_Model(int id, DateTime gv, DateTime gr, int tt, DateTime nl, int b, int n, int k, int gg = 0)
        {
            this.id = id;
            this.gv = gv;
            this.gr = gr;
            this.trt = tt;
            this.nl = nl;
            this.b = b;
            this.n = n;
            this.k = k;
            this.gg = gg;
        }
        public HoaDon_Model(DataRow r)
        {
            this.id = (int)r["MAHD"];
            var i = r["GIOV"];
            if (i.ToString() != "")
                this.gv = (DateTime?)i;
            var j = r["GIOR"];
            if (j.ToString() != "")
                this.gr = (DateTime?)j;
            this.trt = (int)r["TRANGTHAI"];
            this.nl = (DateTime)r["NGAYL"];
            this.b = (int)r["MABA"];
            this.n = (int)r["MANV"];
            this.k = (int)r["MAKH"];
            this.gg = (int)r["GIAMGIA"];
        }

        public int Trt
        {
            get { return trt; }
            set { trt = value; }
        }
        public DateTime? Gv
        {
            get { return gv; }
            set { gv = value; }
        }

        public DateTime? Gr
        {
            get { return gr; }
            set { gr = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
