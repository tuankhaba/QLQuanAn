using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class ChiTiet_HD_Model
    {
        private int iddu;
        private int mact;

        public int Mact
        {
            get { return mact; }
            set { mact = value; }
        }
        public int Iddu
        {
            get { return iddu; }
            set { iddu = value; }
        }
        private int idhd;

        public int Idhd
        {
            get { return idhd; }
            set { idhd = value; }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public ChiTiet_HD_Model(int mact, int id, int id2, int sl)
        {
            this.mact = mact;
            this.iddu = id;
            this.idhd = id2;
            this.count = sl;
        }
        public ChiTiet_HD_Model(DataRow r)
        {
            this.mact = (int)r["MACT"];
            this.iddu = (int)r["MAMA"];
            this.idhd = (int)r["MAHD"];
            this.count = (int)r["SOL"];
        }
    }
}
