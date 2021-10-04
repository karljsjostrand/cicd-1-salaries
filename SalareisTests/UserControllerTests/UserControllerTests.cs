using System.Collections.Generic;
using cicd_1_salaries.Controllers;
using cicd_1_salaries.Models;
using cicd_1_salaries.Models.Data;
using NUnit.Framework;

namespace SalareisTests
{
    [TestFixture]
    public class UserControllerTests
    {

        private List<User> users;
        private User admin;
        private User user;

        [SetUp]
        public void Setup()
        {
            admin = new Admin("admin1", "Admin@123", Role.Developer, 1);
            user = new User("Mohammad", "Passw0rd@123");

            users = new List<User>()
            {
                admin,user
            };
            UserController.users = users;
        }

        [Test]
        public void LoginAsAdmin_Test()
        {
            var name = "admin1";
            var password = "Admin@123";

            var actual = UserController.Login(name, password);

            Assert.AreEqual(actual.Name, name);
            Assert.AreEqual(actual.Password, password);
        }
        [Test]
        public void NotExistUser_Test()
        {
            var name = "NotExist";
            var password = "123123";

            var actual = UserController.Login(name, password);
            Assert.IsNull(actual);
        }
        [Test]
        public void RemoveUser_Test()
        {
            var name = "Mohammad";
            var password = "Passw0rd@123";
            var actual = UserController.RemoveUser(name, password);
            Assert.IsTrue(actual);

        }
        [Test]
        public void RemoveNotExistUser_Test()
        {
            var name = "Abcdef";
            var password = "Passw0rd@123";
            var expected = false;
            var actual = UserController.RemoveUser(name, password);
            Assert.AreEqual(expected, actual);

        }

    }
}