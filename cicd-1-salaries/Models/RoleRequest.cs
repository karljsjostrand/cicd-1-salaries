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
            return $"Request made by {User.Name}\n Current role: {(User as Account)?.Role}\n Request for new role: " + Value;
        }
    }
}
