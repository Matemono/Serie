using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Serie
{
    class Seria
    {
        public String Data { get; set; }
        public String Rodzaj_cwiczenia { get; set; }
        public int Numer_serii { get; set; }
        public int Liczba_powtorzen { get; set; }
        public int Waga_obciazenia { get; set; }


        public Seria(String _data, String _rodzaj_cwiczenia, int _numer_serii, int _liczba_powtorzen, int _waga_obciazenia) 
        {
            this.Data = _data;
            this.Rodzaj_cwiczenia = _rodzaj_cwiczenia;
            this.Numer_serii = _numer_serii;
            this.Liczba_powtorzen = _liczba_powtorzen;
            this.Waga_obciazenia = _waga_obciazenia;
        }
        

        public static async Task Zapisz(Seria seria)
        {
            String linia_do_zapisu = seria.Data + " " + seria.Rodzaj_cwiczenia + " " + seria.Numer_serii + " " + seria.Liczba_powtorzen + " " + seria.Waga_obciazenia + " ";
            using StreamWriter plik = new("Serie_cwiczen.txt", append: true);
            await plik.WriteLineAsync(linia_do_zapisu);
            
        }

        

    }
}
