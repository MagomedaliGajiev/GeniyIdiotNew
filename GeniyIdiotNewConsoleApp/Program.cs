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
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя (или 'история' для просмотра результатов): ");
            var input = Console.ReadLine();

            if (input.ToLower() == "история")
            {
                ShowHistory();
                return;
            }

            var user = new User(input);
            bool playAgain;

            do
            {
                new Test(user).Run();
                SaveTestResult(user);
                ShowTestResult(user);

                playAgain = GetUserChoice("\nХотите пройти тест еще раз?");
            }
            while (playAgain);

            Console.WriteLine("\nСпасибо за участие! До новых встреч!");
        }

        private static void ShowHistory()
        {
            var results = UserResultStorage.GetAllResults();

            if (results.Count == 0)
            {
                Console.WriteLine("История результатов пуста.");
                return;
            }

            Console.WriteLine("\nИстория результатов:");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("| {0,-20} | {1,-25} | {2,-10} | {3,-20} |",
                "ФИО", "Кол-во правильных ответов", "Диагноз", "Дата и время теста");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            foreach (var result in results)
            {
                Console.WriteLine("| {0,-20} | {1,-25} | {2,-10} | {3,-20:dd.MM.yyyy HH:mm:ss} |",
                    result.UserName,
                    result.CorrectAnswersCount,
                    result.Diagnosis,
                    result.TestDateTime);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }

        private static void SaveTestResult(User user)
        {
            var diagnosis = DiagnosisCalculator.GetDiagnosis(
                user.RightAnswersCount,
                QuestionsStorage.GetAllQuestions().Count
            );

            UserResultStorage.SaveResult(new UserResult(
                user.Name,
                user.RightAnswersCount,
                diagnosis,
                DateTime.Now
            ));
        }

        private static void ShowTestResult(User user)
        {
            Console.WriteLine($"\n{user.Name}, количество ваших правильных ответов: {user.RightAnswersCount}");
            Console.WriteLine($"Ваш диагноз: {DiagnosisCalculator.GetDiagnosis(
                user.RightAnswersCount,
                QuestionsStorage.GetAllQuestions().Count
            )}");
        }

        private static bool GetUserChoice(string message)
        {
            while (true)
            {
                Console.Write($"{message} (да/нет): ");
                var answer = Console.ReadLine()?.ToLower();

                if (answer == "да" || answer == "д") return true;
                if (answer == "нет" || answer == "н") return false;

                Console.WriteLine("Не понял ваш ответ. Пожалуйста, введите 'да' или 'нет'.");
            }
        }
    }
}