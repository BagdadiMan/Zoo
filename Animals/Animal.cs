using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public abstract class Animal: ISerializableObject
    {
        private string Name;
        private int Age;
        private Gender Gender;
        private string FavoriteHuman;

        protected Animal(string name, int age, Gender gender, string favoriteHuman)
        {
            SetName(name);
            SetAge(age);
            Gender = gender;
            SetFavoriteHuman(favoriteHuman);
        }

        public void SetName(string newName) => this.Name = newName;

        public string GetName()
        {
            return this.Name;
        }

        public void SetAge(int newAge)
        {
            if(newAge < 0)
            {
                throw new ArgumentException(String.Format("Age must be positive, got {0}", newAge));
            }

            this.Age = newAge;
        }

        public int GetAge()
        {
            return this.Age;
        }

        public void SetGender(Gender newGender) => this.Gender = newGender;

        public Gender GetGender()
        {
            return this.Gender;
        }

        public void SetFavoriteHuman(string newFavoriteHuman)
        {
            if(this.GetName()[0] != newFavoriteHuman[0])
            {
                throw new ArgumentException(String.Format("Animal favorite human name " +
                    "must start with the first letter of the animal, animal name is {0}," +
                    " got {1}", this.GetName(), newFavoriteHuman));
            }

            this.FavoriteHuman = newFavoriteHuman;
        }

        public string GetFavoriteHuman()
        {
            return this.FavoriteHuman;
        }

        public virtual Dictionary<string, object> GetDictionary()
        {
            Dictionary<String, object> animalDictionary = new Dictionary<string, object>();
            animalDictionary.Add("Name", this.GetName());
            animalDictionary.Add("Age", this.GetAge());
            animalDictionary.Add("Gender", this.GetGender());
            animalDictionary.Add("Favorite human", this.GetFavoriteHuman());

            return animalDictionary;
        }
    }
}
