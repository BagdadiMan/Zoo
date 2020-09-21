using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class CsvSerializer : ISerializer
    {
        private string Path;
        private List<ISerializableObject> ListToSerialize;

        public CsvSerializer(string path, List<ISerializableObject> listToSerialize)
        {
            this.Path = path;
            this.ListToSerialize = listToSerialize;
        }

        public void SetPath(string path)
        {
            this.Path = path;
        }

        public string GetPath()
        {
            return this.Path;
        }

        public void SetListToSerialize(List<ISerializableObject> listToSerialize)
        {
            this.ListToSerialize = listToSerialize;
        }

        private string ParseListToCSV(List<ISerializableObject> listToSerialize)
        {
            StringBuilder finalCsvFile = new StringBuilder();
            
            foreach(ISerializableObject itemToSerialize in listToSerialize)
            {
                Dictionary<string, object> itemDictionary = itemToSerialize.GetDictionary();
                string dictionaryAsCSV = ParseDictionaryToCSV(itemDictionary);

                finalCsvFile.Append(dictionaryAsCSV);
                finalCsvFile.Append('\n');
            }

            return finalCsvFile.ToString();
        }

        private string ParseDictionaryToCSV(Dictionary<String, object> dictionaryToParse)
        {
            StringBuilder parsedDictionary = new StringBuilder();

            foreach (object item in dictionaryToParse.Values)
            {
                parsedDictionary.Append(item.ToString());
                parsedDictionary.Append(',');
            }
            return parsedDictionary.ToString();
        }

        public void Serialize()
        {
            System.IO.File.WriteAllText(this.GetPath() + @"\Zoo.csv", this.ParseListToCSV(this.ListToSerialize));
        }
    }
}
  