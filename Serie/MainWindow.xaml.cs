﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Serie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<string> lista_cwiczen = new ObservableCollection<string>();

            lista_cwiczen.Add("sztanga");
            lista_cwiczen.Add("bicki");
            lista_cwiczen.Add("brzuszki");
            lista_cwiczen.Add("podciągniecia");

            RodzajCwiczenia.ItemsSource= lista_cwiczen;

            Data.Text = dzis.ToString("d");

        }
       static DateTime dzis = DateTime.Today;

        public String data = dzis.ToString("d");
        public String rodzaj_cwiczenia = ""; 
        public int numer_serii = 0;
        public int liczba_powtorzen = 0;
        public int waga_obciazenia = 0;


        // Rodzaj ćwiczenia
        private void Rodzaj_cwiczenia(object sender, SelectionChangedEventArgs e)
        {
            rodzaj_cwiczenia = RodzajCwiczenia.SelectedItem.ToString(); // zapisuje wybor rodzaju cwiczenia do zmiennej String
        }
        
        private void Numer_serii(object sender, TextChangedEventArgs e)
        {
            try
            {
                numer_serii = int.Parse(NumerSerii_wartosc.Text);
            }
            catch (Exception)
            {
                NumerSerii_wartosc.Clear();
            }        
        }

        private void Liczba_powtorzen(object sender, TextChangedEventArgs e)
        {
            try
            {
                liczba_powtorzen = int.Parse(LiczbaPowtorzen_wartosc.Text);
                if(liczba_powtorzen == 0)
                    LiczbaPowtorzen_wartosc.Clear();
            }
            catch (Exception)
            {
                LiczbaPowtorzen_wartosc.Clear();
            }
        }

        private void Waga_obciazenia(object sender, TextChangedEventArgs e)
        {
            try
            {
                waga_obciazenia = int.Parse(WagaObciazenia_wartosc.Text);
            }
            catch (Exception)
            {
                WagaObciazenia_wartosc.Clear();
            }
        }

        private void NastepnaSeria_Click(object sender, RoutedEventArgs e)
        {
            Seria seria = new Seria(data,rodzaj_cwiczenia,numer_serii,liczba_powtorzen,waga_obciazenia);
            
            _ = Seria.Zapisz(seria);
            MessageBox.Show("Zapisano");
        }

        private void ZobaczSerie_Click(object sender, RoutedEventArgs e)
        {
            Podgląd_serii podgląd_Serii = new Podgląd_serii();

            podgląd_Serii.ShowDialog();
        }
    }
}
