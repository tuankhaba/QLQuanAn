using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuanKha.Methods;

namespace TuanKha.UI
{
    public partial class KhoThucPham_Gui : UserControl
    {
        DataSet dt = new DataSet();
        public KhoThucPham_Gui()
        {
            InitializeComponent();
            load_DTGV();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void load_DTGV()
        { 
            dt.Tables.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select*from THUCPHAM",XuLy_CauTruyVan.Instance.s);
            da.Fill(dt,"THUCPHAM");
            dataGridView1.DataSource= dt.Tables["THUCPHAM"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_DTGV();
        }
    }
}
