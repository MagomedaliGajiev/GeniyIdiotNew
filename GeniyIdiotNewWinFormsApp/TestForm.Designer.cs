namespace GeniyIdiotNewWinFormsApp
{
    partial class TestForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            questionNumberLabel = new Label();
            questionTextLabel = new Label();
            answerTextBox = new TextBox();
            nextButton = new Button();
            SuspendLayout();
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            questionNumberLabel.Location = new Point(20, 20);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(0, 37);
            questionNumberLabel.TabIndex = 0;
            // 
            // questionTextLabel
            // 
            questionTextLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            questionTextLabel.Location = new Point(20, 60);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(761, 106);
            questionTextLabel.TabIndex = 1;
            // 
            // answerTextBox
            // 
            answerTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            answerTextBox.Location = new Point(12, 209);
            answerTextBox.Name = "answerTextBox";
            answerTextBox.Size = new Size(278, 50);
            answerTextBox.TabIndex = 2;
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            nextButton.Location = new Point(645, 289);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(218, 63);
            nextButton.TabIndex = 3;
            nextButton.Text = "Далее";
            nextButton.Click += nextButton_Click;
            // 
            // TestForm
            // 
            ClientSize = new Size(931, 364);
            Controls.Add(questionNumberLabel);
            Controls.Add(questionTextLabel);
            Controls.Add(answerTextBox);
            Controls.Add(nextButton);
            Name = "TestForm";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label questionNumberLabel;
        private Label questionTextLabel;
        private TextBox answerTextBox;
        private Button nextButton;
    }
}