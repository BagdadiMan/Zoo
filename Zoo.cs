using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo
{
    class Zoo
    {
        private List<Animal> animals;

        public Zoo(List<Animal> animals)
        {
            this.animals = animals;
        }

        public void AddAnimal(Animal animalToAdd)
        {
            animals.Add(animalToAdd);
        }

        public void RemoveAnimal(Animal animalToRemove)
        {
            animals.Remove(animalToRemove);
        }

        public List<Animal> GetAnimals()
        {
            // Copying for immutabilty
            List<Animal> copy = new List<Animal>();
            copy.AddRange(this.animals);

            return copy;
        }
    }
}
