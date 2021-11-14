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

        public Command(string command, string argument)
        {
            CommandName = command;
            Argument = argument;
        }

        public Command(string command, string argument, CommandType type)
        {
            CommandName = command;
            Argument = argument;
            CommandType = type;
        }

        public void SetId(int id)
        {
            ID = id;
        }

        public int ID { get; private set; }

        public string CommandName { get; private set; }

        public Action Action { get; set; }

        public string Argument { get; private set; }

        public CommandType CommandType { get; private set; }
    }
}