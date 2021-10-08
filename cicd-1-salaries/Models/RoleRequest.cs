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
            return $"Request made by {Account.Name}\n Current role: {Account.Role}\n Request for new role: " + Value;
        }
    }
}
