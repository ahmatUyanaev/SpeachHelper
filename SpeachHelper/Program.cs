using SpeachHelper.Application.BizRules;
using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Application.WordActionContainers.Implements;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistance.Session;
using SpeachHelper.Persistence.Repository.Contracts;
using SpeachHelper.Persistence.Repository.Implements;
using System;

namespace SpeachHelper
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
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
            ServiceLocator.Register<ICommandsRepository>(new CommandsRepository());
            ServiceLocator.Register<ICategoryRepository>(new CategoryRepository());
            ServiceLocator.Register<IWordActionContainer>(new WordActionContainer());
            ServiceLocator.Register<ISpeachRecognizer>(new SpeachRecognizer());
            ServiceLocator.Register<ICommandsBizRules>(new CommandsBizRules());

            ServiceLocator.Register<ICategoryBizRules>(new CategoryBizRules());
        }
    }
}