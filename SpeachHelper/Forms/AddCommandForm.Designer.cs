
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
            // AddCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 229);
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
    }
}