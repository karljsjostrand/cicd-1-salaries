namespace cicd_1_salaries
{
	using cicd_1_salaries.Controllers;
	using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using cicd_1_salaries.Views;
    using System;
    using System.Collections.Generic;

    internal static class Program
    {
        private static void Main()
        {
            //new LoginView(); // TODO uncomment

            var admin = Database.Users.Find((u) => u.Name == "admin1") as Admin; // TODO remove
            var aC = new AdminController(admin); // TODO remove
            new AdminView(aC); // TODO remove
        }
    }
}
