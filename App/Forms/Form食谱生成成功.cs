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
    public partial class Form食谱生成成功 : Form
    {
        public Form食谱生成成功()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form食谱评估结果报告().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                new Form食谱公布表打印().ShowDialog();
            }
            catch
            {
                MessageBox.Show("发生异常");
            }
            finally
            {

            }
        }
    }
}
