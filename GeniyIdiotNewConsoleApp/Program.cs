﻿using Newtonsoft.Json;

namespace GeniyIdiotNewConsoleApp
{
    public class Program
    {
        private const string ResultsFileName = "results.json";
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя (или 'история' для просмотра результатов): ");
            var input = Console.ReadLine();

            if (input.ToLower() == "история")
            {
                ShowHistory();
                return;
            }
            var userName = input;
            
            bool playAgain;
            do
            {
                playAgain = RunTest(userName);
            }
            while (playAgain);
            
            Console.WriteLine("\nСпасибо за участие! До новых встреч!");
            
        }

        private static bool RunTest(string? userName)
        {
            var questions = GetQuestions();

            var rightAnswersCount = 0;

            var questionsCount = questions.Count;
            var random = new Random();

            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));

                var randomQuestionIndex = random.Next(0, questions.Count);
                Console.WriteLine(questions[randomQuestionIndex].Text);

                var userAnswer = GetUserAnswer();
                var rightAnswer = questions[randomQuestionIndex].Answer;

                if (userAnswer == rightAnswer)
                {
                    rightAnswersCount++;
                }

                questions.RemoveAt(randomQuestionIndex);
            }

            var diagnosis = CalculateDiagnosis(rightAnswersCount, questionsCount);
            SaveResult(new UserResult(
                userName,
                rightAnswersCount,
                diagnosis,
                DateTime.Now
            ));

            Console.WriteLine($"\n{userName}, количество ваших правильных ответов: {rightAnswersCount}");
            Console.WriteLine($"Ваш диагноз: {diagnosis}");

            var message = "\nХотите пройти тест еще раз?";
            return GetUserChoice(message);
        }


        private static void SaveResult(UserResult result)
        {
            var results = LoadResults();
            results.Add(result);

            var json = JsonConvert.SerializeObject(results, Formatting.Indented);
            File.WriteAllText(ResultsFileName, json);
        }

        private static List<UserResult> LoadResults()
        {
            if (File.Exists(ResultsFileName))
            {
                var json = File.ReadAllText(ResultsFileName);
                return JsonConvert.DeserializeObject<List<UserResult>>(json) ?? new List<UserResult>();
            }
            return new List<UserResult>();
        }

        private static void ShowHistory()
        {
            var results = LoadResults();

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
        private static int GetUserAnswer()
        {

            while (true)
            {
                var input = Console.ReadLine();
                try
                {
                    return Convert.ToInt32(input);
                }
                catch (FormatException)
                {

                    Console.WriteLine("Пожалуйста, введите число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введите число от -2*10^9 до 2*10^9!");
                }
            }
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

        private static List<Question> GetQuestions()
        {
            return new List<Question>
            {
                new Question("Сколько будет два плюс два умноженное на два?", 6),
                new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
                new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
                new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2)
            };
        }
        private static List<string> GetDiagnoses()
        {
            return new List<string> { "кретин", "идиот", "дурак", "нормальный", "талант", "гений" };
        }
        private static string CalculateDiagnosis(int rightAnswersCount, int questionsCount)
        {
            
            var diagnoses = GetDiagnoses();

            if (questionsCount == 0)
            {
                return "не определен";
            }
            var percentage = (double)rightAnswersCount / questionsCount * 100;
            var step = 100.0 / diagnoses.Count;
            var index = (int)(percentage / step);
            return diagnoses[Math.Min(index, diagnoses.Count - 1)];
        }
    }
}