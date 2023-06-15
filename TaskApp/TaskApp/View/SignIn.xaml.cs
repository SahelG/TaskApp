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
    public partial class SignIn : ContentPage
    {
        UserRepository repository = new UserRepository();
        public SignIn()
        {
            InitializeComponent();
        }

        private async void btnSignIn_Clicked(object sender, EventArgs e)
        {
            string emailSI = txtEmailSI.Text;
            string passwordSI = txtPasswordSI.Text;
            string isSignIN = await repository.SignIn(emailSI, passwordSI);

            if (string.IsNullOrEmpty(emailSI) || string.IsNullOrEmpty(passwordSI))
            {
                await DisplayAlert("Warning", "Please fill the fields", "Cancel");
            }

            if (!string.IsNullOrEmpty(isSignIN))
                await Navigation.PushAsync(new MainV2());
            else
                await DisplayAlert("Error", "Sign in failed", "Cancel");

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }
    }
}