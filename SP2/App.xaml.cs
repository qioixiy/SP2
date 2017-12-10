using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SP2
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        Login loginWinow;
        MainWindow mainWindow;
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            loginWinow = new Login();
            bool? ret = loginWinow.ShowDialog();

            if (ret == true)
            {
                // Create the startup window  
                mainWindow = new MainWindow();
                // Show the window  
                mainWindow.Show();
            }
        }
    }
}
