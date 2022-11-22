using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    partial class Program
    {
        public class DinosaurDatabase
        {
            static List<Dinosaur> dinosaurs = new List<Dinosaur>() { };

            public static Dinosaur Add(string name, string diet, int weight, int enclosure)
            {
                Dinosaur newDinosaur = new Dinosaur(name, diet, weight, enclosure);
                dinosaurs.Add(newDinosaur);
                return newDinosaur;
            }

            public static Dinosaur Remove(string name)
            {
                Dinosaur removeDinosaur = dinosaurs.FirstOrDefault(value => value.Name.ToLower() == name.ToLower());
                if (removeDinosaur != null)
                {
                    dinosaurs.Remove(removeDinosaur);
                    Console.WriteLine("Dinosaur removed from database.");
                }
                return removeDinosaur;
            }

            public static Dinosaur Transfer(string name, int newEnclosure)
            {
                Dinosaur transferDinosaur = dinosaurs.FirstOrDefault(value => value.Name.ToLower() == name.ToLower());
                if (transferDinosaur != null)
                {
                    transferDinosaur.EnclosureNumber = newEnclosure;
                    Console.WriteLine("Dinosaur has been updated!");
                }

                return transferDinosaur;
            }

            public static void Summary()
            {
                int herbivoreCount = dinosaurs.Where(value => value.DietType == "herbivore").Count();
                int carnivoreCount = dinosaurs.Where(value => value.DietType == "carnivore").Count();

                Console.WriteLine($"Jurassic Park contains {carnivoreCount} Dinosaurs that are carnivore  and {herbivoreCount} Dinosaurs that are herbivore  ");

            }

            public static void ViewDinosaur(string orderBy)
            {
                if (dinosaurs.Count == 0)
                {
                    Console.WriteLine("There are currently no Dinosaurs in the database");
                    return;
                }
                if (orderBy == "Name")
                {
                    dinosaurs = dinosaurs.OrderBy(value => value.Name).ToList<Dinosaur>();
                }
                else
                if (orderBy == "Enclosure")
                {
                    dinosaurs = dinosaurs.OrderBy(value => value.EnclosureNumber).ToList<Dinosaur>();
                }

                dinosaurs.ForEach(value => value.Description());
            }


        }
    }
}
