using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class JsonSerializer : ISerializer
    {
        private string Path;
        private List<ISerializableObject> ListToSerialize;

        public JsonSerializer(string path, List<ISerializableObject> listToSerialize)
        {
            this.Path = path;
            this.ListToSerialize = listToSerialize;
        }

        public void SetPath(string path)
        {
            this.Path = path;
        }

        public void SetListToSerialize(List<ISerializableObject> listToSerialize)
        {
            this.ListToSerialize = listToSerialize;
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
            string parenthesesTabs = new String('\t', tabsCount);
            string bodyTabs = new String('\t', tabsCount + 1);

            parsedDictionary.Append(parenthesesTabs);
            parsedDictionary.Append("{\n");
            foreach (KeyValuePair<string, object> entry in dictionaryToParse)
            {
                parsedDictionary.Append(bodyTabs);
                parsedDictionary.Append(String.Format("\"{0}\": {1}", entry.Key, ParseObjectToJsonValue(entry.Value, tabsCount)));
                parsedDictionary.Append(",\n");
            }
            parsedDictionary.Append(parenthesesTabs);
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
            System.IO.File.WriteAllText(this.Path + @"\Zoo.json", this.ParseListToJson(this.ListToSerialize));
        }
    }
}
