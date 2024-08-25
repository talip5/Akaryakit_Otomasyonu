using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akaryakit_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Load+=Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            tabControl1.Location = new Point(10,10);
            label1.Font = new Font(label1.Font, FontStyle.Bold);
            this.Text = "AKARYAKIT OTOMASYONU";
            progressBar1.Maximum = 200;
            progressBar2.Maximum = 200;
            //tabPage1.Font = new Font(tabPage1.Font,FontStyle.Bold);
            tabControl1.Font = new Font(tabControl1.Font,FontStyle.Bold);
            tabPage1.Text = "  DEPO BİLGİLERİ  ";
            tabPage2.Text = "  FİYAT BİLGİLERİ ";
            tabPage3.Text = "  SATIŞ YAP       ";
            number1 = Convert.ToInt32(number);
            toplam = number1 * 5;
            //pictureBox1.Image = Image.FromFile(@"Images\a.bmp");
          
           pictureBox1.BackColor = Color.Orange;
            pictureBox1.SizeMode =PictureBoxSizeMode.StretchImage;
            //pictureBox1.Image = Image.FromFile("free.png");
            //pictureBox1.Image = Image.FromFile("picture\\free.png");
            pictureBox1.Image = Image.FromFile(@"picture\free.png");

            //label2.Text = System.IO.Directory.GetCurrentDirectory();
             string resim = System.IO.Directory.GetCurrentDirectory();

            //Image image =Image.FromFile(@"Debug\free.png"); 
            //Path.GetFullPath(PicPath)
            //C:\Users\Furka\source\repos\Akaryakit_Otomasyonu\bin\Debug
            //label2.Text = System.IO.Path.GetFileName(resim);
            //label2.Text = System.IO.Path.GetFileName("C:\\Users\\Furka\\source\\repos\\Akaryakit_Otomasyonu\\bin\\Debug");
            label2.Text = System.IO.Path.GetFileName("C:\\Users\\Furka\\source\\repos\\Akaryakit_Otomasyonu\\bin");

        }

        double D_benzin95 = 0, D_benzin97 = 0;
        double E_benzin95 = 0, E_benzin97 = 0;
        double F_benzin95 = 0, F_benzin97 = 0;
        double S_benzin95 = 0, S_benzin97 = 0;

        string number = "35";
        int number1 = 0;
        int toplam = 0;
        int yeniTop = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            progressBar_guncelle();
            numericupdown_value();
        }

        string[] depo_bilgileri;
        string[] fiyat_bilgileri;

        private void txt_depo_oku()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\klasor\\depo.txt");
            //depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            //depo_bilgileri = System.IO.File.ReadAllLines(@"C: \Users\Furka\source\repos\Akaryakit_Otomasyonu\bin\Debug\klasor\depo.txt"); HATALI
            D_benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            D_benzin97 = Convert.ToDouble(depo_bilgileri[1]);

        
        }

        private void txt_depo_yaz()
        {
            label1.Text = D_benzin95.ToString("N");
            label2.Text = D_benzin97.ToString("N");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yeniTop = Int16.Parse(number);
            yeniTop = yeniTop + 1;
            label1.Text = yeniTop.ToString();
        }

        private void txt_fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\klasor\\fiyat.txt");
            F_benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
        }

        private void txt_fiyat_yaz()
        {
            textBox1.Text = F_benzin95.ToString("N");
            textBox2.Text = F_benzin97.ToString("N");
        }

        private void progressBar_guncelle()
        {
            progressBar1.Value = Convert.ToInt16(D_benzin95);
            progressBar2.Value = Convert.ToInt16(D_benzin97);
        }

        private void numericupdown_value()
        {
            //numericUpDown1.Maximum = decimal.Parse(numericUpDown1.Value.ToString());
            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(D_benzin97.ToString());
        }

    }
}
