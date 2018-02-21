namespace CS_HW2_ISBN
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
            this.Isbn10MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Isbn13MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SelectionComboBox = new System.Windows.Forms.ComboBox();
            this.SelectFormatLabel = new System.Windows.Forms.Label();
            this.ValidateIsbnButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ValidLabel1 = new System.Windows.Forms.Label();
            this.InvalidLabel = new System.Windows.Forms.Label();
            this.OutputTextBox2 = new System.Windows.Forms.TextBox();
            this.ClearFormButton = new System.Windows.Forms.Button();
            this.SubmittedIsbnTextBox = new System.Windows.Forms.TextBox();
            this.InputIsbnLabel = new System.Windows.Forms.Label();
            this.Isbn13Label = new System.Windows.Forms.Label();
            this.Isbn10Label = new System.Windows.Forms.Label();
            this.OutputTextBox1 = new System.Windows.Forms.TextBox();
            this.ValidLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Isbn10MaskedTextBox
            // 
            this.Isbn10MaskedTextBox.BeepOnError = true;
            this.Isbn10MaskedTextBox.Location = new System.Drawing.Point(111, 73);
            this.Isbn10MaskedTextBox.Mask = "0-00-000000-0";
            this.Isbn10MaskedTextBox.Name = "Isbn10MaskedTextBox";
            this.Isbn10MaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.Isbn10MaskedTextBox.TabIndex = 3;
            this.Isbn10MaskedTextBox.Visible = false;
            this.Isbn10MaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Isbn10MaskedTextBox_KeyDown);
            this.Isbn10MaskedTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Isbn10MaskedTextBox_MouseDown);
            // 
            // Isbn13MaskedTextBox
            // 
            this.Isbn13MaskedTextBox.BeepOnError = true;
            this.Isbn13MaskedTextBox.Location = new System.Drawing.Point(111, 73);
            this.Isbn13MaskedTextBox.Mask = "000-0-00-000000-0";
            this.Isbn13MaskedTextBox.Name = "Isbn13MaskedTextBox";
            this.Isbn13MaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.Isbn13MaskedTextBox.TabIndex = 2;
            this.Isbn13MaskedTextBox.Visible = false;
            this.Isbn13MaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Isbn13MaskedTextBox_KeyDown);
            this.Isbn13MaskedTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Isbn13MaskedTextBox_MouseDown);
            // 
            // SelectionComboBox
            // 
            this.SelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectionComboBox.FormattingEnabled = true;
            this.SelectionComboBox.Items.AddRange(new object[] {
            "ISBN-13",
            "ISBN-10"});
            this.SelectionComboBox.Location = new System.Drawing.Point(111, 25);
            this.SelectionComboBox.Name = "SelectionComboBox";
            this.SelectionComboBox.Size = new System.Drawing.Size(100, 21);
            this.SelectionComboBox.TabIndex = 1;
            this.SelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectionComboBox_SelectedIndexChanged);
            // 
            // SelectFormatLabel
            // 
            this.SelectFormatLabel.AutoSize = true;
            this.SelectFormatLabel.Location = new System.Drawing.Point(4, 28);
            this.SelectFormatLabel.Name = "SelectFormatLabel";
            this.SelectFormatLabel.Size = new System.Drawing.Size(101, 13);
            this.SelectFormatLabel.TabIndex = 5;
            this.SelectFormatLabel.Text = "ISBN-10 / ISBN-13:";
            // 
            // ValidateIsbnButton
            // 
            this.ValidateIsbnButton.Location = new System.Drawing.Point(111, 108);
            this.ValidateIsbnButton.Name = "ValidateIsbnButton";
            this.ValidateIsbnButton.Size = new System.Drawing.Size(100, 23);
            this.ValidateIsbnButton.TabIndex = 4;
            this.ValidateIsbnButton.TabStop = false;
            this.ValidateIsbnButton.Text = "Validate ISBN";
            this.ValidateIsbnButton.UseVisualStyleBackColor = true;
            this.ValidateIsbnButton.Click += new System.EventHandler(this.ValidateIsbnButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(16, 50);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 21);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Visible = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ValidLabel1
            // 
            this.ValidLabel1.AutoSize = true;
            this.ValidLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.ValidLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidLabel1.ForeColor = System.Drawing.Color.LimeGreen;
            this.ValidLabel1.Location = new System.Drawing.Point(208, 145);
            this.ValidLabel1.Name = "ValidLabel1";
            this.ValidLabel1.Size = new System.Drawing.Size(30, 24);
            this.ValidLabel1.TabIndex = 6;
            this.ValidLabel1.Text = "✓";
            this.ValidLabel1.Visible = false;
            // 
            // InvalidLabel
            // 
            this.InvalidLabel.AutoSize = true;
            this.InvalidLabel.BackColor = System.Drawing.SystemColors.Control;
            this.InvalidLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvalidLabel.ForeColor = System.Drawing.Color.Red;
            this.InvalidLabel.Location = new System.Drawing.Point(208, 146);
            this.InvalidLabel.Name = "InvalidLabel";
            this.InvalidLabel.Size = new System.Drawing.Size(21, 24);
            this.InvalidLabel.TabIndex = 7;
            this.InvalidLabel.Text = "x";
            this.InvalidLabel.Visible = false;
            // 
            // OutputTextBox2
            // 
            this.OutputTextBox2.Enabled = false;
            this.OutputTextBox2.Location = new System.Drawing.Point(111, 172);
            this.OutputTextBox2.Name = "OutputTextBox2";
            this.OutputTextBox2.ReadOnly = true;
            this.OutputTextBox2.Size = new System.Drawing.Size(100, 20);
            this.OutputTextBox2.TabIndex = 8;
            this.OutputTextBox2.TabStop = false;
            this.OutputTextBox2.Visible = false;
            // 
            // ClearFormButton
            // 
            this.ClearFormButton.Location = new System.Drawing.Point(16, 109);
            this.ClearFormButton.Name = "ClearFormButton";
            this.ClearFormButton.Size = new System.Drawing.Size(75, 21);
            this.ClearFormButton.TabIndex = 5;
            this.ClearFormButton.Text = "Clear Form";
            this.ClearFormButton.UseVisualStyleBackColor = true;
            this.ClearFormButton.Click += new System.EventHandler(this.ClearFormButton_Click);
            // 
            // SubmittedIsbnTextBox
            // 
            this.SubmittedIsbnTextBox.Enabled = false;
            this.SubmittedIsbnTextBox.Location = new System.Drawing.Point(111, 146);
            this.SubmittedIsbnTextBox.Name = "SubmittedIsbnTextBox";
            this.SubmittedIsbnTextBox.ReadOnly = true;
            this.SubmittedIsbnTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubmittedIsbnTextBox.TabIndex = 9;
            // 
            // InputIsbnLabel
            // 
            this.InputIsbnLabel.AutoSize = true;
            this.InputIsbnLabel.Location = new System.Drawing.Point(20, 149);
            this.InputIsbnLabel.Name = "InputIsbnLabel";
            this.InputIsbnLabel.Size = new System.Drawing.Size(85, 13);
            this.InputIsbnLabel.TabIndex = 10;
            this.InputIsbnLabel.Text = "Submitted ISBN:";
            // 
            // Isbn13Label
            // 
            this.Isbn13Label.AutoSize = true;
            this.Isbn13Label.Location = new System.Drawing.Point(3, 175);
            this.Isbn13Label.Name = "Isbn13Label";
            this.Isbn13Label.Size = new System.Drawing.Size(102, 13);
            this.Isbn13Label.TabIndex = 11;
            this.Isbn13Label.Text = " Corrected ISBN-13:";
            this.Isbn13Label.Visible = false;
            // 
            // Isbn10Label
            // 
            this.Isbn10Label.AutoSize = true;
            this.Isbn10Label.Location = new System.Drawing.Point(3, 175);
            this.Isbn10Label.Name = "Isbn10Label";
            this.Isbn10Label.Size = new System.Drawing.Size(102, 13);
            this.Isbn10Label.TabIndex = 12;
            this.Isbn10Label.Text = " Corrected ISBN-10:";
            this.Isbn10Label.Visible = false;
            // 
            // OutputTextBox1
            // 
            this.OutputTextBox1.Enabled = false;
            this.OutputTextBox1.Location = new System.Drawing.Point(111, 172);
            this.OutputTextBox1.Name = "OutputTextBox1";
            this.OutputTextBox1.ReadOnly = true;
            this.OutputTextBox1.Size = new System.Drawing.Size(100, 20);
            this.OutputTextBox1.TabIndex = 13;
            this.OutputTextBox1.TabStop = false;
            this.OutputTextBox1.Visible = false;
            // 
            // ValidLabel2
            // 
            this.ValidLabel2.AutoSize = true;
            this.ValidLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.ValidLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidLabel2.ForeColor = System.Drawing.Color.LimeGreen;
            this.ValidLabel2.Location = new System.Drawing.Point(208, 169);
            this.ValidLabel2.Name = "ValidLabel2";
            this.ValidLabel2.Size = new System.Drawing.Size(30, 24);
            this.ValidLabel2.TabIndex = 14;
            this.ValidLabel2.Text = "✓";
            this.ValidLabel2.Visible = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.ValidateIsbnButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(234, 202);
            this.Controls.Add(this.ValidLabel2);
            this.Controls.Add(this.OutputTextBox1);
            this.Controls.Add(this.Isbn10Label);
            this.Controls.Add(this.Isbn13Label);
            this.Controls.Add(this.InputIsbnLabel);
            this.Controls.Add(this.SubmittedIsbnTextBox);
            this.Controls.Add(this.ClearFormButton);
            this.Controls.Add(this.OutputTextBox2);
            this.Controls.Add(this.InvalidLabel);
            this.Controls.Add(this.ValidLabel1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ValidateIsbnButton);
            this.Controls.Add(this.SelectFormatLabel);
            this.Controls.Add(this.SelectionComboBox);
            this.Controls.Add(this.Isbn13MaskedTextBox);
            this.Controls.Add(this.Isbn10MaskedTextBox);
            this.Name = "Form1";
            this.Text = "ISBN Validator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox Isbn10MaskedTextBox;
        private System.Windows.Forms.MaskedTextBox Isbn13MaskedTextBox;
        private System.Windows.Forms.ComboBox SelectionComboBox;
        private System.Windows.Forms.Label SelectFormatLabel;
        private System.Windows.Forms.Button ValidateIsbnButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label ValidLabel1;
        private System.Windows.Forms.Label InvalidLabel;
        private System.Windows.Forms.TextBox OutputTextBox2;
        private System.Windows.Forms.Button ClearFormButton;
        private System.Windows.Forms.TextBox SubmittedIsbnTextBox;
        private System.Windows.Forms.Label InputIsbnLabel;
        private System.Windows.Forms.Label Isbn13Label;
        private System.Windows.Forms.Label Isbn10Label;
        private System.Windows.Forms.TextBox OutputTextBox1;
        private System.Windows.Forms.Label ValidLabel2;
    }
}

