using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        List<string> kelimeler = new List<string>() { "kalem", "fare", "çanta" };
        List<PictureBox> resimler;
        Oyun oyun;
        int hak = 0;
        int bilinenharf = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resimler = new List<PictureBox> { pb1, pb2, pb3, pb4, pb5, pb6 };

            foreach(PictureBox p in resimler)
            {
                p.Visible = false;
            }

            oyun = new Oyun(kelimeler);
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            oyun.OyunBaslat();
            btnBasla.Enabled = false;
            foreach (Label label in oyun.LabelListesi)
            {
                this.Controls.Add(label);
            }
        }

        private void tiklananHarf(object sender, EventArgs e)
        {
            Button harf = (Button) sender;
            int i = oyun.HarfGir(Convert.ToChar(harf.Text.ToLower()));
            harf.Enabled = false;
            if (i == -1)
            {
                resimler[hak].Visible = true;
                hak++;
                if(hak == 6)
                {
                    MessageBox.Show("Oyun Bitti! Kaybettiniz!");
                }
            }
            else if (i == -100)
            {
                MessageBox.Show("Oyun Bitti! Kaybettiniz!");
            }
            else
            {
                oyun.LabelListesi[i].Text = harf.Text;
                bilinenharf++;
                if(bilinenharf == oyun.SecilenKelime.Length)
                {
                    MessageBox.Show("Oyunu Kazandınız!");
                    btnBasla.Enabled = true;
                }
            }
        }
    }
}
