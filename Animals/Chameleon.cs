using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Chameleon : Lizard
    {
        private Color CurrentColor;

        public Chameleon(string name, int age, Gender gender, string favoriteHuman, Color currentColor) : base(name, age, gender, favoriteHuman)
        {
            SetColor(currentColor);
        }

        public void SetColor(Color newColor) => this.CurrentColor = newColor;

        public Color GetCurrentColor()
        {
            return this.CurrentColor;
        }

        public override Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> ChameleonDictionary = base.GetDictionary();
            ChameleonDictionary.Add("Current color", this.GetCurrentColor().ToString());

            return ChameleonDictionary;
        }
    }
}
