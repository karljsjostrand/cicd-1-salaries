namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Request
    {
        public Request(User user, Object value)
        {
            User = user;
            Value = value;
        }

        /// <summary>
        /// Requestee.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Desired value in regard to what is requested.
        /// </summary>
        public Object Value { get; set; }
    }
}
