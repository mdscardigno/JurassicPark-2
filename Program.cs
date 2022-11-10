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
                        AddDinosaur(database);
                        break;
                    case "R":
                        //remove
                        RemoveDinosaur(database);
                        break;
                    case "T":
                        //transfer
                        Console.WriteLine("Transfering dinosaur");
                        break;
                    case "S":
                        //summary
                        SummarizeAllDinosaurs(database);
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
        private static void AddDinosaur(DinosaurDB database)
        {
            //Add a Dinosaur
            var dinosaur = new Dinosaur();

            //we set the properties of the dinosaur
            dinosaur.Name = PromptForString("Enter the name of the dinosaur: ");
            dinosaur.DietType = PromptForString("Enter the diet type of the dinosaur: ");
            dinosaur.WhenAcquired = DateTime.Now;
            dinosaur.Weight = PromptForInteger("Enter the weight of the dinosaur: ");
            dinosaur.EnclosureNumber = PromptForInteger("Enter the enclosure number of the dinosaur: ");
            dinosaur.Description();

            database.AddDinosaur(dinosaur);
        }
        private static void RemoveDinosaur(DinosaurDB database)
        {
            //search database for dinosaur
            //prompt user for name of dinosaur to remove
            var dinoName = PromptForString("What is the name of the dinosaur you want to remove? ");
            //remove dinosaur from database
            var dinosaurToRemove = database.FindOneDinosaur(dinoName);
            //if we did not find the dino in the database
            if (dinosaurToRemove == null)
            {
                Console.WriteLine($"Sorry. We could not find a dinosaur with the name {dinoName} within the Jurassic Park Database.");
            }
            else
            {
                //if dinosaur is found, show details of dinosaur
                Console.WriteLine($"Dinosaur named {dinosaurToRemove.Name} was found in the Jurassic Park Database.");
                Console.WriteLine($"Are you sure you want to remove {dinosaurToRemove.Name} from the Jurassic Park Database? (Y/N)");
                //if no, do nothing and return to menu
                if (Console.ReadLine().ToUpper() == "N")
                {
                    System.Console.WriteLine("Dinosaur was not removed from the Jurassic Park Database.");
                }
                //if yes, remove dinosaur from database
                else
                {
                    database.RemoveDinosaur(dinoName);
                    Console.WriteLine($"Dinosaur named {dinosaurToRemove.Name} was removed from the Jurassic Park Database.");
                }

                database.RemoveDinosaur(dinoName);
                Console.WriteLine($"{dinoName} has been removed from the database.");
            }
        }
        private static void SummarizeAllDinosaurs(DinosaurDB database)
        {
            //READ 
            //get all dinosaurs from database
            foreach (var dinosaur in database.GetAllDinosaurs())
            {
                //display each dinosaur in the database
                Console.WriteLine($"Dinosaur named {dinosaur.Name} was found in the Jurassic Park Database.");//can I display this any better?
            }
        }
    }//end of class Program
}//end of namespace JurassicPark
