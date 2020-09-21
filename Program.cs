using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo(new List<Animal>());
            zoo.AddAnimal(new Chameleon("Ron", 18, Gender.Female, "Ronen", "Red"));
            zoo.AddAnimal(new Shark("Moshe", 18, Gender.Female, "Meron", SharkType.GreatWhite, false));
            zoo.AddAnimal(new Elephant("Shmuel", 18, Gender.Female, "Sagi", 18.5, 2));
            zoo.AddAnimal(new Ostrich("Ohad", 18, Gender.Female, "Ohadi", true));
            zoo.AddAnimal(new Otter("Ron", 18, Gender.Female, "Ronen", new Rock(54)));

            List<ISerializableObject> serializableObjects = zoo.GetAnimals().Cast<ISerializableObject>().ToList();

            CsvSerializer CsvSerializer = new CsvSerializer(@"C:\Users\Nimrod\Downloads\ex_1_example", serializableObjects);
            JsonSerializer JsonSerializer = new JsonSerializer(@"C:\Users\Nimrod\Downloads\ex_1_example", serializableObjects);

            try
            {
                JsonSerializer.Serialize();
            }
            catch(IOException e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
        }
    }
}
