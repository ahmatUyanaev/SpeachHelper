using SpeachHelper.Application.BizRules;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Domain.Enums;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.InputSimulation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpeachHelper.Forms
{
    public partial class AddCommandForm : Form
    {
        private ICommandsBizRules commandsBizRules;
        private Action fillComboBox;
        private List<ComboBox> comboBoxes = new List<ComboBox>();

        public AddCommandForm(Action fillComboBox)
        {
            InitializeComponent();
            this.fillComboBox = fillComboBox;
            Init();
            commandsBizRules = ServiceLocator.GetService<ICommandsBizRules>();
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

            if (argumentName.Text.Contains("https"))
            {
                await commandsBizRules.AddCommandAsync(new Command(commandName.Text, argumentName.Text, CommandType.BrowserSite));
            }
            else if (argumentName.Text.Contains(".exe"))
            {
                await commandsBizRules.AddCommandAsync(new Command(commandName.Text, argumentName.Text, CommandType.WindowsProgram));
            }
            else if (hotkeyCheckBox.Checked)
            {
                var keys = GetHotKeys();
                await commandsBizRules.AddCommandAsync(new Command(commandName.Text, keys, CommandType.Hotkey));
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