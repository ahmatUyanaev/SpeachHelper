
namespace SpeachHelper.Forms
{
    partial class EditCommandForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.argumentName = new System.Windows.Forms.TextBox();
            this.commandName = new System.Windows.Forms.TextBox();
            this.addCommandBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Аргумент";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Имя команды";
            // 
            // argumentName
            // 
            this.argumentName.Location = new System.Drawing.Point(11, 89);
            this.argumentName.Name = "argumentName";
            this.argumentName.Size = new System.Drawing.Size(215, 22);
            this.argumentName.TabIndex = 7;
            // 
            // commandName
            // 
            this.commandName.Location = new System.Drawing.Point(11, 33);
            this.commandName.Name = "commandName";
            this.commandName.Size = new System.Drawing.Size(215, 22);
            this.commandName.TabIndex = 6;
            // 
            // addCommandBtn
            // 
            this.addCommandBtn.Location = new System.Drawing.Point(254, 164);
            this.addCommandBtn.Name = "addCommandBtn";
            this.addCommandBtn.Size = new System.Drawing.Size(158, 51);
            this.addCommandBtn.TabIndex = 5;
            this.addCommandBtn.Text = "Редактировать";
            this.addCommandBtn.UseVisualStyleBackColor = true;
            this.addCommandBtn.Click += new System.EventHandler(this.editCommandBtn_Click);
            // 
            // EditCommandForm
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
            this.Name = "EditCommandForm";
            this.Text = "EditCommandForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox argumentName;
        private System.Windows.Forms.TextBox commandName;
        private System.Windows.Forms.Button addCommandBtn;
    }
}