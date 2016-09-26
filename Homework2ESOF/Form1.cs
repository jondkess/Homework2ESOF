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
            this.selectedTool = this.mTool;

            InitializeComponent();
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
            double num;
            if (string.IsNullOrEmpty(this.textBox1.Text.ToString()) == false && double.TryParse(this.textBox1.Text, out num))
            {
                this.listBox1.Items.Add(this.textBox1.Text);
                this.textBox1.Clear();
                this.textBox1.Select();
            }
            else
            {
                this.textBox1.Clear();
                MessageBox.Show("Input must be a number.", "Invalid input", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.listBox1.SelectedItem != null)
            {
                this.listBox1.Items.Remove(this.listBox1.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count > 0)
            {
                String sortedNums = "";
                int printCount = 1;
                int[] arrToSort = new int[this.listBox1.Items.Count];
                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    arrToSort[i] = Convert.ToInt32(this.listBox1.Items[i]);
                }
                int[] sortedArr = this.selectedTool.mathSort(arrToSort);
                
                foreach(int num in sortedArr)
                {
                    if (printCount != sortedArr.Count())
                    {
                        sortedNums += num + ", ";
                    }
                    else
                    {
                        sortedNums += num;
                    }
                    printCount++;
                }
                this.textBox2.Text = sortedNums;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox2.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter || (Keys)e.KeyChar == Keys.Return)
            {
                e.Handled = true;
                this.button1.PerformClick();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }
    }
}
