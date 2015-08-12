using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLiteQueryBrowser;
using System.Data.SQLite;

namespace CodeMaster
{
    public partial class Insert : Form
    {
        //string name, string language, string code, string comments
        CodeMassManager CMM=new CodeMassManager();
        CodeMassEntry cme;
        public Insert(CodeMassEntry parent)
        {
            InitializeComponent();

            cme = parent;
            
            Font font = new Font("UTF-8", 11);
            name.Font = font;
            comments.Font = font;
            code.Font = font;
            name.SelectionAlignment = HorizontalAlignment.Left;     

            comments.SelectionAlignment = HorizontalAlignment.Left;
            comments.SelectAll();
            comments.SelectionColor = Color.Gray;
            comments.SelectionCharOffset = -14;
        }

        private void Insert_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            cme.Show();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((name.Text == "") || (code.Text == ""))
            {
                MessageBox.Show("Please type in the name or the source code!");
                return;
            }
            if (language.Text == "")
            {
                MessageBox.Show("Please choose the Language!");
                return;
            }
            CMM.InsertData(name.Text.ToString(),
                           language.Text.ToString(),
                           code.Text.ToString(),
                           comments.Text.ToString());
            MessageBox.Show("You add one piece of Code succesfully!");
            this.Dispose();
            cme.Show();  
        }

        private void name_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comments_Click(object sender, EventArgs e)
        {
        }
        
        private void name_TextChanged(object sender, EventArgs e)
        {
            DealWithBackWords(name, "Code_Name", 1);
        }

        private void name_Enter(object sender, EventArgs e)
        {
            DealWithBackWords(name, "Code_Name", 2);
        }

        private void name_Leave(object sender, EventArgs e)
        {
            DealWithBackWords(name, "Code_Name", 3);
            
        }

        private void comments_TextChanged(object sender, EventArgs e)
        {

            DealWithBackWords(comments, "Comments", 1);
        }

        private void comments_Enter(object sender, EventArgs e)
        {
            DealWithBackWords(comments, "Comments", 2);
        }

        private void comments_Leave(object sender, EventArgs e)
        {
            DealWithBackWords(comments, "Comments", 3);

        }
        private void code_TextChanged(object sender, EventArgs e)
        {
            DealWithBackWords(code, "Source_Code", 1);
        }

        private void code_Enter(object sender, EventArgs e)
        {
            DealWithBackWords(code, "Source_Code", 2);
        }

        private void code_Leave(object sender, EventArgs e)
        {
            DealWithBackWords(code, "Source_Code", 3);

        }

        private void DealWithBackWords(RichTextBox rt, string DefaultStr,int tag)
        {
            switch(tag)
            {
                case 1:
                    {
                        if (rt.Text == DefaultStr) SetBackWords(rt, DefaultStr, true);
                        else SetBackWords(rt, DefaultStr, false);
                        break;
                    }
                case 2:
                    {
                        if (rt.Text == DefaultStr) { rt.Text = ""; SetBackWords(rt, DefaultStr, false); }
                        break;
                    }
                case 3:
                    {
                        if (rt.Text.Length == 0) SetBackWords(rt, DefaultStr, true);
                        break; 
                    }
            }
            return;
        }

        private void SetBackWords(RichTextBox rt ,string Defaultstr,bool avtive)
        {
            if (avtive)
            {
                rt.Text = Defaultstr;
                rt.SelectAll();
                rt.SelectionColor = Color.Gray;
                rt.SelectionCharOffset = -14;
                rt.Select(rt.Text.Length, rt.Text.Length);
            }
            else
            {
                rt.SelectAll();
                rt.SelectionColor = Color.Black;
                rt.SelectionCharOffset = -14;
                rt.Select(rt.Text.Length, rt.Text.Length);
            }
            return;
        }
    }
}
