namespace CursProj
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupButton = new System.Windows.Forms.Button();
            this.TeacherButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GroupButton
            // 
            this.GroupButton.Location = new System.Drawing.Point(117, 29);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.Size = new System.Drawing.Size(208, 65);
            this.GroupButton.TabIndex = 0;
            this.GroupButton.Text = "Список групп и их дисциплин";
            this.GroupButton.UseVisualStyleBackColor = true;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // TeacherButton
            // 
            this.TeacherButton.Location = new System.Drawing.Point(117, 100);
            this.TeacherButton.Name = "TeacherButton";
            this.TeacherButton.Size = new System.Drawing.Size(208, 70);
            this.TeacherButton.TabIndex = 1;
            this.TeacherButton.Text = "Список Преподавателей";
            this.TeacherButton.UseVisualStyleBackColor = true;
            this.TeacherButton.Click += new System.EventHandler(this.TeacherButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 70);
            this.button1.TabIndex = 2;
            this.button1.Text = "Посещение занятий";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 70);
            this.button2.TabIndex = 3;
            this.button2.Text = "Выполнение заданий";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(117, 328);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 70);
            this.button3.TabIndex = 4;
            this.button3.Text = "Оценка и рейтинг студента";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(117, 404);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 70);
            this.button4.TabIndex = 5;
            this.button4.Text = "Неуспевающие студенты";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 486);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TeacherButton);
            this.Controls.Add(this.GroupButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button TeacherButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

