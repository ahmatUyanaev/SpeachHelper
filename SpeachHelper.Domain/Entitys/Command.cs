using SpeachHelper.Domain.Enums;
using System;

namespace SpeachHelper.Domain.Entitys
{
    public class Command
    {
        public Command()
        {
        }

        public Command(string command, Action action)
        {
            CommandName = command;
            Action = action;
        }

        public Command(string command, Action action, string argument)
        {
            CommandName = command;
            Action = action;
            Argument = argument;
        }

        public string CommandName { get; private set; }

        public Action Action { get; set; }

        public string Argument { get; private set; }

        public CommandType CommandType { get; private set; }
    }
}