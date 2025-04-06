namespace GeniyIdiotNewConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var countQuestions = 5;
            var questions = GetQuestions();
            var answers = GetAnswers();

            var rightAnswerscount = 0;
            

            // Создаем и перемешиваем индексы вопросов
            var questionIndices = Enumerable.Range(0, countQuestions).ToList();
            Shuffle(questionIndices);

            for (int i = 0; i < countQuestions; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));

                var currentIndex = questionIndices[i];
                Console.WriteLine(questions[currentIndex]);

                var userAnswer = Convert.ToInt32(Console.ReadLine());
                var rightAnswer = answers[currentIndex];

                if (userAnswer == rightAnswer)
                {
                    rightAnswerscount++;
                }
            }

            var diagnosis = GetDiagnosis(rightAnswerscount);

            Console.WriteLine($"Количество правильных ответов: {rightAnswerscount}");
            Console.WriteLine($"Ваш диагноз:{diagnosis}");
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

        private static string GetDiagnosis(int rightAnswersCount)
        {
            var diagnoses = new string[] { "кретин", "идиот", "дурак", "нормальный", "талант", "гений" };
            return diagnoses[rightAnswersCount];
        }
    }
}