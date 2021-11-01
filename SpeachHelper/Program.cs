using SpeachHelper.Application.DI;
using SpeachHelper.Application.WordActionContainers.Implements;
using SpeachHelper.InputSimulation.Implements;
using SpeachHelper.Application.SpeachRecognition;
using System;
using System.Windows.Forms;

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
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainPage());
        }

        static void RegisterService()
        {
            ServiceLocator.Register(new EdgeInputSimulator());
            ServiceLocator.Register(new WindowsInputSimulator());
            ServiceLocator.Register(new WindowsWordActionContainer());
            ServiceLocator.Register(new EdgeWordActionContainer());
            ServiceLocator.Register(new SpeachRecognizer());
        }
    }
}
