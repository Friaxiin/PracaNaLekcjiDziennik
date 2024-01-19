using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracaNaLekcjiDziennik
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection _database;

        public DataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public Task<User> FilterUsers(string login, string password)
        {
            var data = _database.Table<User>().Where(u => u.Login == login && u.Password == password).FirstOrDefaultAsync();
            return data;
        }

        public Task<int> AddUser(User user) 
        {
            return _database.InsertAsync(user);
        }
    }
}
