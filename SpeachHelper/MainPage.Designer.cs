
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
            this.mainWindowContainer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.actionTextBox = new System.Windows.Forms.TextBox();
            this.wordsTextBox = new System.Windows.Forms.TextBox();
            this.addCommandBtn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.commandsBox = new System.Windows.Forms.ListBox();
            this.mainWindowContainer.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainWindowContainer
            // 
            this.mainWindowContainer.Controls.Add(this.tabPage1);
            this.mainWindowContainer.Controls.Add(this.tabPage2);
            this.mainWindowContainer.Controls.Add(this.tabPage3);
            this.mainWindowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindowContainer.Location = new System.Drawing.Point(0, 0);
            this.mainWindowContainer.Name = "mainWindowContainer";
            this.mainWindowContainer.SelectedIndex = 0;
            this.mainWindowContainer.Size = new System.Drawing.Size(802, 480);
            this.mainWindowContainer.TabIndex = 3;
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
            // tabPage2
            // 
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
            // actionTextBox
            // 
            this.actionTextBox.Location = new System.Drawing.Point(60, 118);
            this.actionTextBox.Name = "actionTextBox";
            this.actionTextBox.Size = new System.Drawing.Size(228, 22);
            this.actionTextBox.TabIndex = 2;
            // 
            // wordsTextBox
            // 
            this.wordsTextBox.Location = new System.Drawing.Point(60, 55);
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.commandsBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(794, 451);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // commandsBox
            // 
            this.commandsBox.FormattingEnabled = true;
            this.commandsBox.ItemHeight = 16;
            this.commandsBox.Location = new System.Drawing.Point(376, 129);
            this.commandsBox.Name = "commandsBox";
            this.commandsBox.Size = new System.Drawing.Size(302, 196);
            this.commandsBox.TabIndex = 0;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 480);
            this.Controls.Add(this.mainWindowContainer);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.mainWindowContainer.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl mainWindowContainer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox actionTextBox;
        private System.Windows.Forms.TextBox wordsTextBox;
        private System.Windows.Forms.Button addCommandBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox commandsBox;
    }
}

