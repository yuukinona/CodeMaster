using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeMaster
{
    public partial class CodePage : Form
    {
        string id,code,name,comment,lang;
        CodeMassManager cmm = new CodeMassManager();
        CodeMass cm;

        private void initText()
        {
            this.SourceCode.Text = code;
            this.CodeName.Text = name;
            this.Comments.Text = comment;
            return;
        }

        public CodePage(CodeMass parent,string ID,string Code,string Name,string Comment,string language)
        {
            InitializeComponent();
            id = ID;
            code = Code;
            name = Name;
            comment = Comment;
            lang = language;
            cm = parent;
            initText();
            EditSwitch(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button2.Visible)
            {
                if (MessageBox.Show("Are you sure to delete this Source_Code?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    cmm.DeleteByID(Convert.ToInt32(id));
                    cm.UpdateSheet(sender, e);
                    this.Dispose();
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure to cancel the update?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    initText();
                    EditSwitch(false);
                    
                }
            }
        }

        private void EditSwitch(bool flag)
        {
            if (flag)
            {
                button2.Visible = false;
                button3.Visible = true;
                this.BackColor = Color.DarkGray;
                foreach (System.Windows.Forms.Control item in this.Controls)
                {
                    if (item is System.Windows.Forms.RichTextBox)
                    {
                        RichTextBox rb = (RichTextBox)item;
                        rb.ReadOnly = false;
                        rb.BackColor = Color.White;
                        rb.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                button2.Visible = true;
                button3.Visible = false;
                this.BackColor = Color.LawnGreen;
                foreach (System.Windows.Forms.Control item in this.Controls)
                {
                    if (item is System.Windows.Forms.RichTextBox)
                    {
                        RichTextBox rb = (RichTextBox)item;
                        rb.ReadOnly = true;
                        rb.BackColor = Color.Black;
                        rb.ForeColor = Color.LawnGreen;
                    }
                }
            }
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditSwitch(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to update and overwrite this Source_Code?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                name = CodeName.Text;
                code = SourceCode.Text;
                comment = Comments.Text;
                cmm.UpdateData(Convert.ToInt32(id), name, code, comment);
                cm.UpdateSheet(sender, e);
                EditSwitch(false);
            }
            else
            {
                if (MessageBox.Show("Are you sure Add this Source_Code as a new version?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    /*
                    int version=GetVersion(name);
                    if (version != -1)
                    {
                        version++;
                        name = name + " Ver " + version.ToString();
                        cmm.InsertData(name, lang, SourceCode.Text, Comments.Text);
                    }
                    else
                    {
                        cmm.UpdateData(Convert.ToInt32(id), name + " Ver 1");
                        if (CodeName.Text == name)
                        {
                            cmm.InsertData(name + " Ver 2", lang, SourceCode.Text, Comments.Text);
                        }
                        else
                        {
                            cmm.InsertData(name + " Ver 2 ;"+CodeName.Text, lang, SourceCode.Text, Comments.Text);
                        }
                        
                    }*/
                    cmm.InsertData(CodeName.Text, lang, SourceCode.Text, Comments.Text);

                    cm.UpdateSheet(sender, e);
                    EditSwitch(false);
                }
            }
        }

        private int GetVersion(string str)
        {
            int pos = str.LastIndexOf("Ver ");
            int v=-1;
            if (pos != -1)
            {
                v = 0;
                pos += 4;
                while (pos < str.Length)
                {
                    if ((str[pos] <= '9') && (str[pos] >= '0')) v = v * 10 + str[pos] - '0';
                    else return -1;
                    pos++;
                }
            }
            return v;
        }

    }
}
