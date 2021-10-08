namespace cicd_1_salaries.Controllers
{
    using System;
    using System.Collections.Generic;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;

    public class AdminController // TODO inherit fron AccountController
    {
        public AdminController()
        {

        }
        public AdminController(Admin admin)
        {
            Admin = admin;
        }

        public Admin Admin { get; }

        public List<User> GetAllUsers()
        {
            return Database.Users;
        }

        public List<Request> GetAccountRequests(string name)
        {
            List<Request> requests = new();

            foreach (var request in Database.Requests)
            {
                if (request.User.Name == name) requests.Add(request);
            }

            return requests;
        }

        public void PayAccounts()
        {
            foreach (var user in Database.Users)
            {
                var account = user as Account;
                account.Balance += account.Salary;
            }
        }

        public bool CreateUser(string name, string password, Role role, int salary, bool isAdmin)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(password))
            {
                // User already exists.
                if (Database.Users.Find((u) => u.Name == name) is not null) return false;

                // TODO check that password contains at least one number and one letter

                if (isAdmin)
                {
                    Database.Users.Add(new Admin(name, password, role, salary));
                }
                else
                {
                    Database.Users.Add(new Account(name, password, role, salary));
                }

                return true;
            }
            return false;
        }

        public bool RemoveUser(string name, string password)
        {
            var user = Database.Users.Find((u) => u.Name == name && u.Password == password);

            if (user is null) return false;

            Database.Users.Remove(user);

            return true;
        }
    }
}
