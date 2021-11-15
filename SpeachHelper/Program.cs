using Autofac;
using SpeachHelper.Application.BizRules;
using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Application.WordActionContainers.Implements;
using SpeachHelper.Infrastructure.DI;
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
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var container = ContainerConfig.Configure();

            RegisterService();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainPage(container.Resolve<ISpeachRecognizer>()));
        }
        
        private static void RegisterService()
        {
            ServiceLocator.Register<ISessionFactory>(new SessionFactory());
            ServiceLocator.Register<ICommandsRepository>(new CommandsRepository());
            ServiceLocator.Register<IBrowserInputSimulation>(new EdgeInputSimulator());
            ServiceLocator.Register<IWindowsInputSimulator>(new WindowsInputSimulator());
            ServiceLocator.Register<IWordActionContainer>(new WordActionContainer());
            ServiceLocator.Register<ISpeachRecognizer>(new SpeachRecognizer(null));
            ServiceLocator.Register<ICommandsBizRules>(new CommandsBizRules());
        }
    }

    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainPage>();
            builder.RegisterType<SessionFactory>().As<ISessionFactory>();
            builder.RegisterType<CommandsRepository>().As<ICommandsRepository>();
            builder.RegisterType<WindowsInputSimulator>().As<IWindowsInputSimulator>();
            builder.RegisterType<WordActionContainer>().As<IWordActionContainer>();
            builder.RegisterType<SpeachRecognizer>().As<ISpeachRecognizer>();
            builder.RegisterType<CommandsBizRules>().As<ICommandsBizRules>();

            return builder.Build();
        }
    }
}