using SpeachHelper.Application.BizRules;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Domain.Enums;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.InputSimulation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace SpeachHelper.Forms
{
    public partial class AddCommandForm : Form
    {
        private readonly ICategoryBizRules _categoryBizRules;
        private ICommandsBizRules commandsBizRules;
        private Action fillComboBox;
        private List<ComboBox> comboBoxes = new List<ComboBox>();

        public AddCommandForm(Action fillComboBox)
        {
            InitializeComponent();
            this.fillComboBox = fillComboBox;
            commandsBizRules = ServiceLocator.GetService<ICommandsBizRules>();
            _categoryBizRules = ServiceLocator.GetService<ICategoryBizRules>();
            Init();
        }

        public bool CheckOfNull()
        {
            return string.IsNullOrEmpty(commandName.Text) && string.IsNullOrEmpty(argumentName.Text);
        }

        private async void addCommandBtn_Click(object sender, EventArgs e)
        {
            if (CheckOfNull())
            {
                MessageBox.Show("Error");
                return;
            }

            var catId = categoryList.SelectedIndex + 1;

            if (argumentName.Text.Contains("http"))
            {
                await commandsBizRules.AddCommandAsync(
                    new Command(commandName.Text, argumentName.Text, CommandType.BrowserSite, catId));
            }
            else if (argumentName.Text.Contains(".exe"))
            {
                await commandsBizRules.AddCommandAsync(
                    new Command(commandName.Text, argumentName.Text, CommandType.WindowsProgram, catId));
            }
            else if (hotkeyCheckBox.Checked)
            {
                var keys = GetHotKeys();
                await commandsBizRules.AddCommandAsync(
                    new Command(commandName.Text, keys, CommandType.Hotkey, catId));
            }
            else
            {
                await commandsBizRules.AddCommandAsync(
                    new Command(commandName.Text, argumentName.Text, CommandType.Empty, catId));
            }
            //при добовлений нужно обновить форму и показать новую команду сразу
            fillComboBox.Invoke();
            this.Close();
        }

        private void hotkeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hotkeyCheckBox.Checked)
            {
                argumentName.Hide();
                keyComboBox.Show();
                keyComboBoxTwo.Show();
                keyComboBoxThree.Show();
            }
            else
            {
                argumentName.Show();
                keyComboBox.Hide();
                keyComboBoxTwo.Hide();
                keyComboBoxThree.Hide();
            }
        }

        private void Init()
        {
            keyComboBox.Hide();
            keyComboBoxTwo.Hide();
            keyComboBoxThree.Hide();

            keyComboBox.Items.AddRange(HotKey.GetAllKeyBoardButtons().ToArray());
            keyComboBoxTwo.Items.AddRange(HotKey.GetAllKeyBoardButtons().ToArray());
            keyComboBoxThree.Items.AddRange(HotKey.GetAllKeyBoardButtons().ToArray());

            var catNames = Task.Run(async () => await _categoryBizRules.GetAllCategoryNames()).Result;
            categoryList.Items.AddRange(catNames.ToArray());
        }

        private string GetHotKeys()
        {
            if (string.IsNullOrEmpty((string)keyComboBox.SelectedItem))
            {
                MessageBox.Show("Введите команду");
            }

            return string.Join(" + ", new string[] { (string)keyComboBox.SelectedItem,
                (string)keyComboBoxTwo.SelectedItem, (string)keyComboBoxThree.SelectedItem});
        }
    }
}