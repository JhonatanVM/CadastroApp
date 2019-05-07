using Autofac;
using System;
using System.Windows.Forms;

namespace CadastroApp.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                Application.Run(scope.Resolve<Form1>());
            }
        }
    }
}
