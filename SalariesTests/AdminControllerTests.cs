namespace SalariesTests
{
    using System;
    using System.Collections.Generic;
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using NUnit.Framework;

    [TestFixture]
    public class AdminControllerTests
    {
        private List<User> users;
        private User admin;
        private User user;
        private Account account;
        private AdminController adminController;
        [SetUp]
        public void SetUp()
        {
            admin = new Admin("admin1", "Admin@123", Role.Developer, 1);
            user = new User("Mohammad", "Passw0rd@123");
            account = new Account("User", "User@123", Role.Developer, 2100);

            adminController = new AdminController();

            users = new List<User>()
            {
            admin,
            user,
            account
            };

            Database.Users.AddRange(users);

        }

        [Test]
        public void GetAccountRequests_Test()
        {
            adminController.GetAccountRequests("Mohammad");
            Assert.Fail();

        }
        [Test]
        public void CreateUser_Test()
        {
            var actual = adminController.CreateUser("Bill", "User@123", Role.Developer, 2100, true);
            Assert.IsTrue(actual);
        }
        [Test]
        public void CreateAlreadyExistsUser_Test()
        {
            var actual = adminController.CreateUser("User", "User@123", Role.Developer, 2100, true);
            Assert.IsFalse(actual);
        }
        [Test]
        public void CreateEmptyUser_Test()
        {
            var actual = adminController.CreateUser("", "", Role.Developer, 1, true);
            Assert.IsFalse(actual);
        }
        [Test]
        public void RemoveUser_Test()
        {
            var name = "Mohammad";
            var password = "Passw0rd@123";
            var actual = adminController.RemoveUser(name, password);
            Assert.IsTrue(actual);

        }

        [Test]
        public void RemoveNotExistUser_Test()
        {
            var name = "Abcdef";
            var password = "Passw0rd@123";
            var actual = adminController.RemoveUser(name, password);
            Assert.IsFalse(actual);

        }

    }
}