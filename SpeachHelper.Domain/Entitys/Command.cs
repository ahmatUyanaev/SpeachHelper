using System;

namespace SpeachHelper.Application.Entitys
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

        public string CommandName { get; set; }

        public Action Action { get; set; }

        public string Argument { get; set; }
    }
}
