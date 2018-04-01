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
            try//这里使用到的语句是：太try ...catch....finally语句，
            //对可能产生异常的程序代码进行监控。try里放的是被监控的代码
            {
                Application.EnableVisualStyles();//固定的
                Application.SetCompatibleTextRenderingDefault(false);//固定的

                FormLoginInstance = new FormLogin();//使用new关键字创建一个应用对象，实例化
                FormMainWindowInstance = new FormMainWindow();//实例化，在try语句里执行这两个窗体

                Application.Run(new FormSplashScreen());//这里是固定的，不过可以在run的方法，实现想要的启动窗体。
            }
            catch
            {
                //这里catch是处理异常语句。
            }
            finally
            {
                //最后执行的程序
            }
        }

        public static FormLogin FormLoginInstance;//创建一个公共函数，
        public static FormMainWindow FormMainWindowInstance;
    }
}//