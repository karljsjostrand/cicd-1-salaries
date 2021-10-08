namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RoleRequest : Request
    {
        public RoleRequest(Account account, Role role) : base(account, role)
        {
        }

        public override string ToString()
        {
            var str = $"Request made by {Account.Name}";
            str += $" | Current role: {Account.Role}";
            str += " | Requesting for new role: " + Value;
            return str;
        }
    }
}
