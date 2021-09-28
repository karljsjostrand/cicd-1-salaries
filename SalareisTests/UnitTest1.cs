using cicd_1_salaries.Controllers;
using cicd_1_salaries.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace SalareisTests
{
    public class Tests
    {
        private List<User> users;
        private User admin1;

        [SetUp]
        public void Setup()
        {
            admin1 = new Admin("admin1", "111", Role.Developer);

            users = new List<User>()
            {
                admin1,
            };

            Salaries.Users = users;
        }

        [Test]
        public void Test_LoginAdmin1()
        {
            var name = "admin1";
            var pw = "111";

            var actual = Salaries.Login(name, pw);

            Assert.AreEqual(actual.Name, name);
            Assert.AreEqual(actual.Password, pw);
        }

        [Test]
        public void Test_LoginNonExistentUser()
        {
            var name = "nonexistent";
            var pw = "something";

            var actual = Salaries.Login(name, pw);

            Assert.IsNull(actual);
        }
    }
}