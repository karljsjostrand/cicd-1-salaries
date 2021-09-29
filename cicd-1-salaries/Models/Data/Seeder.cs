namespace cicd_1_salaries.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Seeder
    {
        public static List<User> Users()
        {
            var users = new List<User>();

            users.Add(new Admin("admin1", "1234", Occupation.Manager));
            users.Add(new Account("Karl", "2345", Occupation.Developer));
            users.Add(new User("Mohammad", "1244"));

            return users;
        }
    }
}
