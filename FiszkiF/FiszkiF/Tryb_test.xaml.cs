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
    public partial class Tryb_test : ContentPage
    {
        int a;
        int b;
        int c;

        Random losowa = new Random();

        public Tryb_test()
        {
            InitializeComponent();
            a = losowa.Next(0, Zmienna.Globalny_zestaw_fiszek.Count - 1);
            b = losowa.Next(0, Zmienna.Globalny_zestaw_fiszek.Count - 1);
            c = losowa.Next(0, Zmienna.Globalny_zestaw_fiszek.Count - 1);

            wyswietlana_fiszka.Text = Zmienna.Globalny_zestaw_fiszek[a].slowo_grid;

            odpa.Text = Zmienna.Globalny_zestaw_fiszek[a].tlumaczenie_grid;
            odpb.Text = Zmienna.Globalny_zestaw_fiszek[b].tlumaczenie_grid;
            odpc.Text = Zmienna.Globalny_zestaw_fiszek[c].tlumaczenie_grid;
        }

        private void odpowiedza(object sender, EventArgs e)
        {
            if(odpa.Text == Zmienna.Globalny_zestaw_fiszek[a].slowo_grid)
            {
                DisplayAlert("kom", "Dobrze", "Ok");
            }
            else
            {
                DisplayAlert("kom", "źle", "Ok");
            } 
                
        }

        private void odpowiedzb(object sender, EventArgs e)
        {
            if (odpb.Text == Zmienna.Globalny_zestaw_fiszek[a].slowo_grid)
            {
                DisplayAlert("kom", "Dobrze", "Ok");
            }
            else
            {
                DisplayAlert("kom", "źle", "Ok");
            }
        }

        private void odpowiedzc(object sender, EventArgs e)
        {
            if (odpc.Text == Zmienna.Globalny_zestaw_fiszek[a].slowo_grid)
            {
                DisplayAlert("kom", "Dobrze", "Ok");
            }
            else
            {
                DisplayAlert("kom", "źle", "Ok");
            }
        }
    }

  

    

   
}