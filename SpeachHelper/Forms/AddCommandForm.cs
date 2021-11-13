using SpeachHelper.Domain.Entitys;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistence.Repository.Contracts;
using System;
using System.Windows.Forms;

namespace SpeachHelper.Forms
{
    public partial class AddCommandForm : Form
    {
        private ICommandsRepository commandsRepository;

        public AddCommandForm()
        {
            InitializeComponent();

            commandsRepository = ServiceLocator.GetService<ICommandsRepository>();
        }

        public bool CheckOfNull()
        {
            return string.IsNullOrEmpty(commandName.Text) && string.IsNullOrEmpty(argumentName.Text);
        }

        private void addCommandBtn_Click(object sender, EventArgs e)
        {
            if (!CheckOfNull())
            {
                commandsRepository.AddCommandAsync(new Command(commandName.Text, argumentName.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}