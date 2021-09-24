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
        private static List<User> users;
        private static User activeUser;

        private static bool IsValidLogin(string name, string password)
        {
            throw new NotImplementedException();
        }

        public static bool RemoveUser(string userName)
        {
            return false;
            //if (activeUser is not Admin && activeUser.Name is not userName) return false;
        }

        public static Account GetAccount(string name, string password)
        {
            throw new NotImplementedException();
        }

        public static User Login(string name, string password)
        {
            throw new NotImplementedException();

            if (IsValidLogin(name, password) is false) return null;
        }
    }
}
