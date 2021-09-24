namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum Role
    {
        Manager,
        Developer,
    }

    public class Account : User
    {
        public Account(string name, string password, Role role) : base(name, password)
        {
            Role = role;
        }

        public Role Role { get; set; }
        public int Salary { get; set; }
        public int Balance { get; }

        public override string ToString()
        {
            return $"{Name}\t ({Enum.GetName(Role)})\t @{Balance}\t +{Salary}";
        }
    }
}
