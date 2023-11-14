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
    public partial class Formistatistik : Form
    {
        public Formistatistik()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }









        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-06LT5PF\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Formistatistik_Load(object sender, EventArgs e)
        {


            baglanti.Open();

            // toplam personel sayısı
            SqlCommand cmd1 = new SqlCommand("select count (*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplampers.Text = dr1[0].ToString();
            }
             

  

            baglanti.Close();

            // evli personel sayısı
            baglanti.Open();

            SqlCommand cmd2 = new SqlCommand("Select count (*) From Tbl_Personel where PerDurum=1",baglanti);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString();
            }



            baglanti.Close();



            baglanti.Open();

            // bekar personel sayısı
            SqlCommand cmd3 = new SqlCommand("Select count (*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {
                lblbekarpersonel.Text = dr3[0].ToString();
            }



            baglanti.Close();

            //toplam şehir sayısı
            baglanti.Open();
            SqlCommand cmd4 = new SqlCommand("Select count (distinct(PerSehir)) From Tbl_Personel",baglanti);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                lbltoplamsehir.Text = dr4[0].ToString();
            }


            baglanti.Close();

            // toplam maaş miktarı

            baglanti.Open();
            SqlCommand cmd5 = new SqlCommand("Select sum (PerMaas) From Tbl_Personel ", baglanti);
            SqlDataReader dr5 = cmd5.ExecuteReader();

            while (dr5.Read())
            {
                lblmaastotal.Text = dr5[0].ToString();
            }

            baglanti.Close();

            //maaş averajları miktarı 

            baglanti.Open ();

            SqlCommand cmd6 = new SqlCommand("Select avg (PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = cmd6.ExecuteReader();

            while (dr6.Read())
            {
                lblavgmaas.Text = dr6[0].ToString();
            }


            baglanti.Close();



        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
