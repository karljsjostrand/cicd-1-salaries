namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SalaryRequest : Request
    {
        public SalaryRequest(Account account, int newSalary) : base(account, newSalary)
        {
        }

        public override string ToString()
        {
            return $"Request made by {Account.Name}\n Current salary: {Account.Salary}\n Request for new salary: " + Value;
        }
    }
}
