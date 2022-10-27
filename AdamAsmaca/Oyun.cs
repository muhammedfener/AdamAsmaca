using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
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
        public int KalanHak { get => _kalanHak; set => _kalanHak = value; }

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

        public int HarfGir(char harf)
        {
            if(KalanHak == 0)
            {
                return -100;
            }
            if (SecilenKelime.Contains(harf))
            {
                return SecilenKelime.IndexOf(harf);
            }
            else
            {
                KalanHak--;
                return -1;
            }
        }
    }
}
