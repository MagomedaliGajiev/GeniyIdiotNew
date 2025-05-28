using GeniyIdiotNew.Common.Models;
using GeniyIdiotNew.Common.Repositories;

namespace GeniyIdiotNewWinFormsApp
{
    public partial class QuestionsManagerForm : Form
    {
        private List<Question> questions;

        public QuestionsManagerForm()
        {
            InitializeComponent();
            LoadQuestions();
            questionsDataGridView.AutoGenerateColumns = true;
        }

        private void LoadQuestions()
        {
            questions = QuestionsRepository.GetAll();
            questionsDataGridView.DataSource = null;
            questionsDataGridView.DataSource = questions;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using var addQuestionForm = new AddQuestionForm();
            if (addQuestionForm.ShowDialog() == DialogResult.OK)
            {
                QuestionsRepository.Add(addQuestionForm.Question);
                LoadQuestions();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (questionsDataGridView.SelectedRows.Count == 0) return;

            var index = questionsDataGridView.SelectedRows[0].Index;
            QuestionsRepository.Remove(index);
            LoadQuestions();
        }
    }
}