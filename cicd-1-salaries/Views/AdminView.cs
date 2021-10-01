
namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Controllers;
    using System;
    using System;
    internal class AdminView
    {
        private enum Navigation
        {
            
        }

        private AdminController controller;

        public AdminView()
        {
            Nav();
        }

        //a. allt som account kan göra
        //b.Se aktuella användare och deras lösenord.
        //c.Se om användare har begärt ändring av roll eller lön och i så fall ändra dessa värden.
        //d.Avancera system en månad så att lön betalas ut till användare.
        //e.Admin skall kunna skapa användare lokalt. Användare skall ha användarnamn och lösenord, dessa måste bestå av både text och siffror.
        //f.Ta bort användare från systemet genom att skriva ett användarnamn och tillhörande lösenord.

        private void Nav()
        {
            var nav = PromptNavigation();

            switch (nav)
            {
                
            }
        }

        private Navigation PromptNavigation()
        {
            Console.WriteLine("Select");
            // TODO
            Console.Write("> ");
            var input = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return input switch
            {
                
                _ => PromptNavigation(),
            };
        }
    }
}