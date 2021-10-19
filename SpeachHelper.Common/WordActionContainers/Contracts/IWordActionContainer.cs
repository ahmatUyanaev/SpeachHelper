using System;
using System.Collections.Generic;

namespace SpeachHelper.Common.WordActionContainers.Contacts
{
    public interface IWordActionContainer
    {
        Dictionary<string, Action> GetActions();
    }
}
