using SpeachHelper.Infrastructure.Entitys;
using System.Collections.Generic;

namespace SpeachHelper.Application.WordActionContainers.Contacts
{
    public interface IWordActionContainer
    {
        List<Command> GetActions();
    }
}