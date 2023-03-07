using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }


        public static void CreateAdmin()
        {
            using (var db = new ApplicationContext())
            {
                var user = new User { Login = "Admin", PasswordHash = "Admin" };
                db.Users.Add(user);
                db.SaveChanges();
            }

        }
        public static User LogIn(string login, string password)
        {
            using (var db = new ApplicationContext())
            {
                try {
                    var users = db.Users.Where(u => u.Login == login && u.PasswordHash == password);
                    return users.Count() == 1 ? users.First() : null;
                }
                catch
                {
                    return null;
                }
                
            }
        }
    }
}
