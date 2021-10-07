namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RoleRequest : Request
    {
        public RoleRequest(User user, Role role) : base(user, role)
        {
        }

        public override string ToString()
        {
            var str = $"Request made by {User.Name}";
            str += $" | Current role: {(User as Account)?.Role}";
            str += " | Requesting for new role: " + Value;
            return str;
        }
    }
}
