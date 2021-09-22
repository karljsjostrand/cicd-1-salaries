namespace cicd_1_salaries.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Seeder
    {
        private static List<Account> Accounts()
        {
            var accounts = new List<Account>();

            // TODO

            return accounts;
        }

        public static List<User> Users()
        {
            throw new NotImplementedException();

            var users = new List<User>();

            // TODO

            users.Add(new Admin("admin", "123"));
            users.Add(new Account(""));

            return users;
        }
    }
}
