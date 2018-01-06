using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLoginInstance = new FormLogin();
            FormMainWindowInstance = new FormMainWindow();

            Application.Run(new FormSplashScreen());
        }

        public static FormLogin FormLoginInstance;
        public static FormMainWindow FormMainWindowInstance;
    }
}
