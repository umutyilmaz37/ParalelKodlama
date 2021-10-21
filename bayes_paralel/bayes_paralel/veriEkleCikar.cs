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
    public partial class veriEkleCikar : Form
    {
        public veriEkleCikar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");

            DataTable dt = new DataTable();

            string sorgu = ("select *from hasta order by hasta_id asc");

            NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
            NpgsqlCommand com = new NpgsqlCommand();

            com.CommandText = sorgu;
            com.Connection = baglanti;
            adap.SelectCommand = com;
            baglanti.Open();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();
                string komut = "insert into hasta(radyasyon,rontgen,sigara,nefes_darligi,kanser) values('" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "')";
                NpgsqlCommand com = new NpgsqlCommand(komut, baglanti);
                NpgsqlDataReader dr;
                dr = com.ExecuteReader();
                MessageBox.Show("Kayıt Başarılı");
                while (dr.Read())
                {

                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();
                string komut = "delete from hasta where hasta_id='" + this.textBox1.Text + "';";
                NpgsqlCommand com = new NpgsqlCommand(komut, baglanti);
                NpgsqlDataReader dr;
                dr = com.ExecuteReader();
                MessageBox.Show("Silme Başarılı");
                while (dr.Read())
                {

                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
