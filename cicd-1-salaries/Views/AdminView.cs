
namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using System;
    using System.Collections.Generic;

    public class AdminView
    {
        private enum Nav
        {
            AccountView,
            ListUsers,
            EditAccountRequest,
            PayAccounts,
            CreateUser,
            RemoveUser,
            Exit,
        }

        public AdminView(Admin admin)
        {
            adminController = new AdminController(admin);

            Console.WriteLine($"Logged in as {admin.Name}.\n");

            NavMenu();
        }

        private AdminController adminController;

        private void NavMenu()
        {
            var exit = false;

            while (exit is false)
            {
                var nav = PromptNavigation();

                switch (nav)
                {
                    case Nav.AccountView:
                        new AccountView(adminController.Admin as Account);
                        break;
                    case Nav.ListUsers:
                        ListUsers();
                        break;
                    case Nav.EditAccountRequest:
                        EditAccountRequest();
                        break;
                    case Nav.PayAccounts:
                        PayAccounts();
                        break;
                    case Nav.CreateUser:
                        CreateUser();
                        break;
                    case Nav.RemoveUser:
                        RemoveUser();
                        break;
                    case Nav.Exit:
                        exit = true;
                        break;
                }
            }
        }

        private void ListUsers()
        {
            foreach (var user in adminController.GetAllUsers())
            {
                Console.WriteLine(user + $"\n Password: {user.Password}");
            }
            Console.WriteLine();
        }

        private void EditAccountRequest()
        {
            Console.WriteLine("Select account");

            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine();

            var requests = adminController.GetAccountRequests(name);

            if (requests.Count > 0)
            {
                Console.WriteLine("Select request");
                for (int i = 1; i < requests.Count + 1; i++)
                {
                    Console.WriteLine($" [{i}] {requests[i - 1]}");
                }
                Console.Write("> ");
                var inputIndex = PromptRequestIndex() - 1; // TODO input check
                Console.WriteLine();

                var request = requests[inputIndex];

                Console.WriteLine("Editing");
                Console.WriteLine(request + "\n");

                if (request is RoleRequest)
                {
                    request.Value = PromptAccountRole();
                }
                if (request is SalaryRequest)
                {
                    request.Value = PromptSalary();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"No requests found for user {name}.");
            }
        }

        private int PromptRequestIndex()
        {
            var input = Convert.ToInt32(Console.ReadLine());

            //return 0 < input && ; // TODO
            return input;
        }

        private void PayAccounts()
        {
            adminController.PayAccounts();

            Console.WriteLine("It's payday! All accounts has been payed.\n");
        }

        private void CreateUser()
        {
            Console.WriteLine("Create user\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            var password = PromptNewUserPassword();

            var role = PromptAccountRole();

            var salary = PromptSalary();

            Console.Write("Admin role? (y/n): ");
            var isAdmin = string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);

            var isCreated = adminController.CreateUser(name, password, role, salary, isAdmin);

            if (isCreated)
            {
                Console.WriteLine($"Created user {name}.");
            }
            else
            {
                Console.WriteLine($"Could not create user {name}, {password}, {role}.");
            }
        }

        private string PromptNewUserPassword()
        {
            Console.Write("Password: ");
            var password = Console.ReadLine();

            return IsValidPassword(password) ? password : PromptNewUserPassword();
        }

        private bool IsValidPassword(string password)
        {
            var hasLetter = false;
            var hasNumber= false;

            foreach (var chr in password)
            {
                if (char.IsLetter(chr)) hasLetter = true;
                if (char.IsNumber(chr)) hasNumber = true;
            }

            return hasLetter && hasNumber;
        }

        private int PromptSalary()
        {
            Console.Write("Salary: ");
            try
            {
                var salary = Convert.ToInt32(Console.ReadLine());
                return salary;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return PromptSalary();
            }
        }

        private Role PromptAccountRole()
        {
            Console.WriteLine("Select role");
            foreach (var roleName in Enum.GetNames(typeof(Role)))
            {
                Console.WriteLine($" [{roleName}]");
            }
            Console.Write("> ");
            var input = Console.ReadLine();
            Console.WriteLine();

            try
            {
                var role = Enum.Parse(typeof(Role), input, true);
                return (Role) role;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return PromptAccountRole();
            }
        }

        private void RemoveUser()
        {
            Console.WriteLine("Remove user\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            var isRemoved = adminController.RemoveUser(name, password);

            if (isRemoved)
            {
                Console.WriteLine($"Removed user {name}, {password}.");
            }
            else
            {
                Console.WriteLine($"Could not find user {name}, {password}.");
            }
        }

        private Nav PromptNavigation()
        {
            Console.WriteLine("Select");
            Console.WriteLine(" [1] Account view");
            Console.WriteLine(" [2] List all users");
            Console.WriteLine(" [3] Edit account request");
            Console.WriteLine(" [4] Pay accounts");
            Console.WriteLine(" [5] Create user");
            Console.WriteLine(" [6] Remove user");
            Console.WriteLine(" [E] Exit");
            Console.Write("> ");
            var input = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return input switch
            {
                "1" => Nav.AccountView,
                "2" => Nav.ListUsers,
                "3" => Nav.EditAccountRequest,
                "4" => Nav.PayAccounts,
                "5" => Nav.CreateUser,
                "6" => Nav.RemoveUser,
                "E" => Nav.Exit,
                _ => PromptNavigation(),
            };
        }
    }
}