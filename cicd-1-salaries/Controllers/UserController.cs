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
        /// <summary>
        /// Checks if the User exist
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool IsValidLogin(string userName, string password)
        {

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                currentUser = users.FirstOrDefault(user => user.Name == userName && user.Password == password);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Logs in.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>In logged user</returns>
        public User Login(string userName, string password)
        {
            if (IsValidLogin(userName, password) is false) return null;
            return currentUser;
        }
        /// <summary>
        /// Removes user.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

    }
}