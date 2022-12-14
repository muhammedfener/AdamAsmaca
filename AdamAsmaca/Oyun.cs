using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace AdamAsmaca
{
    public class Oyun
    {

        private List<string> Kelimeler = new List<string>();
        private string _secilenKelime;
        private List<Label> _labelListesi = new List<Label>();
        private int _kalanHak = 6;

        public List<string> KelimeListesi { get => Kelimeler; set => Kelimeler = value; }
        public string SecilenKelime { get => _secilenKelime; set => _secilenKelime = value; }
        public List<Label> LabelListesi { get => _labelListesi; set => _labelListesi = value; }
        public int KalanHak { get => _kalanHak; }

        public Oyun(List<string> kelimeler)
        {
            Kelimeler = kelimeler;
        }

        public void OyunBaslat(int i=0)
        {
            Random rnd = new Random();
            if(i != 0)
                SecilenKelime = Kelimeler[rnd.Next(i,Kelimeler.Count)];
            else
                SecilenKelime = Kelimeler[rnd.Next(Kelimeler.Count)];

            LabelOlustur(SecilenKelime.Length);
        }

        private void LabelOlustur(int labelsayisi)
        {
            for (int a = 0; a < labelsayisi; a++)
            {
                _labelListesi.Add(new Label());
            }
            int ilknokta = 470;
            foreach(Label label in _labelListesi)
            {
                label.Location = new Point(ilknokta, 50);
                label.Size = new Size(25, 25);
                ilknokta += 30;
                label.Visible = true;
                label.Text = "_";
                label.Font = new Font("Arial", 16);
            }
        }

        public List<int> HarfGir(char harf)
        {
            List<int> donecekler = new List<int>();
            if(KalanHak == 0)
            {
                donecekler.Add(-100);
                return donecekler;
            }
            if (SecilenKelime.Contains(harf))
            {
                for(int a=0;a<SecilenKelime.Length;a++)
                {
                    if (SecilenKelime[a] == harf)
                    {
                        donecekler.Add(a);
                    }
                }
                return donecekler;
            }
            else
            {
                _kalanHak--;
                donecekler.Add(-1);
                return donecekler;
            }
        }
    }
}
