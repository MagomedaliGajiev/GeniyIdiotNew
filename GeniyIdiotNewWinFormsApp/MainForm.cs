namespace GeniyIdiotNewWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            var menuStrip = new MenuStrip();

            var fileMenu = new ToolStripMenuItem("Меню");
            var startTestItem = new ToolStripMenuItem("Начать тест", null, (s, e) => new TestForm().ShowDialog());
            var manageQuestionsItem = new ToolStripMenuItem("Управление вопросами", null, (s, e) => new QuestionsManagerForm().ShowDialog());
            var showResultsItem = new ToolStripMenuItem("Результаты тестов", null, (s, e) => new ResultsForm().ShowDialog());
            var exitItem = new ToolStripMenuItem("Выход", null, (s, e) => Application.Exit());

            fileMenu.DropDownItems.AddRange(new[] { startTestItem, manageQuestionsItem, showResultsItem, exitItem });
            menuStrip.Items.Add(fileMenu);

            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
        }
    }
}