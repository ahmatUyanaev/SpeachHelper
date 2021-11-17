
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
            this.trey = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deleteCommandBtn = new System.Windows.Forms.Button();
            this.addCommandBtn = new System.Windows.Forms.Button();
            this.actionLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.commandsBox = new System.Windows.Forms.ListBox();
            this.editCommandBtn = new System.Windows.Forms.Button();
            this.mainWindowContainer = new System.Windows.Forms.TabControl();
            this.categories_tab = new System.Windows.Forms.TabPage();
            this.tabPage2.SuspendLayout();
            this.mainWindowContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // trey
            // 
            this.trey.Icon = ((System.Drawing.Icon)(resources.GetObject("trey.Icon")));
            this.trey.Text = "Speach";
            this.trey.Visible = true;
            this.trey.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trey_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.deleteCommandBtn);
            this.tabPage2.Controls.Add(this.addCommandBtn);
            this.tabPage2.Controls.Add(this.actionLabel);
            this.tabPage2.Controls.Add(this.wordLabel);
            this.tabPage2.Controls.Add(this.commandsBox);
            this.tabPage2.Controls.Add(this.editCommandBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Команды";
            // 
            // deleteCommandBtn
            // 
            this.deleteCommandBtn.Location = new System.Drawing.Point(503, 403);
            this.deleteCommandBtn.Name = "deleteCommandBtn";
            this.deleteCommandBtn.Size = new System.Drawing.Size(132, 40);
            this.deleteCommandBtn.TabIndex = 12;
            this.deleteCommandBtn.Text = "Удалить";
            this.deleteCommandBtn.UseVisualStyleBackColor = true;
            // 
            // addCommandBtn
            // 
            this.addCommandBtn.Location = new System.Drawing.Point(641, 403);
            this.addCommandBtn.Name = "addCommandBtn";
            this.addCommandBtn.Size = new System.Drawing.Size(145, 40);
            this.addCommandBtn.TabIndex = 11;
            this.addCommandBtn.Text = "Добавить  команду";
            this.addCommandBtn.UseVisualStyleBackColor = true;
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(473, 105);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(47, 17);
            this.actionLabel.TabIndex = 5;
            this.actionLabel.Text = "Action";
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(473, 42);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(42, 17);
            this.wordLabel.TabIndex = 4;
            this.wordLabel.Text = "Word";
            // 
            // commandsBox
            // 
            this.commandsBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.commandsBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.commandsBox.FormattingEnabled = true;
            this.commandsBox.ItemHeight = 16;
            this.commandsBox.Location = new System.Drawing.Point(3, 3);
            this.commandsBox.Name = "commandsBox";
            this.commandsBox.Size = new System.Drawing.Size(311, 445);
            this.commandsBox.TabIndex = 3;
            // 
            // editCommandBtn
            // 
            this.editCommandBtn.Location = new System.Drawing.Point(320, 403);
            this.editCommandBtn.Name = "editCommandBtn";
            this.editCommandBtn.Size = new System.Drawing.Size(177, 40);
            this.editCommandBtn.TabIndex = 0;
            this.editCommandBtn.Text = "Редактировать команду";
            this.editCommandBtn.UseVisualStyleBackColor = true;
            // 
            // mainWindowContainer
            // 
            this.mainWindowContainer.Controls.Add(this.tabPage2);
            this.mainWindowContainer.Controls.Add(this.categories_tab);
            this.mainWindowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindowContainer.Location = new System.Drawing.Point(0, 0);
            this.mainWindowContainer.Name = "mainWindowContainer";
            this.mainWindowContainer.SelectedIndex = 0;
            this.mainWindowContainer.Size = new System.Drawing.Size(802, 480);
            this.mainWindowContainer.TabIndex = 3;
            // 
            // categories_tab
            // 
            this.categories_tab.Location = new System.Drawing.Point(4, 25);
            this.categories_tab.Name = "categories_tab";
            this.categories_tab.Padding = new System.Windows.Forms.Padding(3);
            this.categories_tab.Size = new System.Drawing.Size(794, 451);
            this.categories_tab.TabIndex = 2;
            this.categories_tab.Text = "Категорий";
            this.categories_tab.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(802, 480);
            this.Controls.Add(this.mainWindowContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "SpeachHelper";
            this.SizeChanged += new System.EventHandler(this.MainPage_SizeChanged);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.mainWindowContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon trey;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button deleteCommandBtn;
        private System.Windows.Forms.Button addCommandBtn;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.ListBox commandsBox;
        private System.Windows.Forms.Button editCommandBtn;
        private System.Windows.Forms.TabControl mainWindowContainer;
        private System.Windows.Forms.TabPage categories_tab;
    }
}

