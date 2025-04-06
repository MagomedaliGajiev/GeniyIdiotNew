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

            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine($"Вопрос№{i+1}");
                Console.WriteLine(questions[i]);

                var userAnswer = Convert.ToInt32(Console.ReadLine());
                var rightAnswer = answers[i];

                if (userAnswer == rightAnswer)
                {
                    rightAnswersCount++;
                }
            }

            Console.WriteLine($"Количество правильных ответов {rightAnswersCount}");
        }
    }
}