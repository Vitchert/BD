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
            this.SuspendLayout();
            // 
            // GroupButton
            // 
            this.GroupButton.Location = new System.Drawing.Point(117, 60);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.Size = new System.Drawing.Size(208, 60);
            this.GroupButton.TabIndex = 0;
            this.GroupButton.Text = "Список групп";
            this.GroupButton.UseVisualStyleBackColor = true;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // TeacherButton
            // 
            this.TeacherButton.Location = new System.Drawing.Point(117, 172);
            this.TeacherButton.Name = "TeacherButton";
            this.TeacherButton.Size = new System.Drawing.Size(208, 70);
            this.TeacherButton.TabIndex = 1;
            this.TeacherButton.Text = "Список Преподавателей";
            this.TeacherButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 450);
            this.Controls.Add(this.TeacherButton);
            this.Controls.Add(this.GroupButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button TeacherButton;
    }
}

