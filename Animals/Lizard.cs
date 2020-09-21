using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public abstract class Lizard : Animal
    {
        public Lizard(string name, int age, Gender gender, string favoriteHuman) : base(name, age, gender, favoriteHuman)
        {
        }

        public override Dictionary<string, object> GetDictionary()
        {
            return base.GetDictionary();
        }
    }
}
