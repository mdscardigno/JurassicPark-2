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
            Console.WriteLine("What would you like to do?:\n (V)iew\n (A)dd\n (R)emove\n (T)ransfer\n (S)ummary\n (Q)uit");
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
                        //does the user want to see the dinosaurs in alphabetical order or by enclosure number?
                        Console.WriteLine("Would you like to see the dinosaurs in (A)lphabetical order or by (E)nclosure number?");
                        var viewChoice = Console.ReadLine().ToUpper();
                        if (viewChoice == "A")
                        {
                            // database.ViewDinosaursAlphabetically();
                            Console.WriteLine("Viewing all dinosaurs Alphabetically");
                        }
                        else if (viewChoice == "E")
                        {
                            // database.ViewDinosaursByEnclosure();
                            Console.WriteLine("Viewing all dinosaurs ByEnclosure");
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid input. Please try again.");
                        }

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
                        TransferDinosaur(database);
                        break;
                    case "S":
                        //summary of all carnivore and herbivore
                        Console.WriteLine("Viewing summary of all carnivores and herbivores");
                        //is it carnivore or herbivore? //make a method for this
                        //print the total of carnivore and herbivores

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
                //sort by diet type (carnivore or herbivore)
                //display total number of carnivores and herbivores
                //sort alphabetically
                Console.WriteLine($"Dinosaur named {dinosaur.Name} was found in the Jurassic Park Database.");//can I display this any better?
            }
        }
        private static void TransferDinosaur(DinosaurDB database)
        {
            //prompt for the name of the dinosaur to transfer
            var dinosaurNameToTransfer = PromptForString("What is the name of the dinosaur you want to transfer? ");
            //search database for the dinoNameToTransfer and return the dinosaur
            Dinosaur foundDinosaur = database.FindOneDinosaur(dinosaurNameToTransfer);
            //if we did not find the dino in the database
            if (foundDinosaur == null)
            {
                Console.WriteLine($"Sorry. We could not find a dinosaur with the name {dinosaurNameToTransfer} within the Jurassic Park Database.");
                Console.WriteLine("Would you like to add the dinosaur you are searching for to the Jurassic Park Database? (Y/N)");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    AddDinosaur(database);
                }
                else
                {
                    Console.WriteLine("Dinosaur was not added to the Jurassic Park Database.");
                }
            }
            else
            {
                //if dinosaur is found, show details of dinosaur
                Console.WriteLine($"Dinosaur named {foundDinosaur.Name} was found in enclosure number: {foundDinosaur.EnclosureNumber} of the Jurassic Park Database.");
                //prompt for new enclosure number
                var newEnclosureNumber = PromptForInteger("What is the new enclosure number you want to transfer the dinosaur to? ");
                //is the new enclosure number valid?
                if (newEnclosureNumber < 1 || newEnclosureNumber > 100)
                {
                    Console.WriteLine("Sorry. That is not a valid enclosure number. Please try again.");
                }
                else
                {
                    //if yes, transfer dinosaur to new enclosure number
                    foundDinosaur.EnclosureNumber = newEnclosureNumber;
                    //display the dinosaur's new enclosure number
                    Console.WriteLine($"Dinosaur named {foundDinosaur.Name} was transferred to enclosure number: {foundDinosaur.EnclosureNumber} of the Jurassic Park Database.");
                }
            }
            //prompt for the new enclosure number

        }
    }//end of class Program
}//end of namespace JurassicPark
