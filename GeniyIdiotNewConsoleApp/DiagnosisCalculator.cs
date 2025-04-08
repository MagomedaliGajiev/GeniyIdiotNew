namespace GeniyIdiotNewConsoleApp
{
    public class DiagnosisCalculator
    {
        private static List<string> _diagnoses = new List<string>() 
        { 
            "кретин",
            "идиот",
            "дурак",
            "нормальный",
            "талант",
            "гений" 
        };
        public static string GetDiagnosis(int rightAnswersCount, int questionsCount)
        {
            if (questionsCount == 0)
            {
                return "не определен";
            }
            var percantage = (double)rightAnswersCount / questionsCount * 100;
            var step = 100 / _diagnoses.Count;
            var index = (int)percantage / step;
            return _diagnoses[Math.Min(index, _diagnoses.Count - 1)];
        }
    }
}