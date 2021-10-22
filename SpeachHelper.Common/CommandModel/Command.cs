using System;

namespace SpeachHelper.Common.CommandModel
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
        public string CommandName { get; set; }

        public Action Action { get; set; }
    }
}
