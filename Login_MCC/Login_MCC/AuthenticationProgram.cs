using System;

class AuthenticationProgram
{
    public static void Run()
    {
        while (true)
        {
            // Display menu options
            Console.WriteLine("=== BASIC AUTHENTICATION ===");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Exit");

            // Get user input
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            // Process user choice
            switch (choice)
            {
                case "1":
                    UserHandler.CreateUser();
                    break;
                case "2":
                    UserHandler.ShowUser();
                    break;
                case "3":
                    UserHandler.SearchUser();
                    break;
                case "4":
                    UserHandler.LoginUser();
                    break;
                case "5":
                    ExitProgram();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ExitProgram()
    {
        // Code to exit the program
        Console.WriteLine("Exiting the program...");
        // ...
    }
}
