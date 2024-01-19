using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaNaLekcjiDziennik
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
