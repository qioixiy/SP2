using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SP.Forms
{
    public partial class Form节日与外出设定 : Form
    {
        public Form节日与外出设定()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            updateText1();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            updateText1();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            updateText1();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            updateText1();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            updateText1();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            updateText1();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            updateText1();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            updateText2();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            updateText2();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            updateText2();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            updateText2();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            updateText2();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            updateText2();
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            updateText2();
        }

        private void updateText1()
        {
            int num = 0;
            num += checkBox1.Checked ? 1 : 0;
            num += checkBox2.Checked ? 1 : 0;
            num += checkBox3.Checked ? 1 : 0;
            num += checkBox4.Checked ? 1 : 0;
            num += checkBox5.Checked ? 1 : 0;
            num += checkBox6.Checked ? 1 : 0;
            num += checkBox7.Checked ? 1 : 0;

            textBox1.Text = Convert.ToString(num);
        }

        private void updateText2()
        {
            int num = 0;
            num += checkBox8.Checked ? 1 : 0;
            num += checkBox9.Checked ? 1 : 0;
            num += checkBox10.Checked ? 1 : 0;
            num += checkBox11.Checked ? 1 : 0;
            num += checkBox12.Checked ? 1 : 0;
            num += checkBox13.Checked ? 1 : 0;
            num += checkBox14.Checked ? 1 : 0;

            textBox2.Text = Convert.ToString(num);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string getTextBox1Text()
        {
            return textBox1.Text;
        }

        public string getTextBox2Text()
        {
            return textBox2.Text;
        }

        public void setLabel3Text(string text)
        {
            label3.Text = text;
        }

        public void setLabel4Text(string text)
        {
            label4.Text = text;
        }

        public void setLabel5Text(string text)
        {
            label5.Text = text;
        }

        public void setLabel6Text(string text)
        {
            label6.Text = text;
        }

        public void setLabel7Text(string text)
        {
            label7.Text = text;
        }

        public void setLabel8Text(string text)
        {
            label8.Text = text;
        }

        public void setLabel9Text(string text)
        {
            label9.Text = text;
        }
    }
}
