namespace GeniyIdiotNewConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var questions = new string[5];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";

            var answers = new int[5];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;

            var rightAnswersCount = 0;

            var diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";

            // Создаём массив индексов и перемешиваем его
            var random = new Random();
            var questionIndexes = Enumerable.Range(0, questions.Length).ToArray();

            // Алгоритм Фишера-Йетса для перемешивания
            for (int i = questionIndexes.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (questionIndexes[j], questionIndexes[i]) = (questionIndexes[i], questionIndexes[j]);
            }

            // Задаём вопросы в перемешанном порядке
            foreach (var index in questionIndexes)
            {
                Console.WriteLine($"Вопрос №{Array.IndexOf(questionIndexes, index) + 1}");
                Console.WriteLine(questions[index]);

                var userAnswer = Convert.ToInt32(Console.ReadLine());
                var rightAnswer = answers[index];

                if (userAnswer == rightAnswer)
                {
                    rightAnswersCount++;
                }
            }

            Console.WriteLine($"Ваш диагноз: {diagnoses[rightAnswersCount]}");
        }
    }
}