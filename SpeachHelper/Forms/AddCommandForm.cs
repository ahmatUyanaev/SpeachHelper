using SpeachHelper.Application.BizRules;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Domain.Enums;
using SpeachHelper.Infrastructure.DI;
using System;
using System.Windows.Forms;

namespace SpeachHelper.Forms
{
    public partial class AddCommandForm : Form
    {
        private ICommandsBizRules commandsBizRules;
        private Action fillComboBox;

        public AddCommandForm(Action fillComboBox)
        {
            InitializeComponent();
            this.fillComboBox = fillComboBox;

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
            else
            {
                await commandsBizRules.AddCommandAsync(new Command(commandName.Text, argumentName.Text, CommandType.Empty));
            }
            //при добовлений нужно обновить форму и показать новую команду сразу
            fillComboBox.Invoke();
            this.Close();
        }
    }
}