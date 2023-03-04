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
        private String data;
        private String rodzaj_cwiczenia;
        private int numer_serii;
        private int liczba_powtorzen;
        private int waga_obciazenia;

        public Seria(String data, String rodzaj_cwiczenia, int numer_serii, int liczba_powtorzen, int waga_obciazenia) 
        {
            this.data = data;
            this.rodzaj_cwiczenia = rodzaj_cwiczenia;
            this.numer_serii = numer_serii;
            this.liczba_powtorzen = liczba_powtorzen;
            this.waga_obciazenia = waga_obciazenia;
        }

        public static async Task Zapisz(Seria seria)
        {
            String linia_do_zapisu = seria.data + " " + seria.rodzaj_cwiczenia + " " + seria.numer_serii + " " + seria.liczba_powtorzen + " " + seria.waga_obciazenia + " ";
            using StreamWriter file = new("Serie_cwiczen.txt", append: true);
            await file.WriteLineAsync(linia_do_zapisu);
            
        }
    }
}
