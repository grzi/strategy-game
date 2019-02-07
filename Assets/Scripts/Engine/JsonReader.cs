using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Json parser so as to read and write date from / to json
/// </summary>
/// <typeparam name="T">Json read will be parsed to type T</typeparam>
public class JsonReader<T> {
    public static T read(String path) {
        JObject tmp = null;
        
        using (StreamReader file = File.OpenText(@path))
        using (JsonTextReader reader = new JsonTextReader(file)) {
            tmp = (JObject)JToken.ReadFrom(reader);
        }

        if(tmp != null) {
            return (T)tmp.ToObject(typeof(T));
        }

        throw new JsonReaderException("Impossible to read the json at : " + @path);
    }
}

