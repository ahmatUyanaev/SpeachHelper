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
        private MainPage mainPage;

        public AddCommandForm(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;

            commandsBizRules = ServiceLocator.GetService<ICommandsBizRules>();
        }

        public bool CheckOfNull()
        {
            return string.IsNullOrEmpty(commandName.Text) && string.IsNullOrEmpty(argumentName.Text);
        }

        private void addCommandBtn_Click(object sender, EventArgs e)
        {
            if (CheckOfNull())
            {
                MessageBox.Show("Error");
                return;
            }

            if (argumentName.Text.Contains("https"))
            {
                commandsBizRules.AddCommandAsync(new Command(commandName.Text, argumentName.Text, CommandType.BrowserSite));
            }
            else if (argumentName.Text.Contains(".exe"))
            {
                commandsBizRules.AddCommandAsync(new Command(commandName.Text, argumentName.Text, CommandType.WindowsProgram));
            }
            else
            {
                commandsBizRules.AddCommandAsync(new Command(commandName.Text, argumentName.Text, CommandType.Empty));
            }

            mainPage.FillCombobox();
            this.Close();
        }
    }
}