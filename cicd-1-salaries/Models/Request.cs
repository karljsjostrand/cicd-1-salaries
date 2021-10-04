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
        public Request(User user, Subject subject, Object value)
        {
            User = user;
            Subject = subject;
            Value = value;
        }

        /// <summary>
        /// Requestee.
        /// </summary>
        public User User { get; set; }
        
        /// <summary>
        /// Concern for request.
        /// </summary>
        public Subject Subject { get; set; }

        /// <summary>
        /// Desired value in regard to subject.
        /// </summary>
        public Object Value { get; set; }
    }
}
