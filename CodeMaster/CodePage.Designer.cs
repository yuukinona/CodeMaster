namespace CodeMaster
{
    partial class CodePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodePage));
            this.SourceCode = new System.Windows.Forms.RichTextBox();
            this.CodeName = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Comments = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SourceCode
            // 
            this.SourceCode.BackColor = System.Drawing.SystemColors.InfoText;
            this.SourceCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SourceCode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceCode.ForeColor = System.Drawing.Color.LawnGreen;
            this.SourceCode.Location = new System.Drawing.Point(0, 99);
            this.SourceCode.Name = "SourceCode";
            this.SourceCode.Size = new System.Drawing.Size(776, 702);
            this.SourceCode.TabIndex = 0;
            this.SourceCode.Text = "";
            // 
            // CodeName
            // 
            this.CodeName.BackColor = System.Drawing.SystemColors.InfoText;
            this.CodeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CodeName.Font = new System.Drawing.Font("Consolas", 12F);
            this.CodeName.Location = new System.Drawing.Point(1, 0);
            this.CodeName.Name = "CodeName";
            this.CodeName.Size = new System.Drawing.Size(775, 45);
            this.CodeName.TabIndex = 2;
            this.CodeName.Text = "";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(735, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Comments
            // 
            this.Comments.BackColor = System.Drawing.SystemColors.InfoText;
            this.Comments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Comments.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comments.Location = new System.Drawing.Point(1, 50);
            this.Comments.Name = "Comments";
            this.Comments.Size = new System.Drawing.Size(775, 45);
            this.Comments.TabIndex = 3;
            this.Comments.Text = "";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(735, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(735, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CodePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.ClientSize = new System.Drawing.Size(776, 801);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Comments);
            this.Controls.Add(this.CodeName);
            this.Controls.Add(this.SourceCode);
            this.Name = "CodePage";
            this.Text = "CodePage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox SourceCode;
        private System.Windows.Forms.RichTextBox CodeName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox Comments;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        //private System.Windows.Forms.Button button1;
    }
}