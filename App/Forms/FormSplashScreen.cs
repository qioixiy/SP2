using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP
{
    public partial class FormSplashScreen : Form
    {
        public FormSplashScreen()
        {
            InitializeComponent();
        }

        private void FormSplashScreen_Load(object sender, EventArgs e)
        {
            ;
        }

        private void FormSplashScreen_Click(object sender, EventArgs e)
        {
            DialogResult result = Program.FormLoginInstance.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                ;
            }
            else if (result == DialogResult.OK)
            {
                Program.FormMainWindowInstance.ShowDialog();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
