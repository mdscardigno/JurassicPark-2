using System;

namespace JurassicPark
{
    public class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }//carnivore or herbivore?
        public DateTime WhenAcquired { get; set; }//the date and time it was created
        public int Weight { get; set; }//how heavy in pounds
        public int EnclosureNumber { get; set; }//which pen number it is in
        public void Description()
        {
            Console.WriteLine($"{Name} is a {DietType} dinosaur that weighs {Weight} pounds and was acquired on {WhenAcquired.Date}. It is currently in enclosure {EnclosureNumber}.");
        }
    }
}