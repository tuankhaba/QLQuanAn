using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuanKha.Models
{
    public class Account_Model
    {
        private int manv, chucvu;

        public int Chucvu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }
        private string pass, displayname;

        public string Displayname
        {
            get { return displayname; }
            set { displayname = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public Account_Model(int manv, string display, string pass, int chucv)
        {
            this.manv = manv;
            this.displayname = display;
            this.pass = pass;
            this.chucvu = chucv;

        }
        public Account_Model(DataRow r)
        {
            this.manv = (int)r["MANV"];
            this.displayname = r["displayname"].ToString();
            this.pass = r["pass"].ToString();
            this.chucvu = (int)r["chucv"];
        }
    }
}
