using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2ESOF
{
    public partial class Form1 : Form
    {
        SoftwareTool myMath = new MyMath();
        SoftwareTool mTool = new MTool();
        SoftwareTool mathematica = new Mathematica();
        List<SoftwareTool> tools = new List<SoftwareTool>();
        SoftwareTool selectedTool;

        public Form1()
        {
            this.tools.Add(myMath);
            this.tools.Add(mTool);
            this.tools.Add(mathematica);
            this.selectedTool = this.myMath;

            InitializeComponent();
            //foreach (var sort in Enum.GetValues(typeof(Sort)))
            //{
            //    comboBox2.Items.Add(sort);
            //}
            comboBox2.DataSource = Enum.GetValues(typeof(Sort));
            comboBox1.DataSource = tools;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedTool = (SoftwareTool)comboBox1.SelectedValue;
            this.comboBox2.SelectedItem = (Sort)this.selectedTool.Default;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedTool.setSortStrategy((Sort)this.comboBox2.SelectedValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text.ToString()) == false)
            {
                this.listBox1.Items.Add(this.textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.listBox1.SelectedItem != null)
            {
                this.listBox1.Items.Remove(this.listBox1.SelectedItem);
            }
        }
    }
}
