using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace bayes_paralel
{
    
    public partial class kanserTahmin : Form
    {
        public kanserTahmin()
        {
            InitializeComponent();
        }

        

        private void kanserTahmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            
            Thread thread1 = new Thread(new ThreadStart(surec1));
            Thread thread2 = new Thread(new ThreadStart(surec2));
            Thread thread3 = new Thread(new ThreadStart(surec3));
            Thread thread4 = new Thread(new ThreadStart(surec4));

            System.Diagnostics.Stopwatch zaman = new System.Diagnostics.Stopwatch();
            
            int deger = 0;
            
            zaman.Start();

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            
           
            zaman.Stop();
            MessageBox.Show(zaman.ElapsedMilliseconds.ToString());
        }

        //4 thread kullanılan durum

        public void surec1() 
        {
            /*1.durum*/
            if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {

                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

                /*2.durum*/   else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

                /*3.durum*/   else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {

                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();


            }

            /*4.durum*/    else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        public void surec2() 
        { 
        /*5.durum*/ if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {

                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();


            }

               /*6.durum*/ else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

               /*7.durum*/ else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

               /*8.durum*/ else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        public void surec3()
        {
            
               /*9.durum*/  if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                   /*10.durum*/   else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                   /*11.durum*/   else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

               /*12.durum*/    else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        public void surec4()
        { 
            /*13.durum*/  if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

                  /*14.durum*/ else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                  /*15.durum*/ else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                  /*16.durum*/ else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        
        //2 thread kullanılan tahmin bölümü
        
        public void surec5()
        {
            /*1.durum*/
            if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {

                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

                /*2.durum*/   else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

                /*3.durum*/   else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {

                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();


            }

            /*4.durum*/    else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
       
            /*5.durum*/
            else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();


            }

                /*6.durum*/ else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*7.durum*/ else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*8.durum*/ else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        public void surec6()
        {

            /*9.durum*/
            if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*10.durum*/   else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*11.durum*/   else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

            /*12.durum*/    else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        
        
        
            /*13.durum*/
            else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

                /*14.durum*/ else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*15.durum*/ else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*16.durum*/ else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
       



        //8 thread kullanılan durum


        public void surec7()
        {
            /*1.durum*/
            if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {

                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

                /*2.durum*/   else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }
        }

               public void surec8(){
                   
                   if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {

                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();


            }

            /*4.durum*/    else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        public void surec9()
        {
            /*5.durum*/
            if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {

                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();


            }

                /*6.durum*/ else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }

        public void surec10(){

                /*7.durum*/  if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*8.durum*/ else if (listBox1.SelectedIndex == 0 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='var' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        public void surec11()
        {

            /*9.durum*/
            if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*10.durum*/   else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

        } 
        public void surec12(){
            //11.durum
            if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

            /*12.durum*/    else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 0 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='pozitif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        public void surec13()
        {
            /*13.durum*/
            if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();

            }

                /*14.durum*/ else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 0 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='var' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }
        public void surec14()
        {

                /*15.durum*/  if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='var' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }

                /*16.durum*/ else if (listBox1.SelectedIndex == 1 && listBox2.SelectedIndex == 1 && listBox3.SelectedIndex == 1 && listBox4.SelectedIndex == 1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                baglanti.Open();

                NpgsqlCommand com = new NpgsqlCommand("select count(*) from hasta");
                NpgsqlCommand com1 = new NpgsqlCommand("select count(*) from hasta where  kanser='evet'");

                NpgsqlCommand com2 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='evet'");
                NpgsqlCommand com3 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='evet'");
                NpgsqlCommand com4 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='evet'");
                NpgsqlCommand com5 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='evet'");

                NpgsqlCommand com6 = new NpgsqlCommand("select count(*) from hasta where  kanser='hayır'");

                NpgsqlCommand com7 = new NpgsqlCommand("select count(*) from hasta where radyasyon='yok' and kanser='hayır'");
                NpgsqlCommand com8 = new NpgsqlCommand("select count(*) from hasta where rontgen='negatif' and kanser='hayır'");
                NpgsqlCommand com9 = new NpgsqlCommand("select count(*) from hasta where sigara='yok' and kanser='hayır'");
                NpgsqlCommand com10 = new NpgsqlCommand("select count(*) from hasta where nefes_darligi='yok' and kanser='hayır'");

                com.Connection = baglanti;
                com1.Connection = baglanti;
                com2.Connection = baglanti;
                com3.Connection = baglanti;
                com4.Connection = baglanti;
                com5.Connection = baglanti;
                com6.Connection = baglanti;
                com7.Connection = baglanti;
                com8.Connection = baglanti;
                com9.Connection = baglanti;
                com10.Connection = baglanti;


                Double hastaSayi = Convert.ToDouble(com.ExecuteScalar());
                Double kanserE = Convert.ToDouble(com1.ExecuteScalar());

                Double ranyasyonV = Convert.ToDouble(com2.ExecuteScalar());
                Double rontgenE = Convert.ToDouble(com3.ExecuteScalar());
                Double sigaraV = Convert.ToDouble(com4.ExecuteScalar());
                Double nefesdarligiV = Convert.ToDouble(com5.ExecuteScalar());

                Double kanserH = Convert.ToDouble(com6.ExecuteScalar());

                Double ranyasyonEkH = Convert.ToDouble(com7.ExecuteScalar());
                Double rontgenEkH = Convert.ToDouble(com8.ExecuteScalar());
                Double sigaraVkH = Convert.ToDouble(com9.ExecuteScalar());
                Double nefesdarligiVkH = Convert.ToDouble(com10.ExecuteScalar());

                Double tahmin = (ranyasyonV / kanserE) * (rontgenE / kanserE) * (sigaraV / kanserE) * (nefesdarligiV / kanserE) * (kanserE / hastaSayi);

                Double tahminH = (ranyasyonEkH / kanserH) * (rontgenEkH / kanserH) * (sigaraVkH / kanserH) * (nefesdarligiVkH / kanserH) * (kanserH / hastaSayi);


                if (tahmin > 0 || tahminH > 0)
                {
                    textBox5.Text = Convert.ToString(tahmin.ToString());
                    textBox6.Text = Convert.ToString(tahminH.ToString());
                }
                else
                {
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                }
                baglanti.Close();
            }
        }





        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;

            Thread thread1 = new Thread(new ThreadStart(surec5));
            Thread thread2 = new Thread(new ThreadStart(surec6));
            

            System.Diagnostics.Stopwatch zaman = new System.Diagnostics.Stopwatch();

            int deger = 0;

            zaman.Start();

            thread1.Start();
            thread2.Start();
   
            zaman.Stop();
            MessageBox.Show(zaman.ElapsedMilliseconds.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;

            Thread thread1 = new Thread(new ThreadStart(surec7));
            Thread thread2 = new Thread(new ThreadStart(surec8));
            Thread thread3 = new Thread(new ThreadStart(surec9));
            Thread thread4 = new Thread(new ThreadStart(surec10));
            Thread thread5 = new Thread(new ThreadStart(surec11));
            Thread thread6 = new Thread(new ThreadStart(surec12));
            Thread thread7 = new Thread(new ThreadStart(surec13));
            Thread thread8 = new Thread(new ThreadStart(surec14));



            System.Diagnostics.Stopwatch zaman = new System.Diagnostics.Stopwatch();

            int deger = 0;

            zaman.Start();

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();
            

            zaman.Stop();
           
            MessageBox.Show(zaman.ElapsedMilliseconds.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {

          String kanserVeri;
            
            if (textBox5.Text == String.Empty)
            {
                MessageBox.Show("İlk Önce Tahmin Tuşuna basınız !","UYARI");
            }

            else
            {
                double veri1 = Double.Parse(textBox5.Text);
                double veri2=Double.Parse(textBox6.Text);

                if (veri1 > veri2) 
                {
                    kanserVeri = "evet";
                } 
                else
                {
                    kanserVeri = "hayır";
                }
                

                try
                {
                    NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;User ID=postgres;password=1234;Database=Hastalar");
                    baglanti.Open();
                    string komut = "insert into hasta(radyasyon,rontgen,sigara,nefes_darligi,kanser) values('" + this.listBox1.Text + "','" + this.listBox2.Text + "','" + this.listBox3.Text + "','" + this.listBox4.Text + "','" + kanserVeri + "')";
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
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
