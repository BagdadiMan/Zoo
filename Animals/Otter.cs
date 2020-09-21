using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Otter : Mammal
    {
        private Rock FavoriteRock;

        public Otter(string name, int age, Gender gender, string favoriteHuman, Rock favoriteRock) : base(name, age, gender, favoriteHuman)
        {
            SetFavoriteRock(favoriteRock);
        }

        public void SetFavoriteRock(Rock newFavoriteRock)
        {
            this.FavoriteRock = newFavoriteRock;
        }

        public Rock GetFavoriteRock()
        {
            return this.FavoriteRock;
        }

        public override Dictionary<string, object> GetDictionary()
        {
            Dictionary<string, object> OtterDictionary = base.GetDictionary();
            OtterDictionary.Add("Favorite rock", this.GetFavoriteRock());

            return OtterDictionary;
        }

        public override string GetType()
        {
            return "Otter";
        }
    }
}
