using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Ostrich : BigAssBird
    {
        private bool IsHeadInGround;

        public Ostrich(string name, int age, Gender gender, string favoriteHuman, bool isHeadInGround) : base(name, age, gender, favoriteHuman)
        {
            this.IsHeadInGround = isHeadInGround;
        }

        public void PutHeadInGround()
        {
            this.IsHeadInGround = true;
        }

        public void TakeHeadOutOfGround()
        {
            this.IsHeadInGround = false;
        }

        public bool GetIsHeadInGround()
        {
            return this.IsHeadInGround;
        }

        public override Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> OstrichDictionary = base.GetDictionary();
            OstrichDictionary.Add("Is head in ground", this.GetIsHeadInGround());

            return OstrichDictionary;
        }

        public override string GetType()
        {
            return "Ostrich";
        }
    }
}
