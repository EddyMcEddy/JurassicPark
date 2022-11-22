using System;

namespace JurassicPark
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to JURASSIC PARK!!!!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("_______________________________________________");

            bool menuKeepGoing = true;
            string userInput = " ";

            while (menuKeepGoing)
            {
                Console.WriteLine($"----------------------------------------------------");
                Console.WriteLine($"Dino's Database, Choose one of the following!:");
                Console.WriteLine();
                Console.WriteLine($"(A)dd a Dinosaur to the database \n(R)emove a Dinosaur from the database \n(T)ransfer a Dinosaur to a different enclosure \n(S)ummarize herbivore/carnivore count \n(V)iew the Dinosaurs in order \n(Q)uit to exit");
                Console.WriteLine("____________________________________________________________");


                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "A":
                        string newName = " ";
                        string newDietType = " ";
                        int newWeight = 0;
                        int newEnclosure = 0;

                        Console.WriteLine($"What is the Dino's Diet type? (H)erbivore or (C)arnivore");
                        string userResponse = Console.ReadLine().ToUpper();

                        if (userResponse == "H")
                        {
                            newDietType = "Herbivore type";
                        }
                        else if (userResponse == "C")
                        {
                            newDietType = "Carnivore type";
                        }
                        else
                        {
                            Console.WriteLine($"Invalid Diet");
                            break;
                        }

                        Console.WriteLine($"What is the name of the Dino?");
                        newName = Console.ReadLine();

                        Console.WriteLine($"What is the weight of the Dino in pounds?");
                        newWeight = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Which enclosure number is {newName} going to be residing?");
                        newEnclosure = int.Parse(Console.ReadLine());

                        DinosaurDatabase.Add(newName, newDietType, newWeight, newEnclosure);
                        break;

                    case "R":
                        Console.WriteLine($"Which Dinosaur would you like to remove from the database?");
                        Dinosaur removeDinosaur = DinosaurDatabase.Remove(Console.ReadLine());

                        if (removeDinosaur != null)
                        {
                            Console.WriteLine($"{removeDinosaur.Name} has been removed from database");
                        }
                        else
                        {
                            Console.WriteLine($"This Dino does not exist in our database");
                        }
                        break;

                    case "T":
                        Console.WriteLine($"What is the name of the Dino you need to transfer?");
                        string transferDinosaur = Console.ReadLine();

                        Console.WriteLine($"What is the new enclosure number to transfer the Dino?");
                        int newTransferEnclosure = int.Parse(Console.ReadLine());

                        Dinosaur dinoTransferring = DinosaurDatabase.Transfer(transferDinosaur, newTransferEnclosure);

                        if (dinoTransferring != null)
                        {
                            Console.WriteLine($"{dinoTransferring} has been transferred to its new enclosure.");
                        }
                        else
                        {
                            Console.WriteLine($"This Dinosaur does not exist in our database {dinoTransferring.Name}");
                        }

                        break;

                    case "S":
                        DinosaurDatabase.Summary();
                        break;

                    case "V":
                        Console.WriteLine($"View the Dinosaurs by (N)ame or by (E)nclosure?");
                        string userAnswer = Console.ReadLine();

                        if (userAnswer.ToUpper() == "N")
                        {
                            DinosaurDatabase.ViewDinosaur("Name");
                        }
                        else
                            if (userAnswer.ToUpper() == "E")
                        {
                            DinosaurDatabase.ViewDinosaur("Enclosure");
                        }

                        break;

                    case "Q":
                        menuKeepGoing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            Console.WriteLine($"Thank you for joining Jurassic Park, Come again!");

        }
    }
}
