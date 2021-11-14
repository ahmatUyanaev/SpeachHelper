using System.Collections.Generic;
using System.Windows.Forms;

namespace SpeachHelper.Presentation
{
    public interface IView
    {
        string WordsTextBox { get; set; }

        string ActionTextBox { get; set; }

        void Init(string wordsTextBox = null, string actionTextBox = null, object selectedItem = null);

        void EditCommand(string commandName);

        void AddCommand();

        void DeleteCommand(string commandName);

        void SelectedItemChange();

        List<string> GetAllCommandNames();

        void FillCombobox(ListBox listBox);
    }
}
