using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class MonAn_Model
    {
        int ma;
        public MonAn_Model(int m, string t, float g, int ml)
        {
            this.ma = m;
            this.ten = t;
            this.gia = g;
            this.mal = ml;
        }
        public MonAn_Model(DataRow r)
        {
            this.ma = (int)r["MAMA"];
            this.ten = r["TENMA"].ToString();
            this.gia = (float)Convert.ToDouble(r["GIA"].ToString());
            this.mal = (int)r["MAL"];
        }
        public int Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        float gia;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        int mal;

        public int Mal
        {
            get { return mal; }
            set { mal = value; }
        }
    }
}
