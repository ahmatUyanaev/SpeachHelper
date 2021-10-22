using SpeachHelper.Common.CommandModel;
using System;
using System.Collections.Generic;

namespace SpeachHelper.Common.WordActionContainers.Contacts
{
    public interface IWordActionContainer
    {
        List<Command> GetActions();
    }
}
