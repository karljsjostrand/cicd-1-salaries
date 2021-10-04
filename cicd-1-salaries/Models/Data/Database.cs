namespace cicd_1_salaries.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Database
    {
        private static List<User> users;
        private static List<Request> requests;

        public static List<User> Users
        {
            get
            {
                if (users is null) SeedData();
                return users;
            }
        }


        public static List<Request> Requests 
        {
            get
            {
                if (requests is null) SeedData();
                return requests;
            }
        }

        private static void SeedData()
        {
            users = new List<User>();
            requests = new List<Request>();

            #region Users
            var admin1 = new Admin("admin1", "admin1234", Role.Manager, 2200);

            users.Add(admin1);

            var adam = new Account("Adam", "abc234", Role.Developer, 2000);

            users.Add(adam);
            #endregion

            #region Requests
            requests.Add(new Request(adam, Subject.Salary, 2500));
            #endregion

        }
    }
}
