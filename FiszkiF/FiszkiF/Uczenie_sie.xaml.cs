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
    public partial class Uczenie_sie : ContentPage
    {
        int a;
        bool prawda;
        SQLiteConnection baza = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "baza2.db3"));
        ObservableCollection<Tabelka_dodanych_slow> Fiszki = new ObservableCollection<Tabelka_dodanych_slow>();
        public Uczenie_sie()
        {
            InitializeComponent();
            a = 0;
            prawda = false;
            baza.CreateTable<Zestaw>();
            var odczyt = baza.Query<Zestaw>($"select * from Zestaw where Id_zes='{Zmienna.Id}'");
            foreach(var s in odczyt)
            {
                nazwa_zestawu.Text = s.Nazwa_zes;
            }

            baza.CreateTable<Fiszka>();
            var odczyt1 = baza.Query<Fiszka>($"select * from Fiszka where Id_zestawu={Zmienna.Id};");
            foreach (var s in odczyt1)
            {
                Fiszki.Add(new Tabelka_dodanych_slow(s.Slowo_fiszka,s.Tlumaczenie_fiszka));
            }


            Zmienna.Globalny_zestaw_fiszek = Fiszki;
            Lista_fiszek_zestaw.ItemsSource = Fiszki;
            wyswietlana_fiszka.Text = Fiszki[0].slowo_grid;
        }

        private void odwroc_fiszke(object sender, EventArgs e)
        {
            if(prawda)
            {
                prawda = false;
                wyswietlana_fiszka.Text = Fiszki[a].slowo_grid;
            }
            else
            {
                prawda = true;
                wyswietlana_fiszka.Text = Fiszki[a].tlumaczenie_grid;
            }


        }

        private void przesun_w_lewo(object sender, SwipedEventArgs e)
        {
            a++;
            if(a>Fiszki.Count()-1)
            {
                a = 0;
            }
            prawda = false;
            wyswietlana_fiszka.Text = Fiszki[a].slowo_grid;
          
        }

        private void przesun_w_prawo(object sender, SwipedEventArgs e)
        {
            a--;
            if (a < 0)
            {
                a = Fiszki.Count-1;
            }
            prawda = false;
            wyswietlana_fiszka.Text = Fiszki[a].slowo_grid;
        }

        private async void tryb_z_fiszkami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tryb_fiszki());
        }

        private async void tryb_z_testem(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tryb_test());
        }

        private void tryb_z_pisaniem(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tryb_pisanie());
        }
    }
}