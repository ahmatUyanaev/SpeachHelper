using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Implements;
using SpeachHelper.Domain.DI;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.InputSimulation.Implements;
using SpeachHelper.Persistance.Session;
using SpeachHelper.Persistence.Repository.Contracts;
using SpeachHelper.Persistence.Repository.Implements;
using System;

namespace SpeachHelper
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.ц
        /// </summary>
        [STAThread]
        private static void Main()
        {
            RegisterService();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainPage());
        }

        private static void RegisterService()
        {
            ServiceLocator.Register<ISessionFactory>(new SessionFactory());
            ServiceLocator.Register<IBrowserInputSimulation>(new EdgeInputSimulator());
            ServiceLocator.Register<IWindowsInputSimulator>(new WindowsInputSimulator());
            ServiceLocator.Register(new WindowsWordActionContainer());
            ServiceLocator.Register(new EdgeWordActionContainer());
            ServiceLocator.Register<ISpeachRecognizer>(new SpeachRecognizer());
            ServiceLocator.Register<ICommandsRepository>(new CommandsRepository());
        }
    }
}