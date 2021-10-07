namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SalaryRequest : Request
    {
        public SalaryRequest(User user, int newSalary) : base(user, newSalary)
        {
        }

        public override string ToString()
        {
            var str = $"Request made by {User.Name}";
            str += $" | Current salary: {(User as Account)?.Salary}";
            str += " | Requesting for new salary: " + Value;
            return str;
        }
    }
}
