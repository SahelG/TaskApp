using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await ((Frame)sender).ScaleTo(0.8, 50, Easing.Linear);
            await Task.Delay(100);
            await ((Frame)sender).ScaleTo(1, 50, Easing.Linear);
        }
    }
}