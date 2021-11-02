﻿using Ninject;
using SpeachHelper.Application.Entitys;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.InputSimulation.Implements;
using System.Collections.Generic;

namespace SpeachHelper.Application.WordActionContainers.Implements
{
    public class WindowsWordActionContainer : IWordActionContainer
    {
        private IKernel ninjectKernel;

        private IWindowsInputSimulator windowsInputSimulator;
        private List<Command> commands;

        public WindowsWordActionContainer()
        {
            ninjectKernel = new StandardKernel();

            windowsInputSimulator = ninjectKernel.Get<WindowsInputSimulator>();
            FillMock();
        }

        private void FillMock()
        {
            commands = new List<Command>();
            commands.Add(new Command("Скопируй", windowsInputSimulator.Copy()));
            commands.Add(new Command("Вставить", windowsInputSimulator.Paste()));
            commands.Add(new Command("Переключи язык", windowsInputSimulator.ChangeLanguage()));
        }

        public List<Command> GetActions()
        {
            return commands;
        }
    }
}
