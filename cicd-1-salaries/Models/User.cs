namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; }
        public string Password { get; }
    }
}


