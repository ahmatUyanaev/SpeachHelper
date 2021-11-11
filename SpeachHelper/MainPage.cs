﻿using SpeachHelper.Application.SpeachRecognition;
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

            view = new View();

            editCommandBtn.Click += (o, s) =>
            {
                view.Init(wordsTextBox: wordsTextBox.Text, actionTextBox: actionTextBox.Text);
                view.EditCommand();
            };

            commandsBox.SelectedIndexChanged += (o, s) =>
            {
                view.Init(selectedItem: commandsBox.SelectedItem);
                view.SelectedItemChange();
                wordsTextBox.Text = view.WordsTextBox;
                actionTextBox.Text = view.ActionTextBox;
            };

            allRadioButton.CheckedChanged += (o, s) =>
            {
                if (allRadioButton.Checked)
                {
                    commandsBox.Items.Clear();

                    foreach (string name in view.GetAllCommandNames())
                    {
                        commandsBox.Items.Add(name);
                    }
                }
            };

            browserRadioButton.CheckedChanged += (o, s) =>
            {
                if (browserRadioButton.Checked)
                {
                    commandsBox.Items.Clear();

                    foreach (string name in view.GetBrowserCommandNames())
                    {
                        commandsBox.Items.Add(name);
                    }
                }
            };

            windowsRadioButton.CheckedChanged += (o, s) =>
            {
                if (windowsRadioButton.Checked)
                {
                    commandsBox.Items.Clear();

                    foreach (string name in view.GetWindowsCommandNames())
                    {
                        commandsBox.Items.Add(name);
                    }
                }
            };

            foreach (string name in view.GetAllCommandNames())
            {
                commandsBox.Items.Add(name);
            }

            recognizer.RecognizeAsync();
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