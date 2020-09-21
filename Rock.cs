using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Rock
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

        public override string ToString()
        {
            return String.Format("Rock, Weight: {0} KG", this.GetWeight());
        }
    }
}
