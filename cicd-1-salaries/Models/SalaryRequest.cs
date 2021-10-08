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
            var str = $"Request made by {Account.Name}";
            str += $" | Current salary: {Account.Salary}";
            str += " | Requesting for new salary: " + Value;
            return str;
        }
    }
}
