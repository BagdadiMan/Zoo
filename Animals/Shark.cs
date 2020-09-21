using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Shark : Fish
    {
        private SharkType Type;
        private bool IsLawyer;

        public Shark(string name, int age, Gender gender, string favoriteHuman, SharkType type, bool isLawyer) : base(name, age, gender, favoriteHuman)
        {
            SetSharkType(type);
            SetIsLawyer(isLawyer);
        }

        public void SetSharkType(SharkType newType) => this.Type = newType;

        public SharkType GetSharkType()
        {
            return this.Type;
        }

        public void SetIsLawyer(bool isLawyer) => this.IsLawyer = isLawyer;

        public bool GetIsLawyer()
        {
            return this.IsLawyer;
        }

        public override Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> SharkDictionary = base.GetDictionary();
            SharkDictionary.Add("Type", this.GetType());
            SharkDictionary.Add("Is lawyer", this.GetIsLawyer());

            return SharkDictionary;
        }
    }
}
