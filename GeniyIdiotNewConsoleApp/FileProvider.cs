using Newtonsoft.Json;

namespace GeniyIdiotNewConsoleApp
{
    public static class FileProvider
    {
        public static void Save<T>(string fileName, T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public static T Load<T>(string fileName) where T : new()
        {
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<T>(json) ?? new T();
            }
            return new T();
        }

        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        public static void Append<T>(string fileName, T data)
        {
            var list = Load<List<T>>(fileName);
            list.Add(data);
            Save(fileName, list);
        }
    }
}