namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum Occupation
    {
        Manager,
        Developer,
    }

    public class Account : User
    {
        public Account(string name, string password, Occupation occupation) : base(name, password)
        {
            Occupation = occupation;
        }

        public Occupation Occupation { get; set; }
        public int Salary { get; set; }
        public int Balance { get; }

        public override string ToString()
        {
            return $"{Name}\t ({Enum.GetName(Occupation)})\t @{Balance}\t +{Salary}";
        }
    }
}
