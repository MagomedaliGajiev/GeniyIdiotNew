namespace GeniyIdiotNewWinFormsApp
{
    partial class AddQuestionForm
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
            questionTextBox = new TextBox();
            answerNumeric = new NumericUpDown();
            saveButton = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)answerNumeric).BeginInit();
            SuspendLayout();
            // 
            // questionTextBox
            // 
            questionTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            questionTextBox.Location = new Point(12, 53);
            questionTextBox.Multiline = true;
            questionTextBox.Name = "questionTextBox";
            questionTextBox.Size = new Size(775, 80);
            questionTextBox.TabIndex = 0;
            // 
            // answerNumeric
            // 
            answerNumeric.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            answerNumeric.Location = new Point(12, 263);
            answerNumeric.Name = "answerNumeric";
            answerNumeric.Size = new Size(120, 50);
            answerNumeric.TabIndex = 1;
            // 
            // saveButton
            // 
            saveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            saveButton.Location = new Point(571, 248);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(216, 65);
            saveButton.TabIndex = 2;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 5);
            label1.Name = "label1";
            label1.Size = new Size(240, 45);
            label1.TabIndex = 3;
            label1.Text = "Текст вопроса";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 155);
            label2.Name = "label2";
            label2.Size = new Size(318, 45);
            label2.TabIndex = 4;
            label2.Text = "Правильный ответ";
            // 
            // AddQuestionForm
            // 
            ClientSize = new Size(904, 362);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(saveButton);
            Controls.Add(answerNumeric);
            Controls.Add(questionTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddQuestionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление нового вопроса";
            ((System.ComponentModel.ISupportInitialize)answerNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.NumericUpDown answerNumeric;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}