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
    public partial class SignUp : ContentPage
    {
        UserRepository repository = new UserRepository();
        public SignUp()
        {
            InitializeComponent();
        }

        private async void btnSignUp_Clicked(object sender, EventArgs e)
        {
            string firstNameSU = txtFirstNameSU.Text;
            string lastNameSU = txtLastNameSU.Text;
            string emailSU = txtEmailSU.Text;
            string passwordSU = txtPasswordSU.Text;

            if (string.IsNullOrEmpty(firstNameSU) || string.IsNullOrEmpty(lastNameSU) || string.IsNullOrEmpty(emailSU) || string.IsNullOrEmpty(passwordSU))
            {
                await DisplayAlert("Warning", "Please fill the fields", "Cancel");
            }

            User user = new User();
            user.firstName = firstNameSU;
            user.lastName = lastNameSU;
            user.email = emailSU;
            user.password = passwordSU;


            var isSave = await repository.Register(firstNameSU, lastNameSU, emailSU, passwordSU);
            //var isSave2 = await repository.SaveUser(user);

            if (isSave)
            {
                var isSave2 = await repository.SaveUser(user);
                if (isSave2)
                {
                    await DisplayAlert("Information", "User has been saved", "Ok");
                    await Navigation.PushAsync(new MainV2());
                }
                    
                else
                    await DisplayAlert("Error", "Saved failed2", "Cancel");
            } else
            {
                await DisplayAlert("Error", "Saved failed", "Cancel");
            }
        }
    }
}