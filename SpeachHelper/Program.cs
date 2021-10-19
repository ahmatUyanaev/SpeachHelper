using System;
using System.Windows.Forms;

using SpeachHelper.Common.DI;
using SpeachHelper.SpeachRecognition;
using SpeachHelper.InputSimulation.Implements;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.Common.WordActionContainers.Implements;

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
            ServiceLocator.Register(new WindowsInputSimulator());
            ServiceLocator.Register(new WindowsWordActionContainer());
            ServiceLocator.Register(new EdgeWordActionContainer());
            ServiceLocator.Register(new SpeachRecognizer());
        }
    }
}
