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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-06LT5PF\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True"))
            {
                baglanti.Open();

                SqlCommand admcmd = new SqlCommand("SELECT * FROM Tbl_Yonetici WHERE KullaniciAdi=@p1 AND Sifre=@p2", baglanti);
                admcmd.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
                admcmd.Parameters.AddWithValue("@p2", TxtSifre.Text);

                SqlDataReader dr = admcmd.ExecuteReader();

                if (dr.Read())
                {
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!");
                }
            }
        }
    }
    }
