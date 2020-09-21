using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Elephant : Mammal
    {
        private double TrunkLength;
        private int TusksCount;

        public Elephant(string name, int age, Gender gender, string favoriteHuman, double trunkLength, int tusksCount) : base(name, age, gender, favoriteHuman)
        {
            SetTrunkLength(trunkLength);
            SetTusksCount(tusksCount);
        }

        public void AddTusk()
        {
            this.TusksCount++;
        }

        public void RemoveTusk()
        {
            if(this.TusksCount <= 0)
            {
                throw new ArgumentException("Can not remove tusk from an elephant that has no tusks!");
            }
            this.TusksCount--;
        }

        public int GetTusksCount()
        {
            return this.TusksCount;
        }

        private void SetTusksCount(int tusksCount)
        {
            if (this.TusksCount < 0)
            {
                throw new ArgumentException("Tusks count has to be positive");
            }
            this.TusksCount = tusksCount;
        }

        public void SetTrunkLength(double trunkLength)
        {
            this.TrunkLength = trunkLength;
        }

        public double GetTrunkLength()
        {
            return this.TrunkLength;
        }

        public override Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> ElephantDictionary = base.GetDictionary();
            ElephantDictionary.Add("Trunk length", this.GetTrunkLength());
            ElephantDictionary.Add("Tusks count", this.GetTusksCount());

            return ElephantDictionary;
        }
    }
}
