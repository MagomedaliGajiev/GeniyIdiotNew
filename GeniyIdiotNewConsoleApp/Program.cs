namespace GeniyIdiotNewConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            var userName = Console.ReadLine();
            
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
            var answers = GetAnswers();

            var rightAnswerscount = 0;


            // Создаем и перемешиваем индексы вопросов
            var questionsCount = questions.Length;
            var questionIndices = Enumerable.Range(0, questionsCount).ToList();
            Shuffle(questionIndices);

            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));

                var currentIndex = questionIndices[i];
                Console.WriteLine(questions[currentIndex]);

                var userAnswer = GetUserAnswer();
                var rightAnswer = answers[currentIndex];

                if (userAnswer == rightAnswer)
                {
                    rightAnswerscount++;
                }
            }

            var diagnosis = GetDiagnosis(rightAnswerscount, questionsCount);

            Console.WriteLine($"\n{userName}, количество ваших правильных ответов: {rightAnswerscount}");
            Console.WriteLine($"Ваш диагноз: {diagnosis}");

            var message = "\nХотите пройти тест еще раз?";
            return GetUserChoice(message);
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
                catch (Exception)
                {

                    Console.WriteLine("Пожалуйста, введите число!");
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

        private static void Shuffle<T>(IList<T> list)
        {
            var random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }

        private static string[] GetQuestions()
        {
            return new string[]
            {
                "Сколько будет два плюс два умноженное на два?",
                "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
                "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
                "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
                "Пять свечей горело, две потухли. Сколько свечей осталось?"
            };
        }

        private static int[] GetAnswers()
        {
            return new int[] { 6, 9, 25, 60, 2 };
        }
        private static string[] GetDiagnoses()
        {
            return new string[] { "кретин", "идиот", "дурак", "нормальный", "талант", "гений" };
        }
        private static string GetDiagnosis(int rightAnswersCount, int questionsCount)
        {
            
            var diagnoses = GetDiagnoses();

            if (questionsCount == 0)
            {
                return "не определен";
            }
            var percentage = (double)rightAnswersCount / questionsCount * 100;
            var step = 100.0 / diagnoses.Length;
            var index = (int)(percentage / step);
            return diagnoses[Math.Min(index, diagnoses.Length - 1)];
        }
    }
}