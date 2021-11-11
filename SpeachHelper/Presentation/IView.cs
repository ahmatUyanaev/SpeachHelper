using System.Collections.Generic;

namespace SpeachHelper.Presentation
{
    public interface IView
    {
        string WordsTextBox { get; set; }

        string ActionTextBox { get; set; }

        void Init(string wordsTextBox = null, string actionTextBox = null, object selectedItem = null);

        void EditCommand();

        void SelectedItemChange();

        List<string> GetAllCommandNames();

        List<string> GetBrowserCommandNames();

        List<string> GetWindowsCommandNames();
    }
}
