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
    public partial class Lista_zestawow : ContentPage
    {
        SQLiteConnection baza = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "baza2.db3"));
        ObservableCollection<Tabelka_dodanych_zestawow> Lista_dodanych = new ObservableCollection<Tabelka_dodanych_zestawow>();
        int c;
        public Lista_zestawow()
        {
            InitializeComponent();

            baza.CreateTable<Zestaw>();
            var odczyt = baza.Query<Zestaw>("select * from Zestaw;");

            foreach(var s in odczyt)
            {
                Lista_dodanych.Add(new Tabelka_dodanych_zestawow(s.Id_zes.ToString(),s.Nazwa_zes));
            }

            Lista_dodanych_zestawow.ItemsSource = Lista_dodanych;
            c = 0;
        }


        private void usun_zestaw(object sender, EventArgs e)
        {
            try
            {
                baza.CreateTable<Zestaw>();
                baza.Query<Zestaw>($"delete from Zestaw where Nazwa_zes='{Lista_dodanych[c].nazwa_zestawu}'");
                baza.CreateTable<Fiszka>();
                baza.Query<Fiszka>($"delete from Fiszka where Id_zestawu={Lista_dodanych[c].id}");
                Lista_dodanych.RemoveAt(c);
                Lista_dodanych_zestawow.ItemsSource = Lista_dodanych;
            }
            catch
            {
                DisplayAlert("Komunikat", "Brak zestawów", "Ok");
            }
        }

        private void nadaj(object sender, SelectedItemChangedEventArgs e)
        {
            c = e.SelectedItemIndex;
        }

        private async void zaladuj_zestaw(object sender, EventArgs e)
        {
            try
            {
                Zmienna.Id = Lista_dodanych[c].id;
                Navigation.PushAsync(new Uczenie_sie());
            }
            catch
            {
                DisplayAlert("Komunikat", "Brak zestawów", "Ok");
            }
        }
    }
}