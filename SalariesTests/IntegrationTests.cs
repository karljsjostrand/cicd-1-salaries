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

        [SetUp]
        public void SetUp()
        {
            accountController = new AccountController();
        }

        /// <summary>
        /// Log in as currently stored user admin1, create a new user, pay all
        /// accounts, and assert that the new users balance has been payed.
        /// </summary>
        [Test]
        public void Login_Then_CreateUser_Then_PayAccounts_Test()
        {
            // log in as admin1
            admin1 = accountController.Login("admin1", "admin1234") as Admin;

            adminController = new AdminController(admin1);

            var newUserName = "admin2";

            // create a new user
            adminController.CreateUser(newUserName, "admin2345", Role.Developer, 2222, true);

            var newUserAccount = Database.Users.Find((u) => u.Name == newUserName) as Account;

            var previousNewUserBalance = newUserAccount.Balance;
            var expectedNewUserBalance = previousNewUserBalance + newUserAccount.Salary;

            // pay all accounts
            adminController.PayAccounts();

            var actualAdmin2Balance = newUserAccount.Balance;

            // assert that new users balance is as expected after payed. 
            Assert.AreEqual(expectedNewUserBalance, actualAdmin2Balance);
        }
    }
}
