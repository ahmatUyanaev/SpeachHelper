using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.Common.WordActionContainers.Contacts
{
    public interface IWordActionContainer 
    {
        Dictionary<string, Action> GetActions();
    }
}
