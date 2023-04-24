namespace FuturesReportParser
{
    partial class Form_FuturesReportParser
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
            button1 = new Button();
            textBox1 = new TextBox();
            comboBox_1 = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(457, 8);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(73, 23);
            button1.TabIndex = 0;
            button1.Text = "選取";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(142, 9);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(312, 23);
            textBox1.TabIndex = 1;
            // 
            // comboBox_1
            // 
            comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_1.FormattingEnabled = true;
            comboBox_1.IntegralHeight = false;
            comboBox_1.Items.AddRange(new object[] { "總表", "區期選", "期貨", "期貨夜", "期貨大額", "選擇權", "選擇權夜", "選擇權大額", "選擇權買賣", "選擇權買賣夜", "選PCR" });
            comboBox_1.Location = new Point(19, 9);
            comboBox_1.Margin = new Padding(2);
            comboBox_1.Name = "comboBox_1";
            comboBox_1.Size = new Size(118, 23);
            comboBox_1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            button2.Location = new Point(535, 8);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(73, 23);
            button2.TabIndex = 0;
            button2.Text = "匯入";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(25, 59);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(568, 268);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // Form_FuturesReportParser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 355);
            Controls.Add(richTextBox1);
            Controls.Add(comboBox_1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "Form_FuturesReportParser";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private ComboBox comboBox_1;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private RichTextBox richTextBox1;
    }
}