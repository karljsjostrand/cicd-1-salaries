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
    class AccountControllerTests
    {
        private List<Account> users;
        private Account admin;
        private Account user;
        private AccountController accountController;

        [SetUp]
        public void SetUp()
        {
            accountController = new AccountController();

            admin = new Admin("admin1", "Admin@123", Role.Developer, 1);
            user = new Account("Mohammad", "Passw0rd@123");

            users = new List<Account>()
            {
            admin,
            user,
            };

            Database.Users.AddRange(users);
        }

        [Test]
        public void LoginAsAdmin_Test()
        {
            var name = "admin1";
            var password = "Admin@123";

            var actual = accountController.Login(name, password);

            Assert.AreEqual(actual.Name, name);
            Assert.AreEqual(actual.Password, password);
        }

        [Test]
        public void NotExistUser_Test()
        {
            var name = "NotExist";
            var password = "123123";

            var actual = accountController.Login(name, password);
            Assert.IsNull(actual);
        }
    }
}
