using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Newtonsoft.Json;

namespace TaskApp
{
    public class UserRepository
    {
        string webAPIKey = "AIzaSyDof8ZDCIGYvinREfQN7HckTFgLEJTvjsw";
        FirebaseClient firebaseClient = new FirebaseClient("https://taskapp-d5e69-default-rtdb.firebaseio.com/");
        FirebaseAuthProvider authProvider;
        FirebaseAuth auth;

        public UserRepository ()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
        }

        public async Task<bool> Register(string firstname, string lastname, string email, string password)
        {
            try
            {
                var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                string a = token.FirebaseToken;

                Debug.Print(a);
                await App.Current.MainPage.DisplayAlert("Alert", "Algo esta mal: " + a, "Ok");

                return true;
            }catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Algo esta mal: " + ex.Message, "Ok"); 
                return false;
            }
        }

        public async Task<string> SignIn(string email, string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";

        }

        public async Task<bool> SaveUser(User user)
        {
            var data = await firebaseClient.Child(nameof(User)).PostAsync(JsonConvert.SerializeObject(user));
            //string token = auth.FirebaseToken;
            if (!string.IsNullOrEmpty(data.Key))
            {
                //Debug.Print(token);
                //await App.Current.MainPage.DisplayAlert("Alert", "Algo esta mal: " + ex.InnerException?.Message, "Ok");
                return true;
            }
            return false;
        }
    }
}
