
namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using System;
    using System.Collections.Generic;

    internal class AdminView
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

        //c.Se om användare har begärt ändring av roll eller lön och i så fall ändra dessa värden.
        //d.Avancera system en månad så att lön betalas ut till användare.
        //e.Admin skall kunna skapa användare lokalt. Användare skall ha användarnamn och lösenord, dessa måste bestå av både text och siffror.
        //f.Ta bort användare från systemet genom att skriva ett användarnamn och tillhörande lösenord.

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

            var requests = adminController.GetAccountRequests(name);

            Console.WriteLine("Select request");
            for (int i = 0; i < requests.Count; i++)
            {
                Console.WriteLine($" [{i}] {requests[i]}");
            }
            Console.Write("> ");
            var input = Console.ReadLine() == string.Empty;
            var inputIndex = Convert.ToInt32(input);

            var request = requests[inputIndex];

            Console.WriteLine("Editing request: " + request + "\n");
            // TODO allow for editing the request, EditRequestView?
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

            Console.Write("Password: ");
            var password = Console.ReadLine();

            Console.Write("Role: ");
            var role = PromptAccountRole();

            Console.Write("Salary: ");
            var salary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Admin role? (y/n): ");
            var isAdmin = Console.ReadLine() == "y" ? true : false;

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

        private Role PromptAccountRole()
        {
            //var roles = Enum.GetValues(typeof(Role));

            //var roles = new Dictionary<int, Role>();

            //foreach (var role in Enum.GetNames(typeof(Role)))
            //{
            //    roles.Add(roles.Count + 1, role);
            //}

            //for (int i = 1; i <= roles.Length; i++)
            //{
            //    Console.WriteLine($" [{i}] {roles.GetValue(i)}");
            //}

            Console.WriteLine("Select role");
            Console.WriteLine($" {Enum.GetName(Role.Manager)}");
            Console.WriteLine($" {Enum.GetName(Role.Developer)}");
            Console.Write("> ");
            var input = Console.ReadLine();
            Console.WriteLine();

            var role = Enum.Parse(typeof(Role), input, true);

            if (role is not null)
            {
                return (Role) role;
            }
            
            return PromptAccountRole();
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