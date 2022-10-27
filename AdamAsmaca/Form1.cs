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
        List<string> kelimeler = new List<string>() { "kalem", "fare", "çanta","tesbih" };
        List<PictureBox> resimler;
        List<Button> butonlar;
        Oyun oyun;
        int hak = 0;
        int bilinenharf = 0;
        bool ilkcalistirma = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resimler = new List<PictureBox> { pb1, pb2, pb3, pb4, pb5, pb6 };
            butonlar = new List<Button> { btnA,btnB,btnC,btnCh,btnD,btnE,btnF,btnG,btnYumusakG,btnH,btnI,btnIi,btnJ,btnK,btnL,btnM,btnN,btnO,btnNoktaO,btnP,btnR,btnS,btnSh,btnT,btnU,btnNoktaU,btnV,btnY,btnZ};

            foreach(Button button in butonlar)
            {
                button.Enabled = false;
            }

            ResimGizle();
        }
        private void ResimGizle()
        {
            foreach (PictureBox p in resimler)
            {
                p.Visible = false;
            }
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (!ilkcalistirma)
            {
                LabelEkle(false);
            }
            ResimGizle();
            oyun = new Oyun(kelimeler);
            oyun.OyunBaslat();
            btnBasla.Enabled = false;
            foreach(Button button in butonlar)
            {
                button.Enabled = true;
            }
            hak = 0;
            bilinenharf = 0;
            LabelEkle(true);
            ilkcalistirma = false;
        }

        private void LabelEkle(bool Ekle)
        {
            if (Ekle)
            {
                foreach (Label label in oyun.LabelListesi)
                {
                    this.Controls.Add(label);
                }
            }
            else
            {
                foreach (Label label in oyun.LabelListesi)
                {
                    this.Controls.Remove(label);
                }
            }
        }

        private void tiklananHarf(object sender, EventArgs e)
        {
            Button harf = (Button) sender;
            List<int> donendegerler = oyun.HarfGir(Convert.ToChar(harf.Text.ToLower()));
            harf.Enabled = false;
            foreach(int deger in donendegerler)
            {
                if (deger == -1)
                {
                    resimler[hak].Visible = true;
                    hak++;
                    if (hak == 6)
                    {
                        MessageBox.Show("Oyun Bitti! Kaybettiniz!");
                        btnBasla.Enabled = true;
                    }
                }
                else if (deger == -100)
                {
                    MessageBox.Show("Oyun Bitti! Kaybettiniz!");
                    btnBasla.Enabled = true;
                }
                else
                {
                    oyun.LabelListesi[deger].Text = harf.Text;
                    bilinenharf++;
                    if (bilinenharf == oyun.SecilenKelime.Length)
                    {
                        MessageBox.Show("Oyunu Kazandınız!");
                        btnBasla.Enabled = true;
                    }
                }
            }
        }
    }
}
