using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Chameleon : Lizard
    {
        private string CurrentColor;

        public Chameleon(string name, int age, Gender gender, string favoriteHuman, string currentColor) : base(name, age, gender, favoriteHuman)
        {
            SetColor(currentColor);
        }

        public void SetColor(string newColor) => this.CurrentColor = newColor;

        public string GetCurrentColor()
        {
            return this.CurrentColor;
        }

        public override Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> ChameleonDictionary = base.GetDictionary();
            ChameleonDictionary.Add("Current color", this.GetCurrentColor());

            return ChameleonDictionary;
        }

        public override string GetType()
        {
            return "Chameleon";
        }
    }
}
