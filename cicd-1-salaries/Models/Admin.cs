namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Admin : Account
    {
        public Admin(string name, string password, Role occupation) : base(name, password, occupation)
        {
        }
    }
}
