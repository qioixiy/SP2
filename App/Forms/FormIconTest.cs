using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SP
{
    public partial class FormIconTest : Form
    {
        public FormIconTest()
        {
            InitializeComponent();
        }

        private void FormIconTest_Load(object sender, EventArgs e)
        {
            largeIcon = new IntPtr[250];
            smallIcon = new IntPtr[250];

            ExtractIconEx("shell32.dll", 0, largeIcon, smallIcon, 250);

            int i = 23;
            Icon ic = Icon.FromHandle(largeIcon[i]);
            ((PictureBox)this.Controls["pictureBox1"]).Image = ic.ToBitmap();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);

        [DllImport("Shell32.dll")]
        public extern static int ExtractIconEx(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon, int nIcons);

        public static IntPtr[] largeIcon;
        public static IntPtr[] smallIcon;
    }
}
