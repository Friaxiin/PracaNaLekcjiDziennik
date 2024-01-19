using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracaNaLekcjiDziennik
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.user = user;
            //dodaj();
            UploadData();
        }
        User user;

        public async void dodaj()
        {
            //User x = new User()
            //{
            //    Name = "Marcin",
            //    Surname = "Gawron",
            //    Login = "000001n",
            //    Password = "admin123",
            //    IsTeacher = true
            //};
            //await App.Database.InsertUser(x);
            //Subject sbj = new Subject()
            //{
            //    Name = "Programowanie"
            //};
            //await App.Database.InsertSubject(sbj);
            //Score s = new Score()
            //{
            //    User_id = 1,
            //    Subject_id = 1,
            //    Subject_name = "Programowanie",
            //    Value = "5+",
            //    Date = DateTime.Now,
            //    Description = "Sprawdzian",
            //    Period = "Okres 1"
            //};
            //await App.Database.InsertScore(s);
        }

        public async void UploadData()
        {
            LV_UserScores.ItemsSource = await App.DataBase.GetGrades();

            List<List<string>> period1_Scories = new List<List<string>>();
            List<List<string>> period2_Scories = new List<List<string>>();

            var subjects = await App.DataBase.GetSubjects();
            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var scoriesPeriodOne = await App.DataBase.GetScories(this.user.UserId, subject.SubjectId, "Okres 1");
                string scoriesPeriodOneText = "";
                foreach (var score in scoriesPeriodOne)
                {
                    scoriesPeriodOneText += score.Score + " ";
                }
                row.Add(scoriesPeriodOneText);
                row.Add(subject.SubjectName);

                period1_Scories.Add(row);
            }

            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var scoriesPeriodTwo = await App.DataBase.GetScories(this.user.UserId, subject.SubjectId, "Okres 2");
                string scoriesPeriodTwoText = "";
                foreach (var score in scoriesPeriodTwo)
                {
                    scoriesPeriodTwoText += score.Score + " ";
                }
                row.Add(scoriesPeriodTwoText);
                row.Add(subject.SubjectName);

                period2_Scories.Add(row);
            }

            LV_UserScores_Period_1.ItemsSource = period1_Scories;
            LV_UserScores_Period_2.ItemsSource = period2_Scories;
        }

    }
}
