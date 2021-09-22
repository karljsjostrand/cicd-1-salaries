namespace cicd_1_salaries.Controllers
{
    using cicd_1_salaries.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Salaries
    {
        private List<User> users;
        private User activeUser;

        private bool IsValidUser(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(string userName)
        {
            throw new NotImplementedException();

            //if (activeUser is not Admin && activeUser.Name is not userName) return false;
        }

        public Account GetAccount(string "admin", string password)
        {
            throw new NotImplementedException();

            return new Admin();

            if (IsValidUser(name, password) is false) return null;
        }

        public User Login(string name, string password)
        {
            throw new NotImplementedException();

            if (IsValidUser(name, password) is false) return null;
        }
    }
}
