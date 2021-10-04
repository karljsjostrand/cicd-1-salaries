namespace cicd_1_salaries.Controllers
{
    using cicd_1_salaries.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Salaries
    {
        public static List<User> Users { get; set; }

        private static bool IsValidLogin(string name, string password)
        {
            return true; // TODO
        }

        public static bool RemoveUser(string userName)
        {
            return false; // TODO
        }

        public static User Login(string name, string password)
        {
            if (IsValidLogin(name, password) is false) return null;

            var user = Users.Find((u) => u.Name == name && u.Password == password);

            return user;
        }
    }
}
