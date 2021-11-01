using SpeachHelper.Application.Entitys;

namespace SpeachHelper.Application.WordActionContainers.Contacts
{
    public interface IBrowserWordActionContainer
    {
        Command AddBrowserWebSiteAction(string command, string openedSite);
    }
}
