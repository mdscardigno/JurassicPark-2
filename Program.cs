using System;
using System.Collections.Generic;

namespace JurassicPark
{
    class Program
    {
        //UI
        static void DisplayGreeting()
        {
            Console.WriteLine("Welcome to Jurassic Park!");
        }
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = int.TryParse(Console.ReadLine(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("That is not a valid input. Please try again.");
                return 0;
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?: (V)iew\n (A)dd\n (R)emove\n (T)ransfer\n (S)ummary\n (Q)uit");
        }


        static void Main(string[] args)
        {
            DisplayGreeting();
            //create a dinosaur

            var database = new DinosaurDB();
            var keepShowingMenu = true;
            while (keepShowingMenu)
            {
                DisplayMenu();
                var choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "V":
                        //view
                        Console.WriteLine("Viewing all dinosaurs");
                        break;
                    case "A":
                        //add
                        Console.WriteLine("Adding dinosaur");
                        break;
                    case "R":
                        //remove
                        Console.WriteLine("Removing dinosaur");
                        break;
                    case "T":
                        //transfer
                        Console.WriteLine("Transfering dinosaur");
                        break;
                    case "S":
                        //summary
                        Console.WriteLine("Describing dinosaur");
                        break;
                    case "Q":
                        //quit
                        Console.WriteLine("Exiting Jurassic Park. Good bye!");
                        keepShowingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }//end of Switch
            }//end of while loop
        }//end of Main
    }//end of class Program
}//end of namespace JurassicPark
