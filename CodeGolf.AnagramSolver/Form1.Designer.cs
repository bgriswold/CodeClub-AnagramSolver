namespace CodeGolf.AnagramSolver
{
    partial class Form1
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
            this.WordTextbox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.AnagramListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // WordTextbox
            // 
            this.WordTextbox.Location = new System.Drawing.Point(12, 12);
            this.WordTextbox.Name = "WordTextbox";
            this.WordTextbox.Size = new System.Drawing.Size(174, 20);
            this.WordTextbox.TabIndex = 1;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(63, 38);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // AnagramListBox
            // 
            this.AnagramListBox.FormattingEnabled = true;
            this.AnagramListBox.Location = new System.Drawing.Point(12, 69);
            this.AnagramListBox.Name = "AnagramListBox";
            this.AnagramListBox.Size = new System.Drawing.Size(174, 277);
            this.AnagramListBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 385);
            this.Controls.Add(this.AnagramListBox);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.WordTextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WordTextbox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.ListBox AnagramListBox;

    }
}

