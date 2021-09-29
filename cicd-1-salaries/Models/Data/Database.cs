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

        public static List<User> Users
        {
            get
            {
                if (users is null) users = SeedUsers();
                return users;
            }
        }

        public static List<Request> Requests { get; set; }
        private static List<User> SeedUsers()
        {
            var users = new List<User>();

            users.Add(new Admin("admin1", "1234", Role.Manager));
            users.Add(new Account("Karl", "2345", Role.Developer));

            return users;
        }
    }
}
