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
    public partial class Form食谱评估结果报告 : Form
    {
        public Form食谱评估结果报告()
        {
            InitializeComponent();
        }

        private void Form食谱评估结果报告_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
