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
    public partial class Tryb_fiszki : ContentPage
    {
        int a;
        bool prawda;
        public Tryb_fiszki()
        {
            InitializeComponent();
            sliderek.Maximum = Zmienna.Globalny_zestaw_fiszek.Count;
            sliderek.Minimum = 0;
            a = 0;
            prawda = false;
            wyswietlana_fiszka.Text = Zmienna.Globalny_zestaw_fiszek[0].slowo_grid;
            sliderek.Value = a;
        }


        private void odwroc_fiszke(object sender, EventArgs e)
        {
            if (prawda)
            {
                prawda = false;
                wyswietlana_fiszka.Text = Zmienna.Globalny_zestaw_fiszek[a].slowo_grid;
            }
            else
            {
                prawda = true;
                wyswietlana_fiszka.Text = Zmienna.Globalny_zestaw_fiszek[a].tlumaczenie_grid;
            }
            sliderek.Value = a;

        }

        private void przesun_w_lewo(object sender, SwipedEventArgs e)
        {
            a++;
            if (a > Zmienna.Globalny_zestaw_fiszek.Count - 1)
            {
                a = 0;
            }
            prawda = false;
            wyswietlana_fiszka.Text = Zmienna.Globalny_zestaw_fiszek[a].slowo_grid;
            sliderek.Value = a;
        }

        private void przesun_w_prawo(object sender, SwipedEventArgs e)
        {
            a--;
            if (a < 0)
            {
                a = Zmienna.Globalny_zestaw_fiszek.Count - 1;
            }
            prawda = false;
            wyswietlana_fiszka.Text = Zmienna.Globalny_zestaw_fiszek[a].slowo_grid;
            sliderek.Value = a;
        }
    }
}