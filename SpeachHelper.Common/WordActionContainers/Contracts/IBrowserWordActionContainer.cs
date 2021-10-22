using SpeachHelper.Common.CommandModel;

namespace SpeachHelper.Common.WordActionContainers.Contacts
{
    public interface IBrowserWordActionContainer
    {
        Command AddBrowserWebSiteAction(string command, string openedSite);
    }
}
