using SpeachHelper.Locator;
using SpeachHelper.SpeachRecognition;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeachHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegisterService();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void RegisterService()
        {
            ServiceLocator.Register(new GrammarContainer());
            ServiceLocator.Register(new SpeachRecognizer());
        }
    }
}
