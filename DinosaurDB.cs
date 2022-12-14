using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    public class DinosaurDB
    {
        private List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();
        //VIEW DINOSAURS
        //CREATE
        //BEHAVIOR
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            Dinosaurs.Add(newDinosaur);
        }
        //READ
        public List<Dinosaur> GetAllDinosaurs()
        {
            return Dinosaurs;
        }
        //READ
        public Dinosaur FindOneDinosaur(string nameToFind)
        {
            Dinosaur foundDinosaur = Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name.ToUpper().Contains(nameToFind.ToUpper()));
            return foundDinosaur;
        }
        //DELETE    
        public void RemoveDinosaur(string nameToRemove)
        {
            Dinosaur foundDinosaur = FindOneDinosaur(nameToRemove);
            Dinosaurs.Remove(foundDinosaur);
        }
        //TRANSFER
        public void TransferDinosaur(string nameToTransfer, int newEnclosureNumber)
        {
            Dinosaur foundDinosaur = FindOneDinosaur(nameToTransfer);
            foundDinosaur.EnclosureNumber = newEnclosureNumber;
        }
    }
}