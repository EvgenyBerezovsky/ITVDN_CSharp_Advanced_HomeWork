namespace Task003
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            buttonSearch = new Button();
            checkedListBox1 = new CheckedListBox();
            textBoxFileName = new TextBox();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 173);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(890, 497);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 123);
            button1.Name = "button1";
            button1.Size = new Size(105, 29);
            button1.TabIndex = 1;
            button1.Text = "Посмотреть";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(135, 123);
            button2.Name = "button2";
            button2.Size = new Size(106, 29);
            button2.TabIndex = 2;
            button2.Text = "Сжать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(808, 44);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 3;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 12);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(229, 92);
            checkedListBox1.TabIndex = 4;
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(247, 44);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(555, 27);
            textBoxFileName.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 682);
            Controls.Add(textBoxFileName);
            Controls.Add(checkedListBox1);
            Controls.Add(buttonSearch);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button buttonSearch;
        private CheckedListBox checkedListBox1;
        private TextBox textBoxFileName;
        private SaveFileDialog saveFileDialog1;
    }
}