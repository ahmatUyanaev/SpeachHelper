using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.Common.WordActionContainers.Contacts
{
    public interface IBrowserWordActionContainer
    {
        void AddBrowserWebSiteAction(string command, string openedSite);
    }
}
