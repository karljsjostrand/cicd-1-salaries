namespace cicd_1_salaries.Controllers
{
    using System;
    using System.Collections.Generic;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;

    public class AdminController
    {
        /// <summary>
        /// Creates a new object of AdminController.
        /// </summary>
        /// <param name="admin">Signed in administrating account.</param>
        public AdminController(Admin admin)
        {
            Admin = admin;
        }

        /// <summary>
        /// Signed in admin account.
        /// </summary>
        public Admin Admin { get; }

        /// <summary>
        /// Get all stored users.
        /// </summary>
        /// <returns>All user objects.</returns>
        public List<User> GetAllUsers()
        {
            return Database.Users;
        }

        /// <summary>
        /// Get all requests made by user.
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns>All stored request objects made by user.</returns>
        public List<Request> GetAccountRequests(string name)
        {
            List<Request> requests = new();

            foreach (var request in Database.Requests)
            {
                if (request.Account.Name == name) requests.Add(request);
            }

            return requests;
        }

        /// <summary>
        /// Increase all accounts balances with their salaries.
        /// </summary>
        public void PayAccounts()
        {
            foreach (var user in Database.Users)
            {
                if (user is Account)
                {
                    var account = user as Account;
                    account.Balance += account.Salary;
                }
            }
        }

        /// <summary>
        /// Create a new user account.
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="password">User password</param>
        /// <param name="role">User role</param>
        /// <param name="salary">User salary</param>
        /// <param name="isAdmin">Whether the account should have admin privileges.</param>
        /// <returns>true if user account was created, otherwise false.</returns>
        public bool CreateUser(string name, string password, Role role, int salary, bool isAdmin)
        {
            // if name and password is not empty.
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(password))
            {
                // Don't create if user already exists.
                if (AccountExists(name)) return false;
                                
                if (isAdmin)
                {
                    Database.Users.Add(new Admin(name, password, role, salary));
                }
                else
                {
                    Database.Users.Add(new Account(name, password, role, salary));
                }

                // User was created.
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove user found matching user details.
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="password">User password</param>
        /// <returns>true if user was removed, otherwise false.</returns>
        public bool RemoveUser(string name, string password)
        {
            var user = Database.Users.Find((u) => u.Name == name && u.Password == password);

            if (user is null) return false;

            Database.Users.Remove(user);

            return true;
        }

        private bool AccountExists(string name)
        {
            if (Database.Users.Find((u) => u.Name == name) is not null) return true;

            return false;
        }

        /// <summary>
        /// Checks whether admin account is in database.
        /// </summary>
        /// <returns>true if admin account exists, otherwise false.</returns>
        public bool AdminAccountExists()
        {
            return AccountExists(Admin.Name);
        }
    }
}
