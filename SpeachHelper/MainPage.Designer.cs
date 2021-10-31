
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.commandsBox = new System.Windows.Forms.ListBox();
            this.actionTextBox = new System.Windows.Forms.TextBox();
            this.wordsTextBox = new System.Windows.Forms.TextBox();
            this.addCommandBtn = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.mainWindowContainer = new System.Windows.Forms.TabControl();
            this.wordLabel = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.windowsRadioButton = new System.Windows.Forms.RadioButton();
            this.browserRadioButton = new System.Windows.Forms.RadioButton();
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.mainWindowContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.allRadioButton);
            this.tabPage2.Controls.Add(this.browserRadioButton);
            this.tabPage2.Controls.Add(this.windowsRadioButton);
            this.tabPage2.Controls.Add(this.actionLabel);
            this.tabPage2.Controls.Add(this.wordLabel);
            this.tabPage2.Controls.Add(this.commandsBox);
            this.tabPage2.Controls.Add(this.actionTextBox);
            this.tabPage2.Controls.Add(this.wordsTextBox);
            this.tabPage2.Controls.Add(this.addCommandBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Редактировать команды";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // commandsBox
            // 
            this.commandsBox.FormattingEnabled = true;
            this.commandsBox.ItemHeight = 16;
            this.commandsBox.Location = new System.Drawing.Point(-4, 9);
            this.commandsBox.Name = "commandsBox";
            this.commandsBox.Size = new System.Drawing.Size(318, 420);
            this.commandsBox.TabIndex = 3;
            this.commandsBox.SelectedIndexChanged += new System.EventHandler(this.commandsBox_SelectedIndexChanged);
            // 
            // actionTextBox
            // 
            this.actionTextBox.Location = new System.Drawing.Point(526, 126);
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
            // addCommandBtn
            // 
            this.addCommandBtn.Location = new System.Drawing.Point(598, 356);
            this.addCommandBtn.Name = "addCommandBtn";
            this.addCommandBtn.Size = new System.Drawing.Size(156, 40);
            this.addCommandBtn.TabIndex = 0;
            this.addCommandBtn.Text = "Добавить команду";
            this.addCommandBtn.UseVisualStyleBackColor = true;
            this.addCommandBtn.Click += new System.EventHandler(this.addCommandBtnClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Команды";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(56, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(536, 307);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(523, 39);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(42, 17);
            this.wordLabel.TabIndex = 4;
            this.wordLabel.Text = "Word";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(523, 106);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(47, 17);
            this.actionLabel.TabIndex = 5;
            this.actionLabel.Text = "Action";
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
            this.windowsRadioButton.CheckedChanged += new System.EventHandler(this.windowsRadioButton_CheckedChanged);
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
            this.browserRadioButton.CheckedChanged += new System.EventHandler(this.browserRadioButton_CheckedChanged);
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
            this.allRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 480);
            this.Controls.Add(this.mainWindowContainer);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.mainWindowContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox commandsBox;
        private System.Windows.Forms.TextBox actionTextBox;
        private System.Windows.Forms.TextBox wordsTextBox;
        private System.Windows.Forms.Button addCommandBtn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabControl mainWindowContainer;
        private System.Windows.Forms.RadioButton browserRadioButton;
        private System.Windows.Forms.RadioButton windowsRadioButton;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.RadioButton allRadioButton;
    }
}

