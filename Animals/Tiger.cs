using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Tiger : Mammal
    {
        private int StripesCount;
        private int HumansEaten;

        public Tiger(string name, int age, Gender gender, string favoriteHuman, int stripesCount, int humanEaten) : base(name, age, gender, favoriteHuman)
        {
            SetHumanEaten(humanEaten);
            SetStripesCount(stripesCount);
        }

        public void SetStripesCount(int stripesCount)
        {
            if(stripesCount < 0)
            {
                throw new ArgumentException("Stripes count must be positive!");
            }

            this.StripesCount = stripesCount;
        }

        public int GetStripesCount()
        {
            return this.StripesCount;
        }

        private void SetHumanEaten(int humanEaten)
        {
            if (humanEaten < 0)
            {
                throw new ArgumentException("Human eaten must be positive!");
            }

            this.HumansEaten = humanEaten;
        }

        public void AddHumanEaten()
        {
            this.HumansEaten++;
        }

        public int GetHumanEaten()
        {
            return this.HumansEaten;
        }

        public override Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> TigerDictionary = base.GetDictionary();
            TigerDictionary.Add("Stripes Count", this.GetStripesCount());
            TigerDictionary.Add("Human Eaten", this.GetHumanEaten());

            return TigerDictionary;
        }

        public override string GetType()
        {
            return "Tiger";
        }
    }
}