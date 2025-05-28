using GeniyIdiotNew.Common.Repositories;

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
            var results = UserResultsRepository.GetAll()
                .Select(r => new
                {
                    ФИО = $"{r.User.LastName} {r.User.FirstName}",
                    r.RightAnswersCount,
                    Диагноз = r.Diagnosis,
                    Дата = r.TestDate.ToString("dd.MM.yyyy HH:mm")
                }).ToList();

            resultsDataGridView.DataSource = results;
            resultsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}