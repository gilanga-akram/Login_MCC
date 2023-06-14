using System;
using System.Collections.Generic;

class UserHandler
{
    private static List<string> users = new List<string>();

    public static void CreateUser()
    {
        // Code to create a new user
        Console.WriteLine("Creating a new user...");
        // ...
    }

    public static void ShowUser()
    {
        // Code to display all existing users
        Console.WriteLine("Displaying all users...");

        if (users.Count == 0)
        {
            Console.WriteLine("No users found.");
            return;
        }

        Console.WriteLine("User List:");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i]}");
        }

        Console.WriteLine();

        // Display additional options
        Console.WriteLine("Additional Options:");
        Console.WriteLine("1. Edit User");
        Console.WriteLine("2. Delete User");
        Console.WriteLine("3. Back");

        // Get user input
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        // Process additional user choice
        switch (choice)
        {
            case "1":
                EditUser();
                break;
            case "2":
                DeleteUser();
                break;
            case "3":
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    public static void SearchUser()
    {
        // Code to search for a specific user
        Console.WriteLine("Searching for a user...");
        // ...
    }

    public static void LoginUser()
    {
        // Code to authenticate and log in a user
        Console.WriteLine("Logging in a user...");
        // ...
    }

    private static void EditUser()
    {
        // Code to edit a user
        Console.WriteLine("Editing a user...");
        // ...
    }

    private static void DeleteUser()
    {
        // Code to delete a user
        Console.WriteLine("Deleting a user...");
        // ...
    }
}
