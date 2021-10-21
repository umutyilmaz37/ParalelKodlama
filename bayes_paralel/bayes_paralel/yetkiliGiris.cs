using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace bayes_paralel
{
    public partial class yetkiliGiris : Form
    {
        public yetkiliGiris()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            bool blnfound = false;

            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
            baglanti.Open();
            string sorgu = ("select *from yetkili where y_ad='" + textBox1.Text + "'and y_sifre='" + textBox2.Text + "'");
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu, baglanti);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                blnfound = true;
                veriEkleCikar f5 = new veriEkleCikar();
                f5.ShowDialog();
                this.Hide();
            }

            if (blnfound == false)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre hatalı !", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                dr.Close();
                baglanti.Close();
            }
        }
    }
}
