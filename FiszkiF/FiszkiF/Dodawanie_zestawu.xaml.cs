using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FiszkiF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dodawanie_zestawu : ContentPage
    {
        SQLiteConnection baza = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "baza2.db3"));
        ObservableCollection<Tabelka_dodanych_slow>Lista_dodanych = new ObservableCollection<Tabelka_dodanych_slow>();
        public int zmienna;

        public Dodawanie_zestawu()
        {
            InitializeComponent();
            zmienna = 0;
        }

        private void Dodaj_nowa_fiszke(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(tlumaczenie_entry.Text)||String.IsNullOrEmpty(slowo_entry.Text))
            {
                DisplayAlert("Komunikat","Pole słowo/tłumaczenie jest puste","Ok");
            }
            else
            {
                Lista_dodanych.Add(new Tabelka_dodanych_slow(slowo_entry.Text,tlumaczenie_entry.Text));
                slowo_entry.Text = "";
                tlumaczenie_entry.Text = "";
                Lista_dodanych_fiszek.ItemsSource = Lista_dodanych;
                zmienna++;
            }
        }


        
        private void Zatwierdz_caly_zestaw(object sender, EventArgs e)
        {
            bool sprawdz = false;

            var odczyt1 = baza.Query<Zestaw>($"select * from Zestaw;");

            foreach (var s in odczyt1)
            {
                if(s.Nazwa_zes==Nazwa_zestawu.Text)
                {
                    sprawdz = true;
                }
            }

            if (String.IsNullOrEmpty(Nazwa_zestawu.Text)||zmienna<=0||sprawdz)
            {
                DisplayAlert("Komunikat", "Nie wprowadzono nazwy zestawu/musi być przynajmniej jedna definicja/Istnieje już zestaw z taką nazwą", "Ok");
            }
            else
            {
                baza.CreateTable<Zestaw>();
                Zestaw zestaw = new Zestaw();
                zestaw.Nazwa_zes = Nazwa_zestawu.Text;
                baza.Insert(zestaw);

                int b = 0;
                var odczyt = baza.Query<Zestaw>($"select * from Zestaw where Nazwa_zes='{Nazwa_zestawu.Text}';");

                foreach(var s in odczyt)
                {
                    b = s.Id_zes;
                }
             
                baza.CreateTable<Fiszka>();
                Fiszka fiszka = new Fiszka();
                for(int i=0;i<Lista_dodanych.Count;i++)
                {
                    fiszka.Tlumaczenie_fiszka = Lista_dodanych[i].tlumaczenie_grid;
                    fiszka.Slowo_fiszka = Lista_dodanych[i].slowo_grid;
                    fiszka.Id_zestawu = b.ToString();
                    baza.Insert(fiszka);
                }
                Navigation.PopAsync();
            }
        }

        private void Modyfikuj_dodana_fiszke(object sender, ItemTappedEventArgs e)
        {
            int a = e.ItemIndex;
            zmienna--;
            slowo_entry.Text = Lista_dodanych[a].slowo_grid;
            tlumaczenie_entry.Text = Lista_dodanych[a].tlumaczenie_grid;
            Lista_dodanych.RemoveAt(a);
        }
    }
}