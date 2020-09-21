using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Rock : ISerializableObject
    {
        private int Weight;

        public Rock(int weight)
        {
            Weight = weight;
        }

        public void SetWeight(int newWeight)
        {
            if (newWeight < 0)
            {
                throw new ArgumentException("Weight must be positive!");
            }

            this.Weight = newWeight;
        }

        public int GetWeight()
        {
            return this.Weight;
        }

        public Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> RockDictionary = new Dictionary<string, object>();
            RockDictionary.Add("Weight", this.GetWeight());

            return RockDictionary;
        }
    }
}
