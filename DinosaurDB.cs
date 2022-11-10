using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    public class DinosaurDB
    {
        private List<Dinosaur> dinosaurs = new List<Dinosaur>();

        public List<Dinosaur> GetAllDinosaurs()
        {
            return dinosaurs;
        }
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            dinosaurs.Add(newDinosaur);
        }
        public Dinosaur FindOneDinosaur(string name)
        {
            Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);
            return foundDinosaur;
        }

    }
}