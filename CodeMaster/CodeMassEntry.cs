using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace CodeMaster
{   

    public partial class CodeMassEntry : Form
    {
        CodeMassManager CMM;
        public static Insert Insert_Form;
        public static CodeMass CM;

        public CodeMassEntry()
        {
            InitializeComponent();
            CMM = new CodeMassManager();
            CMM.DeleteByName("11");
           // this.IsMdiContainer = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insert_Form = new Insert(this);
            //Insert_Form.MdiParent = this;
            this.Hide();
            Insert_Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CM = new CodeMass(this);
            this.Hide();
            CM.Show();
        }
    }
}
