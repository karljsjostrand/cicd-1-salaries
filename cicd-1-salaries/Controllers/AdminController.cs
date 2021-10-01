namespace cicd_1_salaries.Controllers
{
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class AdminController
    {
        public List<User> GetAllUsers()
        {
            return Database.Users;
        }

        public List<Request> GetAccountRequests(string name)
        {
            List<Request> requests = new List<Request>();

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
        
        public bool CreateUser(string name, string password, Role role, bool isAdmin)
        {
            // User does not exist.
            if (Database.Users.Find((u) => u.Name == name) is not null) return false;

            if (isAdmin)
            {
                Database.Users.Add(new Admin(name, password, role));
            }
            else
            {
                Database.Users.Add(new Account(name, password, role));
            } 

            return true;
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
