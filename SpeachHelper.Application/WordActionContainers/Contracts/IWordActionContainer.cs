using SpeachHelper.Domain.Entitys;
using System.Collections.Generic;

namespace SpeachHelper.Application.WordActionContainers.Contacts
{
    public interface IWordActionContainer
    {
        List<Command> GetActions();
        void AddCommand(Command command);

        void DeleteCommand(int commandId);
        void EditCommand(int commandId, Command editedCommand);

        //void AddCommand(Command command);

    }
}