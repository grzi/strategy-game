using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Json parser so as to read and write date from / to json
/// </summary>
/// <typeparam name="T">Json read will be parsed to type T</typeparam>
public class JsonReader<T> {
    public static T read(String path) {
        try {
            string dataAsJson = File.ReadAllText(path);
            var result = JsonUtility.FromJson<T>(dataAsJson);
            return result;
        }
        catch (Exception) {
            throw new Exception("Impossible to read the json at : " + @path);
        }
    }
}

