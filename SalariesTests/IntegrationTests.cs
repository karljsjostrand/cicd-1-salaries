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
        }

        /// <summary>
        /// Integration test for AdminController.PayAccounts().
        /// Log in as currently stored user admin1, create a new user, pay all
        /// accounts, and assert that the new users balance has been payed.
        /// </summary>
        [Test]
        public void Login_Then_CreateUser_Then_PayAccounts_Test()
        {
            accountController = new AccountController();

            // Log in as admin1.
            admin1 = accountController.Login("admin1", "admin1234") as Admin;

            adminController = new AdminController(admin1);

            // Create a new user.
            var newAdminName = "admin2";
            adminController.CreateUser(newAdminName, "admin2345", Role.Developer, 2222, true);

            newAdmin = Database.Users.Find((u) => u.Name == "admin2") as Admin;

            var expectedNewUserBalance = newAdmin.Balance + newAdmin.Salary;

            // Pay all accounts.
            adminController.PayAccounts();

            // Assert that new users balance is increased as expected after payed. 
            var actualNewUserBalance = newAdmin.Balance;

            Assert.AreEqual(expectedNewUserBalance, actualNewUserBalance);
        }
    }
}
