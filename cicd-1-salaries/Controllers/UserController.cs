namespace cicd_1_salaries.Controllers
{
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserController
    {
        /// <summary>
        /// Finds corresponding user object for log in details.
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="password">User password</param>
        /// <returns>User object matching <paramref name="name"/> and <paramref name="password"/>.</returns>
        public User Login(string name, string password)
        {
            return Database.Users.FirstOrDefault((u) => u.Name == name && u.Password == password);
        }
    }
}
