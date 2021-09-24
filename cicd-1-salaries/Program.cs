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
            new LoginView();

            var users = Seeder.Users();

            var karl = users.Find((u) => string.Equals(u.Name, "Karl", StringComparison.OrdinalIgnoreCase));
            var admin = users.Find((u) => string.Equals(u.Name, "admin1", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine();
            Console.WriteLine(karl);
            Console.WriteLine(admin);
        }
    }
}
