using System;
using System.Collections.Generic;
using System.Linq;
using cicd_1_salaries.Models;
using cicd_1_salaries.Models.Data;

namespace cicd_1_salaries.Controllers
{
    public class UserController
    {

        private static List<User> users = Seeder.Users();

        private User currentUser;
        private int myProperty;

        private bool IsUserActive { get; set; }

        private bool IsValidLogin(string userName, string password)
        {

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                currentUser = users.FirstOrDefault(user => user.Name == userName && user.Password == password);
                return true;
            }
            return false;

        }
        public User Login(string userName, string password)
        {
            if (IsValidLogin(userName, password) is false) return null;
            return currentUser;
        }

        public bool RemoveUser(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                currentUser = users.FirstOrDefault(user => user.Name == userName && user.Password == password);
                users.Remove(currentUser);
                return true;
            }
            return false;
        }
 
        public int MyProperty { get => myProperty; set => myProperty = value; }




    }
}