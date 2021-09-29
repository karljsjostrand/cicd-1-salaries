namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum Subject
    {
        Role,
        Salary,
    }

    public class Request
    {
        public User User { get; set; }
        public Subject Subject { get; set; }
        public Object Value { get; set; } // Account.Role eller ny lön
    }
}
