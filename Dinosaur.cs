using System;

namespace JurassicPark
{
    public class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        public string Description
        {
            get
            {
                return $"{Name} is a {DietType} dinosaur that weighs {Weight} pounds and was acquired on {WhenAcquired}. It is currently in enclosure {EnclosureNumber}.";
            }
        }
    }
}