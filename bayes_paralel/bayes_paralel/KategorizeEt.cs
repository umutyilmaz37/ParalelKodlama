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
    public partial class KategorizeEt : Form
    {
        public KategorizeEt()
        {
            InitializeComponent();
        }

        private void KategorizeEt_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                string sorgu = ("select hasta_id,radyasyon,kanser from hasta where radyasyon='var'");
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                DataTable dt = new DataTable();

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
                NpgsqlCommand com = new NpgsqlCommand();

                com.CommandText = sorgu;
                com.Connection = baglanti;
                adap.SelectCommand = com;

                baglanti.Open();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (listBox1.SelectedIndex == 1)
            {
                string sorgu = ("select hasta_id,radyasyon,kanser from hasta where radyasyon='yok'");
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                DataTable dt = new DataTable();

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
                NpgsqlCommand com = new NpgsqlCommand();

                com.CommandText = sorgu;
                com.Connection = baglanti;
                adap.SelectCommand = com;

                baglanti.Open();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (listBox1.SelectedIndex == 2)
            {
                string sorgu = ("select hasta_id,rontgen,kanser from hasta where rontgen='pozitif'");
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                DataTable dt = new DataTable();

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
                NpgsqlCommand com = new NpgsqlCommand();

                com.CommandText = sorgu;
                com.Connection = baglanti;
                adap.SelectCommand = com;

                baglanti.Open();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (listBox1.SelectedIndex == 3)
            {
                string sorgu = ("select hasta_id,rontgen,kanser from hasta where rontgen='negatif'");
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                DataTable dt = new DataTable();

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
                NpgsqlCommand com = new NpgsqlCommand();

                com.CommandText = sorgu;
                com.Connection = baglanti;
                adap.SelectCommand = com;

                baglanti.Open();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (listBox1.SelectedIndex == 4)
            {
                string sorgu = ("select hasta_id,sigara,kanser from hasta where sigara='var'");
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                DataTable dt = new DataTable();

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
                NpgsqlCommand com = new NpgsqlCommand();

                com.CommandText = sorgu;
                com.Connection = baglanti;
                adap.SelectCommand = com;

                baglanti.Open();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (listBox1.SelectedIndex == 5)
            {
                string sorgu = ("select hasta_id,sigara,kanser from hasta where sigara='yok'");
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                DataTable dt = new DataTable();

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
                NpgsqlCommand com = new NpgsqlCommand();

                com.CommandText = sorgu;
                com.Connection = baglanti;
                adap.SelectCommand = com;

                baglanti.Open();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (listBox1.SelectedIndex == 6)
            {
                string sorgu = ("select hasta_id,nefes_darligi,kanser from hasta where nefes_darligi='var'");
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                DataTable dt = new DataTable();

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
                NpgsqlCommand com = new NpgsqlCommand();

                com.CommandText = sorgu;
                com.Connection = baglanti;
                adap.SelectCommand = com;

                baglanti.Open();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (listBox1.SelectedIndex == 7)
            {
                string sorgu = ("select hasta_id,nefes_darligi,kanser from hasta where nefes_darligi='yok'");
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                DataTable dt = new DataTable();

                NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
                NpgsqlCommand com = new NpgsqlCommand();

                com.CommandText = sorgu;
                com.Connection = baglanti;
                adap.SelectCommand = com;

                baglanti.Open();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = listBox1.SelectedItem.ToString();
        }

        
       
        
    }
}
