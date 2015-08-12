namespace CodeMaster
{
    partial class Insert
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
            this.code = new System.Windows.Forms.RichTextBox();
            this.name = new System.Windows.Forms.RichTextBox();
            this.comments = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.language = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(0, 106);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(671, 335);
            this.code.TabIndex = 1;
            this.code.Text = "Source_Code";
            this.code.TextChanged += new System.EventHandler(this.code_TextChanged);
            this.code.Enter += new System.EventHandler(this.code_Enter);
            this.code.Leave += new System.EventHandler(this.code_Leave);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(2, 3);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(465, 48);
            this.name.TabIndex = 2;
            this.name.Text = "Code_Name";
            this.name.Click += new System.EventHandler(this.name_Click);
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            this.name.Enter += new System.EventHandler(this.name_Enter);
            this.name.Leave += new System.EventHandler(this.name_Leave);
            // 
            // comments
            // 
            this.comments.Location = new System.Drawing.Point(0, 55);
            this.comments.Name = "comments";
            this.comments.Size = new System.Drawing.Size(671, 48);
            this.comments.TabIndex = 4;
            this.comments.Text = "Comments";
            this.comments.Click += new System.EventHandler(this.comments_Click);
            this.comments.TextChanged += new System.EventHandler(this.comments_TextChanged);
            this.comments.Enter += new System.EventHandler(this.comments_Enter);
            this.comments.Leave += new System.EventHandler(this.comments_Leave);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(582, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "GO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // language
            // 
            this.language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.language.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.language.FormattingEnabled = true;
            this.language.Items.AddRange(new object[] {
            "c++",
            "c#",
            "c",
            "Java"});
            this.language.Location = new System.Drawing.Point(483, 10);
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(83, 35);
            this.language.TabIndex = 9;
            this.language.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(670, 440);
            this.Controls.Add(this.language);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comments);
            this.Controls.Add(this.name);
            this.Controls.Add(this.code);
            this.Name = "Insert";
            this.Text = "Insert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Insert_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox code;
        private System.Windows.Forms.RichTextBox name;
        private System.Windows.Forms.RichTextBox comments;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox language;
    }
}