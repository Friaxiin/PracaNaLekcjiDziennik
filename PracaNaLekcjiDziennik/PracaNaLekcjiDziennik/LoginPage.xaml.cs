using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaNaLekcjiDziennik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            User user = new User();
            user.Login = "123";
            user.Password = "123";
            App.DataBase.AddUser(user);
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            var users = await App.DataBase.FilterUsers(loginEntry.Text, passwordEntry.Text);
            if (loginEntry.Text.Length != 7 || users.Count == 0)
            {
                await DisplayAlert("Błąd", "Podano nieprawidlowe dane", "OK");
                return;
            }

            var user = users.ElementAt(0);
            Navigation.PushAsync(new MainPage(user));
        }
    }
}