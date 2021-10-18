using System;
using System.Windows.Forms;

using SpeachHelper.Locator;
using SpeachHelper.SpeachRecognition;
using SpeachHelper.InputSimulation;

namespace SpeachHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.ц
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegisterService();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());
        }

        static void RegisterService()
        {
            ServiceLocator.Register(new EdgeInputSimulator());
            ServiceLocator.Register(new EdgeWordActionContainer());
            ServiceLocator.Register(new SpeachRecognizer());
        }
    }
}
