using SpeachHelper.Domain.Entitys;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistence.Repository.Contracts;
using System;
using System.Windows.Forms;

namespace SpeachHelper.Forms
{
    public partial class EditCommandForm : Form
    {
        private ICommandsRepository commandsRepository;
        private Command editedCommand;
        private int commandId;

        public EditCommandForm(int commandId)
        {
            InitializeComponent();
            this.commandId = commandId;
            commandsRepository = ServiceLocator.GetService<ICommandsRepository>();
            editedCommand = commandsRepository.GetCommandById(commandId);
            commandName.Text = editedCommand.CommandName;
            argumentName.Text = editedCommand.Argument;
        }

        public bool CheckOfNull()
        {
            return string.IsNullOrEmpty(commandName.Text) && string.IsNullOrEmpty(argumentName.Text);
        }

        private void editCommandBtn_Click(object sender, EventArgs e)
        {
            if (!CheckOfNull())
            {
                commandsRepository.EditCommandAsync(commandId, new Command(commandName.Text, argumentName.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }


    }
}