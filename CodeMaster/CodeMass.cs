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
    public partial class CodeMass : Form
    {

        Timer Delay = new Timer();

        CodeMassEntry cme;
        CodeMassManager cmm=new CodeMassManager();
        public CodeMass(CodeMassEntry parent)
        {
            InitializeComponent();
            cme = parent;
            //this.richTextBox1.Text = cmm.ShowData("select * from CodeMass order by id");
            //this.richTextBox1.ReadOnly = true;
            this.dataGridView1.DataSource = cmm.GetDataByQuery();
            this.dataGridView1.DataMember = "T_CLASS";
            //this.dataGridView1.bi
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int i = 0; i < 6;i++ ) dataGridView1.Columns[i].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
            Font font = new Font("UTF-8", 15);
            dataGridView1.Font = font;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Width = 55;// AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].Width = 300;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].Width = 95;// = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].Width = 310;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].Width = 180;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].Width = 180;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[6].Width = 60;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Width = 1180;
            dataGridView1.Height = this.Height-30-this.richTextBox1.Height;
            this.Width = 1180;
            this.richTextBox1.Width = 1025;
            this.richTextBox1.SelectAll();
            this.richTextBox1.SelectionCharOffset = -4;
            Delay.Interval = 500;
            Delay.Tick += new System.EventHandler(this.UpdateSheet);

            this.richTextBox2.SelectionAlignment = HorizontalAlignment.Right;
            this.richTextBox2.SelectAll();
            this.richTextBox2.SelectionCharOffset = -6;

        }

        
        private void CodeMass_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            cme.Show();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Rows[index].Cells[i].Selected = true;
                }
                string code = dataGridView1.Rows[index].Cells[6].Value.ToString();

                CodePage cp = new CodePage(this, 
                                           dataGridView1.Rows[index].Cells[0].Value.ToString(), 
                                           code, 
                                           dataGridView1.Rows[index].Cells[1].Value.ToString(), 
                                           dataGridView1.Rows[index].Cells[3].Value.ToString(),
                                           dataGridView1.Rows[index].Cells[2].Value.ToString()
                                          );
                cp.Show();
                
            }
            catch { }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Rows[index].Cells[i].Selected = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Delay.Stop();
            Delay.Start();
        
        }

        public void UpdateSheet(object sender, EventArgs e)
        {
            if (this.richTextBox1.Text == "")
            {
                this.dataGridView1.DataSource = cmm.GetDataByQuery();
                this.dataGridView1.DataMember = "T_CLASS";
            }
            else
            {
                this.dataGridView1.DataSource = cmm.GetDataByQuery(this.richTextBox1.Text);
                this.dataGridView1.DataMember = "T_CLASS";
            }
            Delay.Stop();
            return;

        }
    }
}