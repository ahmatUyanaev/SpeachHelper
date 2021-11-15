using SpeachHelper.Application.BizRules;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistence.Repository.Contracts;
using System;
using System.Windows.Forms;

namespace SpeachHelper.Forms
{
    public partial class EditCommandForm : Form
    {
        private ICommandsBizRules commandsBizRules;
        private Command editedCommand;
        private int commandId;

        private Action fillComboBox;

        public EditCommandForm(int commandId, Action fillComboBox)
        {
            InitializeComponent();
            this.fillComboBox = fillComboBox;
            this.commandId = commandId;
            commandsBizRules = ServiceLocator.GetService<ICommandsBizRules>();
            editedCommand = commandsBizRules.GetCommandById(commandId);
            commandName.Text = editedCommand.CommandName;
            argumentName.Text = editedCommand.Argument;
        }

        public bool CheckOfNull()
        {
            return string.IsNullOrEmpty(commandName.Text) && string.IsNullOrEmpty(argumentName.Text);
        }

        private async void editCommandBtn_Click(object sender, EventArgs e)
        {
            if (CheckOfNull())
            {
                MessageBox.Show("Error");
                return;
            }

            await commandsBizRules.EditCommandAsync(commandId, new Command(commandName.Text, argumentName.Text));
            fillComboBox.Invoke();
            this.Close();
        }
    }
}