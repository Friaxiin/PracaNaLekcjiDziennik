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
            //Dodaj();
        }
        public async void Dodaj()
        {
            User u = new User()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Login = "1231231",
                Password = "admin123",
                IsTeacher = true
            };
            await App.DataBase.InsertUser(u);
            Subject subject = new Subject()
            {
                SubjectName = "Biologia"
            };
            await App.DataBase.InsertSubject(subject);
            Grade grade = new Grade()
            {
                UserId = 1,
                SubjectId = 1,
                SubjectName = "Biologia",
                Score = "5+",
                Date = DateTime.Now,
                Description = "Sprawdzian",
                Period = "Okres 1"
            };
            await App.DataBase.InsertGrade(grade);
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
            await Navigation.PushAsync(new MainPage(user));
        }
    }
}