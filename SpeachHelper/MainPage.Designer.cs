﻿
namespace SpeachHelper
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.keys = new System.Windows.Forms.ComboBox();
            this.pathOrHotheyBtn = new System.Windows.Forms.RadioButton();
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.browserRadioButton = new System.Windows.Forms.RadioButton();
            this.windowsRadioButton = new System.Windows.Forms.RadioButton();
            this.actionLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.commandsBox = new System.Windows.Forms.ListBox();
            this.actionTextBox = new System.Windows.Forms.TextBox();
            this.wordsTextBox = new System.Windows.Forms.TextBox();
            this.editCommandBtn = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mainWindowContainer = new System.Windows.Forms.TabControl();
            this.trey = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage2.SuspendLayout();
            this.mainWindowContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.keys);
            this.tabPage2.Controls.Add(this.pathOrHotheyBtn);
            this.tabPage2.Controls.Add(this.allRadioButton);
            this.tabPage2.Controls.Add(this.browserRadioButton);
            this.tabPage2.Controls.Add(this.windowsRadioButton);
            this.tabPage2.Controls.Add(this.actionLabel);
            this.tabPage2.Controls.Add(this.wordLabel);
            this.tabPage2.Controls.Add(this.commandsBox);
            this.tabPage2.Controls.Add(this.actionTextBox);
            this.tabPage2.Controls.Add(this.wordsTextBox);
            this.tabPage2.Controls.Add(this.editCommandBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Редактировать команды";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // keys
            // 
            this.keys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keys.FormattingEnabled = true;
            this.keys.Location = new System.Drawing.Point(388, 254);
            this.keys.Name = "keys";
            this.keys.Size = new System.Drawing.Size(165, 24);
            this.keys.TabIndex = 10;
            // 
            // pathOrHotheyBtn
            // 
            this.pathOrHotheyBtn.AutoSize = true;
            this.pathOrHotheyBtn.Location = new System.Drawing.Point(598, 150);
            this.pathOrHotheyBtn.Name = "pathOrHotheyBtn";
            this.pathOrHotheyBtn.Size = new System.Drawing.Size(118, 21);
            this.pathOrHotheyBtn.TabIndex = 9;
            this.pathOrHotheyBtn.TabStop = true;
            this.pathOrHotheyBtn.Text = "pathOrHothey";
            this.pathOrHotheyBtn.UseVisualStyleBackColor = true;
            // 
            // allRadioButton
            // 
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Checked = true;
            this.allRadioButton.Location = new System.Drawing.Point(320, 113);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(44, 21);
            this.allRadioButton.TabIndex = 8;
            this.allRadioButton.TabStop = true;
            this.allRadioButton.Text = "All";
            this.allRadioButton.UseVisualStyleBackColor = true;
            // 
            // browserRadioButton
            // 
            this.browserRadioButton.AutoSize = true;
            this.browserRadioButton.Location = new System.Drawing.Point(320, 86);
            this.browserRadioButton.Name = "browserRadioButton";
            this.browserRadioButton.Size = new System.Drawing.Size(80, 21);
            this.browserRadioButton.TabIndex = 7;
            this.browserRadioButton.Text = "Browser";
            this.browserRadioButton.UseVisualStyleBackColor = true;
            // 
            // windowsRadioButton
            // 
            this.windowsRadioButton.AutoSize = true;
            this.windowsRadioButton.Location = new System.Drawing.Point(320, 59);
            this.windowsRadioButton.Name = "windowsRadioButton";
            this.windowsRadioButton.Size = new System.Drawing.Size(85, 21);
            this.windowsRadioButton.TabIndex = 6;
            this.windowsRadioButton.Text = "Windows";
            this.windowsRadioButton.UseVisualStyleBackColor = true;
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(523, 150);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(47, 17);
            this.actionLabel.TabIndex = 5;
            this.actionLabel.Text = "Action";
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(523, 39);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(42, 17);
            this.wordLabel.TabIndex = 4;
            this.wordLabel.Text = "Word";
            // 
            // commandsBox
            // 
            this.commandsBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.commandsBox.FormattingEnabled = true;
            this.commandsBox.ItemHeight = 16;
            this.commandsBox.Location = new System.Drawing.Point(3, 3);
            this.commandsBox.Name = "commandsBox";
            this.commandsBox.Size = new System.Drawing.Size(311, 445);
            this.commandsBox.TabIndex = 3;
            // 
            // actionTextBox
            // 
            this.actionTextBox.Location = new System.Drawing.Point(526, 184);
            this.actionTextBox.Name = "actionTextBox";
            this.actionTextBox.Size = new System.Drawing.Size(228, 22);
            this.actionTextBox.TabIndex = 2;
            // 
            // wordsTextBox
            // 
            this.wordsTextBox.Location = new System.Drawing.Point(526, 59);
            this.wordsTextBox.Name = "wordsTextBox";
            this.wordsTextBox.Size = new System.Drawing.Size(228, 22);
            this.wordsTextBox.TabIndex = 1;
            // 
            // editCommandBtn
            // 
            this.editCommandBtn.Location = new System.Drawing.Point(598, 403);
            this.editCommandBtn.Name = "editCommandBtn";
            this.editCommandBtn.Size = new System.Drawing.Size(188, 40);
            this.editCommandBtn.TabIndex = 0;
            this.editCommandBtn.Text = "Редактировать команду";
            this.editCommandBtn.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Команды";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mainWindowContainer
            // 
            this.mainWindowContainer.Controls.Add(this.tabPage1);
            this.mainWindowContainer.Controls.Add(this.tabPage2);
            this.mainWindowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindowContainer.Location = new System.Drawing.Point(0, 0);
            this.mainWindowContainer.Name = "mainWindowContainer";
            this.mainWindowContainer.SelectedIndex = 0;
            this.mainWindowContainer.Size = new System.Drawing.Size(802, 480);
            this.mainWindowContainer.TabIndex = 3;
            // 
            // trey
            // 
            this.trey.Icon = ((System.Drawing.Icon)(resources.GetObject("trey.Icon")));
            this.trey.Text = "Speach";
            this.trey.Visible = true;
            this.trey.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trey_MouseDoubleClick);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 480);
            this.Controls.Add(this.mainWindowContainer);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.MainPage_SizeChanged);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.mainWindowContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox commandsBox;
        private System.Windows.Forms.TextBox actionTextBox;
        private System.Windows.Forms.TextBox wordsTextBox;
        private System.Windows.Forms.Button editCommandBtn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl mainWindowContainer;
        private System.Windows.Forms.RadioButton browserRadioButton;
        private System.Windows.Forms.RadioButton windowsRadioButton;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.NotifyIcon trey;
        private System.Windows.Forms.RadioButton pathOrHotheyBtn;
        private System.Windows.Forms.ComboBox keys;
    }
}

