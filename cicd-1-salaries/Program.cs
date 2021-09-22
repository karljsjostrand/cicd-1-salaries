namespace cicd_1_salaries
{
	using cicd_1_salaries.Controllers;
	using cicd_1_salaries.Models;
    using System;

    internal static class Program
    {
        private static void Main()
        {
            var salaries = new Salaries();

            var user = new Account("Karl", "123", Occupation.Developer);
        }
    }
}
