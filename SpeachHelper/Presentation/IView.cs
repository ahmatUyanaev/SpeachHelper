using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeachHelper.Presentation
{
    public interface IView
    {
        string WordsTextBox { get; set; }

        string ActionTextBox { get; set; }

        void EditCommand(string commandName);

        void AddCommand();

        Task DeleteCommandAsync(string commandName);

        void SelectedItemChange(object selectedItem);

        List<string> GetAllCommandNames();

        void FillCombobox(ListBox listBox, TreeView treeView);
    }
}
