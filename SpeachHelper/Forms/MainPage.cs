using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Presentation;
using System.Windows.Forms;
using View = SpeachHelper.Presentation.View;

namespace SpeachHelper
{
    public partial class MainPage : Form
    {
        private ISpeachRecognizer recognizer;
        private IView view;

        public MainPage()
        {
            InitializeComponent();

            recognizer = ServiceLocator.GetService<ISpeachRecognizer>();

            view = new View(this);

            addCommandBtn.Click += (o, s) =>
            {
                view.AddCommand();
            };
            editCommandBtn.Click += (o, s) =>
            {
                view.EditCommand((string)commandsBox.SelectedItem);
            };

            commandsBox.SelectedIndexChanged += (o, s) =>
            {
                view.Init(selectedItem: commandsBox.SelectedItem);
                view.SelectedItemChange();
                wordLabel.Text = "Имя команды: " + view.WordsTextBox;
                actionLabel.Text = "Действие: " + view.ActionTextBox;
            };

            deleteCommandBtn.Click += (o, s) =>
            {
                view.DeleteCommand((string)commandsBox.SelectedItem);
                FillCombobox();
            };

            FillCombobox();

            recognizer.RecognizeAsync();
        }

        public void FillCombobox()
        {
            commandsBox.Items.Clear();
            foreach (string name in view.GetAllCommandNames())
            {
                commandsBox.Items.Add(name);
            }
        }

        #region trey
        private void trey_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                Activate();
                ShowInTaskbar = true;
                trey.Visible = false;
            }
        }

        private void MainPage_SizeChanged(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                trey.Visible = true;
            }
        }
        #endregion
    }
}