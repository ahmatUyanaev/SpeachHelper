using SpeachHelper.Infrastructure.Entitys;

namespace SpeachHelper.Application.WordActionContainers.Contacts
{
    public interface IBrowserWordActionContainer : IWordActionContainer
    {
        Command AddBrowserWebSiteAction(string command, string openedSite);
    }
}