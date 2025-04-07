namespace GeniyIdiotNewConsoleApp
{
    public class DiagnosisCalculator
    {
        private static List<string> diagnoses = new List<string>
            { "кретин", "идиот", "дурак", "нормальный", "талант", "гений" };

        public static string GetDiagnosis(int rightAnswersCount, int totalQuestions)
        {
            if (totalQuestions == 0) return "не определен";

            var percentage = (double)rightAnswersCount / totalQuestions * 100;
            var step = 100.0 / diagnoses.Count;
            var index = (int)(percentage / step);
            return diagnoses[Math.Min(index, diagnoses.Count - 1)];
        }
    }
}