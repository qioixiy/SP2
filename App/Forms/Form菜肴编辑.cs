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
    public partial class Form菜肴编辑 : Form
    {
        public Form菜肴编辑()
        {
            InitializeComponent();
        }

        private void Form菜肴编辑_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form原料编辑().ShowDialog();
        }
    }
}
