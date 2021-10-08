namespace SalariesTests
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    class IntegrationTests
    {
        private Admin admin1;
        private AdminController adminController;
        private AccountController accountController;
        private Admin newAdmin;

        [SetUp]
        public void SetUp()
        {
            accountController = new AccountController();
            adminController = new AdminController();
        }

        /// <summary>
        /// Log in as currently stored user admin1, create a new user, pay all
        /// accounts, and assert that the new users balance has been payed.
        /// </summary>
        [Test]
        public void Login_Then_CreateUser_Then_PayAccounts_Test()
        {

            // Log in as admin1.
            admin1 = accountController.Login("admin1", "admin1234") as Admin;

             adminController = new AdminController(admin1);

            // Create a new admin.
            var newAdminName = "admin2";
            adminController.CreateUser(newAdminName, "admin2345", Role.Developer, 2222, true);

            newAdmin = Database.Users.Find((u) => u.Name == "admin2") as Admin;

            var previousNewUserBalance = newAdmin.Balance;
            var expectedNewUserBalance = previousNewUserBalance + newAdmin.Salary;

            // Pay all accounts.
            adminController.PayAccounts();

            var actualAdmin2Balance = newAdmin.Balance;

            // Assert that new users balance is as expected after payed. 
            Assert.AreEqual(expectedNewUserBalance, actualAdmin2Balance);
        }
    }
}
