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
            return $"Request made by {User.Name}\n Current salary: {(User as Account)?.Salary}\n Request for new salary: " + Value;
        }
    }
}
