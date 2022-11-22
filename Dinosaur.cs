using System;

namespace JurassicPark
{
    public class Dinosaur
    {

        public int Weight { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int EnclosureNumber { get; set; }
        public string Name { get; set; }

        public Dinosaur(string name, string diet, int weight, int enclosure)
        {
            Name = name;
            DietType = diet;
            WhenAcquired = DateTime.Now;
            Weight = weight;
            EnclosureNumber = enclosure;
        }

        public void Description()
        {
            Console.WriteLine($"{Name} dietType is {DietType}. {Name} is in enclosure number {EnclosureNumber} and weighs {Weight} pounds. It was acquired at {WhenAcquired}");
        }
    }
}
