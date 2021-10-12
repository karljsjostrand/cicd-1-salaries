using System;
using System.Collections.Generic;
using System.Linq;
using cicd_1_salaries.Models;
using cicd_1_salaries.Models.Data;

namespace cicd_1_salaries.Controllers
{
    public class AccountController
    {
        public AccountController(Account account)
        {
            Account = account;
        }

        public Account Account { get; private set; }

        /// <summary>
        /// Log in user account to controller.
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="password">User password</param>
        /// <returns>User object matching <paramref name="name"/> and <paramref name="password"/>.</returns>
        public User Login(string name, string password)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
            {
                Account = Database.Users.FirstOrDefault(user => user.Name == name && user.Password == password) as Account;
            }

            return Account;
        }

        /// <summary>
        /// Store request.
        /// </summary>
        /// <param name="request">Request to be stored.</param>
        public void CreateRequest(Request request)
        {
            Database.Requests.Add(request);
        }

        /// <summary>
        /// Remove logged in account from the database.
        /// </summary>
        /// <returns>true if account is removed, otherwise false.</returns>
        public bool RemoveAccount()
        {
            return Database.Users.Remove(Account);
        }

    }
}

