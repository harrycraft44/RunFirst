namespace RunFirst
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(569, 154);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(485, 1035);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19F);
            label1.Location = new Point(569, 100);
            label1.Name = "label1";
            label1.Size = new Size(252, 51);
            label1.TabIndex = 1;
            label1.Text = "SYSTEM INFO";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(827, 100);
            button1.Name = "button1";
            button1.Size = new Size(227, 48);
            button1.TabIndex = 2;
            button1.Text = "copy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(29, 134);
            button2.Name = "button2";
            button2.Size = new Size(470, 71);
            button2.TabIndex = 3;
            button2.Text = "run malwarebytes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19F);
            label2.Location = new Point(29, 50);
            label2.Name = "label2";
            label2.Size = new Size(388, 51);
            label2.TabIndex = 4;
            label2.Text = "troubleshooting steps";
            // 
            // button3
            // 
            button3.Location = new Point(29, 211);
            button3.Name = "button3";
            button3.Size = new Size(470, 71);
            button3.TabIndex = 5;
            button3.Text = "scan for corrupted files";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(29, 288);
            button4.Name = "button4";
            button4.Size = new Size(470, 71);
            button4.TabIndex = 6;
            button4.Text = "update drivers";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(29, 365);
            button5.Name = "button5";
            button5.Size = new Size(470, 71);
            button5.TabIndex = 7;
            button5.Text = "update windows";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(29, 992);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(485, 197);
            textBox2.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19F);
            label3.Location = new Point(29, 925);
            label3.Name = "label3";
            label3.Size = new Size(335, 51);
            label3.TabIndex = 9;
            label3.Text = "Recommendations";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 1201);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox2;
        private Label label3;
    }
}
