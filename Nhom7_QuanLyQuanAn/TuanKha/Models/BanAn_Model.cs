using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class BanAn_Model
    {
        private int id;
        private string name;
        private int tt;

        public int Tt
        {
            get { return tt; }
            set { tt = value; }
        }
        public static int w = 100;
        public static int H = 100;
        public BanAn_Model(int id, string ten, int tt)
        {
            this.id = id;
            this.name = ten;
            this.tt = tt;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public BanAn_Model(DataRow r)
        {
            this.id = int.Parse(r["MABA"].ToString());
            this.name = r["TENB"].ToString();
            this.tt = int.Parse(r["TRANGTHAI"].ToString());
        }

    }
}
