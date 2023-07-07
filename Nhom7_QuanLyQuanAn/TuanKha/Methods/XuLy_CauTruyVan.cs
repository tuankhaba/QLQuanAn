using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace TuanKha.Methods
{
    public class XuLy_CauTruyVan
    {
        private static XuLy_CauTruyVan instance;

        public static XuLy_CauTruyVan Instance
        {
            get { if (instance == null) instance = new XuLy_CauTruyVan(); return XuLy_CauTruyVan.instance; }
            private set { XuLy_CauTruyVan.instance = value; }
        }
        private XuLy_CauTruyVan() { }
        public string s = @"Data Source=DESKTOP-HING3O1\THAI;Initial Catalog=QL_QUANAN999;Integrated Security=True";
        //public DataTable getdata(string query)
        //{
        //    SqlConnection a = new SqlConnection(s);
        //    a.Open();
        //    SqlCommand cmd = new SqlCommand(query, a);
        //    DataTable data = new DataTable();
        //    SqlDataAdapter b = new SqlDataAdapter(cmd);
        //    b.Fill(data);
        //    return data;
        //}
        public DataTable ExcuteQuery(string query, object[] para = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(s))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                if (para != null)
                {
                    int j = 0;
                    string[] lispara = query.Split(' ');
                    foreach (string i in lispara)
                    {
                        if (i.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(i, para[j]);

                            j++;
                        }
                    }
                }
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                adt.Fill(data);
                con.Close();
            }
            return data;
        }
        public int ExcuteNonQuery(string query, object[] para = null)
        {
            int data = 0;
            using (SqlConnection con = new SqlConnection(s))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                if (para != null)
                {
                    int j = 0;
                    string[] lispara = query.Split(' ');
                    foreach (string i in lispara)
                    {
                        if (i.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(i, para[j]);
                            j++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                con.Close();
            }
            return data;
        }
        public object Excute_Scalar(string query, object[] para = null)
        {
            object data = 0;
            using (SqlConnection con = new SqlConnection(s))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                if (para != null)
                {
                    int j = 0;
                    string[] lispara = query.Split(' ');
                    foreach (string i in lispara)
                    {
                        if (i.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(i, para[j]);
                            j++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                con.Close();
            }
            return data;
        }
    }
}
