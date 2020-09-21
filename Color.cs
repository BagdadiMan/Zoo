namespace Zoo
{
    public class Color
    {
        private string Name;

        public Color(string name)
        {
            Name = name;
        }

        public void SetName(string newName)
        {
            this.Name = newName;
        }

        public string GetName()
        {
            return this.Name;
        }

        public override string ToString()
        {
            return string.Format("Color {0}", this.GetName());
        }
    }
}