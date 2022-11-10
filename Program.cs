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
        static void DisplayMenu()
        {
            Console.WriteLine("1. View all dinosaurs");
            Console.WriteLine("2. Add a dinosaur");
            Console.WriteLine("3. Remove a dinosaur");
            Console.WriteLine("4. Transfer a dinosaur");
            Console.WriteLine("5. View heaviest dinosaur");
            Console.WriteLine("6. View diet type");
            Console.WriteLine("7. Exit");
        }


        static void Main(string[] args)
        {
            DisplayGreeting();
            //create a dinosaur

            // var database = new DinoDB();
            //view add remove transfer summary or quit

            DisplayMenu();
        }
    }
}
