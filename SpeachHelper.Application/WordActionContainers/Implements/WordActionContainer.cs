﻿using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Domain.Enums;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.InputSimulation;
using SpeachHelper.Persistence.Repository.Contracts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpeachHelper.Application.WordActionContainers.Implements
{
    public class WordActionContainer : IBrowserWordActionContainer, IWordActionContainer
    {
        private List<Command> commands;
        private ICommandsRepository commandsRepository;

        public WordActionContainer()
        {
            commandsRepository = ServiceLocator.GetService<ICommandsRepository>();
        }

        private async Task<List<Command>> GetCommandsAsync()
        {
            return await commandsRepository.GetCommandsAsync();
        }

        public List<Command> GetActions()
        {
            if (commands == null)
            {
                commands = GetCommandsAsync().Result;
                MapArgument(commands);
                return commands;
            }

            return commands;
        }

        public Command AddBrowserWebSiteAction(string command, string openedSite)
        {
            commands.Add(new Command(command, () => Process.Start(openedSite)));
            return commands.Last();
        }

        private void MapArgument(List<Command> commands)
        {
            foreach (var command in commands)
            {
                if (command.CommandType == CommandType.Hotkey)
                {
                    command.Action = HotKey.MapToInputSimulator(command.Argument);
                }
                if (command.CommandType == CommandType.BrowserSite)
                {
                    command.Action = () => { Process.Start(command.Argument); };
                }
                if (command.CommandType == CommandType.WindowsProgram)
                {
                    command.Action = () => { Process.Start(command.Argument); };
                }
            }
        }

        public void AddCommand(Command command)
        {
            commands.Add(command);
        }

        public void DeleteCommand(int commandId)
        {
            var removeCommand = commands.FirstOrDefault(c => c.ID == commandId);
            commands.Remove(removeCommand);
        }

        public void EditCommand(int commandId, Command editedCommand)
        {
            var command = commands.FirstOrDefault(c => c.ID == commandId);
            commands.Remove(command);
            editedCommand.SetId(commandId);
            commands.Add(editedCommand);
        }
    }
}