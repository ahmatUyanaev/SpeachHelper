
namespace SpeachHelper.Forms
{
    partial class AddCommandForm
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
            this.addCommandBtn = new System.Windows.Forms.Button();
            this.commandName = new System.Windows.Forms.TextBox();
            this.argumentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hotkeyCheckBox = new System.Windows.Forms.CheckBox();
            this.keyComboBox = new System.Windows.Forms.ComboBox();
            this.keyComboBoxTwo = new System.Windows.Forms.ComboBox();
            this.keyComboBoxThree = new System.Windows.Forms.ComboBox();
            this.categoryList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // addCommandBtn
            // 
            this.addCommandBtn.Location = new System.Drawing.Point(255, 170);
            this.addCommandBtn.Name = "addCommandBtn";
            this.addCommandBtn.Size = new System.Drawing.Size(158, 51);
            this.addCommandBtn.TabIndex = 0;
            this.addCommandBtn.Text = "Добавить ";
            this.addCommandBtn.UseVisualStyleBackColor = true;
            this.addCommandBtn.Click += new System.EventHandler(this.addCommandBtn_Click);
            // 
            // commandName
            // 
            this.commandName.Location = new System.Drawing.Point(12, 39);
            this.commandName.Name = "commandName";
            this.commandName.Size = new System.Drawing.Size(215, 22);
            this.commandName.TabIndex = 1;
            // 
            // argumentName
            // 
            this.argumentName.Location = new System.Drawing.Point(12, 95);
            this.argumentName.Name = "argumentName";
            this.argumentName.Size = new System.Drawing.Size(215, 22);
            this.argumentName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя команды";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Аргумент";
            // 
            // hotkeyCheckBox
            // 
            this.hotkeyCheckBox.AutoSize = true;
            this.hotkeyCheckBox.Location = new System.Drawing.Point(272, 19);
            this.hotkeyCheckBox.Name = "hotkeyCheckBox";
            this.hotkeyCheckBox.Size = new System.Drawing.Size(104, 21);
            this.hotkeyCheckBox.TabIndex = 5;
            this.hotkeyCheckBox.Text = "Это HotKey";
            this.hotkeyCheckBox.UseVisualStyleBackColor = true;
            this.hotkeyCheckBox.CheckedChanged += new System.EventHandler(this.hotkeyCheckBox_CheckedChanged);
            // 
            // keyComboBox
            // 
            this.keyComboBox.FormattingEnabled = true;
            this.keyComboBox.Location = new System.Drawing.Point(12, 95);
            this.keyComboBox.Name = "keyComboBox";
            this.keyComboBox.Size = new System.Drawing.Size(105, 24);
            this.keyComboBox.TabIndex = 6;
            // 
            // keyComboBoxTwo
            // 
            this.keyComboBoxTwo.FormattingEnabled = true;
            this.keyComboBoxTwo.Location = new System.Drawing.Point(123, 95);
            this.keyComboBoxTwo.Name = "keyComboBoxTwo";
            this.keyComboBoxTwo.Size = new System.Drawing.Size(105, 24);
            this.keyComboBoxTwo.TabIndex = 7;
            // 
            // keyComboBoxThree
            // 
            this.keyComboBoxThree.FormattingEnabled = true;
            this.keyComboBoxThree.Location = new System.Drawing.Point(233, 95);
            this.keyComboBoxThree.Name = "keyComboBoxThree";
            this.keyComboBoxThree.Size = new System.Drawing.Size(105, 24);
            this.keyComboBoxThree.TabIndex = 8;
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(12, 142);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(176, 24);
            this.categoryList.TabIndex = 9;
            // 
            // AddCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 229);
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.keyComboBoxThree);
            this.Controls.Add(this.keyComboBoxTwo);
            this.Controls.Add(this.keyComboBox);
            this.Controls.Add(this.hotkeyCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.argumentName);
            this.Controls.Add(this.commandName);
            this.Controls.Add(this.addCommandBtn);
            this.MaximumSize = new System.Drawing.Size(441, 276);
            this.MinimumSize = new System.Drawing.Size(441, 276);
            this.Name = "AddCommandForm";
            this.Text = "Добавить команду";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCommandBtn;
        private System.Windows.Forms.TextBox commandName;
        private System.Windows.Forms.TextBox argumentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox hotkeyCheckBox;
        private System.Windows.Forms.ComboBox keyComboBox;
        private System.Windows.Forms.ComboBox keyComboBoxTwo;
        private System.Windows.Forms.ComboBox keyComboBoxThree;
        private System.Windows.Forms.ComboBox categoryList;
    }
}