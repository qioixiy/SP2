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
    public partial class Form清单打印 : Form
    {
        public Form清单打印()
        {
            InitializeComponent();
        }

        private void Form清单打印_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void Form清单打印_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
        }
    }
}
