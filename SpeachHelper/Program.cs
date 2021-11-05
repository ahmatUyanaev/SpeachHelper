using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Implements;
using SpeachHelper.InputSimulation.Implements;
using System;
using Ninject;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.Application.WordActionContainers.Contacts;

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
            using (IKernel ninjectKernel = new StandardKernel())
            {
                ninjectKernel.Bind<IBrowserInputSimulation>().To<EdgeInputSimulator>();
                ninjectKernel.Bind<IWindowsInputSimulator>().To<WindowsInputSimulator>();
                ninjectKernel.Bind<IWordActionContainer>().To<WindowsWordActionContainer>();
                ninjectKernel.Bind<IWordActionContainer>().To<EdgeWordActionContainer>();
                ninjectKernel.Bind<ISpeachRecognizer>().To<SpeachRecognizer>();
            }
        }
    }
}
