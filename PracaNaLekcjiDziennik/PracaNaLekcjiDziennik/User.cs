using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaNaLekcjiDziennik
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
