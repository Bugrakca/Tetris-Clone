using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class FileHandler
{
    public static void SaveToJson<T>(List<T> toSave, string fileName)
    {
        Debug.Log(GetPath(fileName));
        string content = JsonHelper.ToJson(toSave.ToArray());
        WriteFile(GetPath(fileName), content);
    }

    public static T ReadFromJson<T> (string filename) {
        string content = ReadFile (GetPath (filename));

        if (string.IsNullOrEmpty (content) || content == "{}") {
            return default (T);
        }

        T res = JsonUtility.FromJson<T> (content);

        return res;

    }
    
    public static List<T> ReadListFromJson<T> (string filename) {
        string content = ReadFile(GetPath (filename));

        if (string.IsNullOrEmpty (content) || content == "{}") {
            return new List<T> ();
        }

        List<T> res = JsonHelper.FromJson<T> (content).ToList();

        return res;
    }

    public static string GetPath(string fileName)
    {
        return $"{Application.persistentDataPath}/{fileName}";
    }

    public static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    public static string ReadFile(string path)
    {
        if (File.Exists (path)) {
            using (StreamReader reader = new StreamReader (path)) {
                string content = reader.ReadToEnd ();
                return content;
            }
        }
        return "";
    }


    public static class JsonHelper {
        public static T[] FromJson<T> (string json) {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (json);
            return wrapper.items;
        }

        public static string ToJson<T> (T[] array) {
            Wrapper<T> wrapper = new Wrapper<T>
            {
                items = array
            };
            return JsonUtility.ToJson (wrapper);
        }

        public static string ToJson<T> (T[] array, bool prettyPrint) {
            Wrapper<T> wrapper = new Wrapper<T> ();
            wrapper.items = array;
            return JsonUtility.ToJson (wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T> {
            public T[] items;
        }
    }
}