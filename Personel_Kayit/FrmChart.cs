using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class FrmChart : Form
    {
        public FrmChart()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-06LT5PF\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void FrmChart_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select Persehir, Count(*) from Tbl_Personel Group by Persehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();

            while (dr1.Read())
            {

                chart1.Series["Sehirs"].Points.AddXY(dr1[0], dr1[1]);

            }

            baglanti.Close();


            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select Permeslek,Avg(PerMaas) From Tbl_Personel Group By Permeslek",baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();

            while (dr2.Read())
            {
                chart2.Series["MaasAvg"].Points.AddXY(dr2[0], dr2[1]);
            }

            baglanti.Close();



        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
