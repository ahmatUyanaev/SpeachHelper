using SpeachHelper.Common.DI;
using SpeachHelper.Common.WordActionContainers.Contacts;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.InputSimulation.Implements;
using System;
using System.Collections.Generic;

namespace SpeachHelper.Common.WordActionContainers.Implements
{
    public class WindowsWordActionContainer : IWordActionContainer
    {
        private static Dictionary<string, Action> actions;

        private IWindowsInputSimulator windowsInputSimulator;

        public WindowsWordActionContainer()
        {
            windowsInputSimulator = ServiceLocator.GetService<WindowsInputSimulator>();
            actions = Mock();
        }

        private Dictionary<string, Action> Mock()
        {
            var dic = new Dictionary<string, Action>();

            dic.Add("Скопируй", windowsInputSimulator.Copy());
            dic.Add("Вставить", windowsInputSimulator.Paste());

            return dic;
        }

        public Dictionary<string, Action> GetActions()
        {
            return actions;
        }
    }
}
