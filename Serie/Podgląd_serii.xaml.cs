using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Serie
{
    /// <summary>
    /// Logika interakcji dla klasy Podgląd_serii.xaml
    /// </summary>
    public partial class Podgląd_serii : Window
    {
        ObservableCollection<string> lista_cwiczen = new ObservableCollection<string>();
            
        ObservableCollection<Seria> serie_do_wyswietlenia = new ObservableCollection<Seria>();

        public Podgląd_serii()
        {
            InitializeComponent();
            
            lista_cwiczen.Add("Pokaż wszystko");
            lista_cwiczen.Add("sztanga");
            lista_cwiczen.Add("bicki");
            lista_cwiczen.Add("brzuszki");
            lista_cwiczen.Add("podciągniecia");
            
            RodzajCwiczenia.ItemsSource = lista_cwiczen;

            // tworzenie kolekcji obiektów Serii z pliku tekstowego
            foreach(string seria in serie_z_pliku)
            {
                string[] el_serii = seria.Split(' ');

                serie_do_wyswietlenia.Add(new Seria(el_serii[0], el_serii[1], Convert.ToInt32(el_serii[2]), Convert.ToInt32(el_serii[3]), Convert.ToInt32(el_serii[4]))); 
            }
            
           ListaSerii.ItemsSource = serie_do_wyswietlenia;
        }

        public String rodzaj_cwiczenia = "";

        readonly string[] serie_z_pliku = File.ReadAllLines(@"Serie_cwiczen.txt");

        private void Rodzaj_Cwiczenia(object sender, SelectionChangedEventArgs e)
        {
            rodzaj_cwiczenia = RodzajCwiczenia.SelectedItem.ToString(); // zapisuje wybor rodzaju cwiczenia do zmiennej rodzaj_cwiczenia

            ObservableCollection<Seria> serie_wybrane = new ObservableCollection<Seria>();

            // intrukcja warunkowa, lista_cwiczen[0] to "Pokaż wszystko", kiedy warunek spełniony, w programie wyśiwetlają się wszystkie serie ćwiczeń
            if (rodzaj_cwiczenia == lista_cwiczen[0])
            {
                ListaSerii.ItemsSource = serie_do_wyswietlenia;
            }
            else
            {   // w pętli tworzona jest kolekcja obiektów Serii spełniających kryterium wyboru z paska rozwijanego
                foreach(Seria seria in serie_do_wyswietlenia)
                {
                    if (seria.Rodzaj_cwiczenia == rodzaj_cwiczenia)
                        serie_wybrane.Add(seria);
                }
                ListaSerii.ItemsSource = serie_wybrane;
            }
        }

        private void Lista_Serii(object sender, SelectionChangedEventArgs e)
        {
            // pusto
        }
        
        private void Naglowek_Click(object sender, RoutedEventArgs e)
        {
            // sortowanie serii wg klimniętego nagłówka
            GridViewColumnHeader naglowek = sender as GridViewColumnHeader;
            string kolumnaDoSortowania = naglowek.Content.ToString();

            CollectionView widok = (CollectionView)CollectionViewSource.GetDefaultView(ListaSerii.ItemsSource);
            ListSortDirection sortowanie = ListSortDirection.Ascending;

            if (widok.SortDescriptions.Any())
            {
                SortDescription elem = widok.SortDescriptions.ElementAt(0);

                if (kolumnaDoSortowania == elem.PropertyName.ToString())
                    if (elem.Direction == ListSortDirection.Ascending)
                        sortowanie = ListSortDirection.Descending;
                    else
                        sortowanie = ListSortDirection.Ascending;
            }

            widok.SortDescriptions.Clear();

            widok.SortDescriptions.Add(new SortDescription(kolumnaDoSortowania, sortowanie));
        }
    }
}
