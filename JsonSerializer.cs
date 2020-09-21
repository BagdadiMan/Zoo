using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class JsonSerializer : ISerializer
    {
        private string path;
        private List<ISerializableObject> listToSerialize;

        public JsonSerializer(string path, List<ISerializableObject> listToSerialize)
        {
            this.path = path;
            this.listToSerialize = listToSerialize;
        }

        public void SetPath(string path)
        {
            this.path = path;
        }

        public void SetListToSerialize(List<ISerializableObject> listToSerialize)
        {
            this.listToSerialize = listToSerialize;
        }

        private string ParseListToJson(List<ISerializableObject> listToSerialize)
        {
            StringBuilder finalJsonFile = new StringBuilder();

            finalJsonFile.Append("[\n");
            foreach (ISerializableObject itemToSerialize in listToSerialize)
            {
                Dictionary<string, object> itemDictionary = itemToSerialize.GetDictionary();
                string dictionaryAsJson = ParseDictionaryToJson(itemDictionary);

                finalJsonFile.Append(dictionaryAsJson);
                finalJsonFile.Append(",\n");
            }
            finalJsonFile.Append("]");

            return finalJsonFile.ToString();
        }

        private string ParseDictionaryToJson(Dictionary<String, object> dictionaryToParse)
        {
            return ParseDictionaryToJson(dictionaryToParse, 1);
        }

        private string ParseDictionaryToJson(Dictionary<String, object> dictionaryToParse, int tabsCount)
        {
            StringBuilder parsedDictionary = new StringBuilder();
            string outerTabs = new String('\t', tabsCount);
            string innetTabs = new String('\t', tabsCount + 1);

            parsedDictionary.Append(outerTabs);
            parsedDictionary.Append("{\n");
            foreach (KeyValuePair<string, object> entry in dictionaryToParse)
            {
                parsedDictionary.Append(innetTabs);
                parsedDictionary.Append(String.Format("\"{0}\": {1}", entry.Key, ParseObjectToJsonValue(entry.Value, tabsCount)));
                parsedDictionary.Append(",\n");
            }
            parsedDictionary.Append(outerTabs);
            parsedDictionary.Append("}");

            return parsedDictionary.ToString();
        }

        private string ParseObjectToJsonValue(Object objectToParse, int tabsCount)
        {
            Type objectType = objectToParse.GetType();
            string objectAsJsonValue;

            if (objectType.Equals(typeof(System.String))) {
                objectAsJsonValue = String.Format("\"{0}\"", objectToParse);
            }
            else if(objectToParse is ISerializableObject)
            {
                objectAsJsonValue = "\n" + this.ParseDictionaryToJson(((ISerializableObject)objectToParse).GetDictionary(), tabsCount + 1);
            }
            else
            {
                objectAsJsonValue = objectToParse.ToString();
            }

            return objectAsJsonValue;
        }

        public void Serialize()
        {
            System.IO.File.WriteAllText(this.path + @"\Zoo.json", this.ParseListToJson(this.listToSerialize));
        }
    }
}
