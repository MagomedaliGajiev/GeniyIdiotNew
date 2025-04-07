using Newtonsoft.Json;

namespace GeniyIdiotNewConsoleApp
{
    public static class FileProvider
    {
        public static void SaveToFile<T>(string path, T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static T LoadFromFile<T>(string path) where T : new()
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json) ?? new T();
            }
            return new T();
        }

        public static void AppendToFile<T>(string path, T item)
        {
            var list = LoadFromFile<List<T>>(path);
            list.Add(item);
            SaveToFile(path, list);
        }
    }
}