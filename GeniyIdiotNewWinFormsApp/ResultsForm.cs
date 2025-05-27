using GeniyIdiotNew.Common;

namespace GeniyIdiotNewWinFormsApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
            LoadResults();
        }

        private void LoadResults()
        {
            var results = UserResultsStorage.GetAll()
                .Select(r => new
                {
                    ФИО = $"{r.User.LastName} {r.User.FirstName}",
                    r.RightAnswersCount,
                    Диагноз = r.Diagnosis,
                    Дата = r.TestDateTime.ToString("dd.MM.yyyy HH:mm")
                }).ToList();

            resultsDataGridView.DataSource = results;
            resultsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}