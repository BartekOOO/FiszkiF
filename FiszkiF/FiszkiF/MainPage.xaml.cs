using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FiszkiF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private async void Lista_zestawow(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Lista_zestawow());
        }

        private async void Dodawanie_zestawu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Dodawanie_zestawu());
        }
    }
}
