using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FiszkiF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tryb_pisanie : ContentPage
    {
        Random losowa = new Random();
        int a;
        public Tryb_pisanie()
        {
            InitializeComponent();
            a = losowa.Next(0,Zmienna.Globalny_zestaw_fiszek.Count-1);
            poprawna_fiszka.IsVisible = false;
            wyswietlana_fiszka.Text = Zmienna.Globalny_zestaw_fiszek[a].slowo_grid;

        }

        private void sprawdz(object sender, EventArgs e)
        {

            if (wpisana_fiszka.Text == Zmienna.Globalny_zestaw_fiszek[a].tlumaczenie_grid)
            {
                a = losowa.Next(0, Zmienna.Globalny_zestaw_fiszek.Count - 1);
                poprawna_fiszka.IsVisible = false;
                wyswietlana_fiszka.Text = Zmienna.Globalny_zestaw_fiszek[a].slowo_grid;
                wpisana_fiszka.Text = "";
            }
            else
            {
                poprawna_fiszka.Text = $"Poprawna odpowiedź: {Zmienna.Globalny_zestaw_fiszek[a].tlumaczenie_grid}";
                poprawna_fiszka.IsVisible = true;
            }

        }
    }
}