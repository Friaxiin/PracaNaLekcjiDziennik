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
        public MainPage(User user)
        {
            InitializeComponent();
            this.user = user;
            
            UploadData();
        }
        User user;

        public async void UploadData()
        {
            UserScores.ItemsSource = await App.DataBase.GetGrades();
            List<Subject> subjectsList = new List<Subject>();

            List<List<string>> period1Grades = new List<List<string>>();
            List<List<string>> period2Grades = new List<List<string>>();

            var subjects = await App.DataBase.GetSubjects();
            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var GradesPeriodOne = await App.DataBase.GetGrades(this.user.UserId, subject.SubjectId, "Okres 1");
                string GradesPeriodOneText = "";
                foreach (var score in GradesPeriodOne)
                {
                    GradesPeriodOneText += score.Score + " ";
                }
                row.Add(GradesPeriodOneText);
                row.Add(subject.SubjectName);

                period1Grades.Add(row);
            }

            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var GradesPeriodTwo = await App.DataBase.GetGrades(this.user.UserId, subject.SubjectId, "Okres 2");
                string GradesPeriodTwoText = "";
                foreach (var score in GradesPeriodTwo)
                {
                    GradesPeriodTwoText += score.Score + " ";
                }
                row.Add(GradesPeriodTwoText);
                row.Add(subject.SubjectName);

                period2Grades.Add(row);

                subjectsList.Add(subject);
            }

            UserGradesPeriod1.ItemsSource = period1Grades;
            UserGradesPeriod2.ItemsSource = period2Grades;

            SubjectNamePicker.ItemsSource = subjectsList;
        }
        public async void AddGrade()
        {

        }
    }
}
