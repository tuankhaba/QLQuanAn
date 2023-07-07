using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class LoaiMonAn_Model
    {
        int mal;
        public LoaiMonAn_Model(int m, string t)
        {
            this.mal = m;
            this.tenl = t;
        }
        public LoaiMonAn_Model(DataRow r)
        {
            this.mal = (int)r["MAL"];
            this.tenl = r["TENL"].ToString();
        }
        public int Mal
        {
            get { return mal; }
            set { mal = value; }
        }
        string tenl;

        public string Tenl
        {
            get { return tenl; }
            set { tenl = value; }
        }
    }
}
