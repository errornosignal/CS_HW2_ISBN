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
            this.ValidLabel = new System.Windows.Forms.Label();
            this.InvalidLabel = new System.Windows.Forms.Label();
            this.OutputTextBox2 = new System.Windows.Forms.TextBox();
            this.ClearFormButton = new System.Windows.Forms.Button();
            this.SubmittedIsbnTextBox = new System.Windows.Forms.TextBox();
            this.InputIsbnLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputTextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Isbn10MaskedTextBox
            // 
            this.Isbn10MaskedTextBox.BeepOnError = true;
            this.Isbn10MaskedTextBox.Location = new System.Drawing.Point(115, 135);
            this.Isbn10MaskedTextBox.Mask = "0-00-000000-0";
            this.Isbn10MaskedTextBox.Name = "Isbn10MaskedTextBox";
            this.Isbn10MaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.Isbn10MaskedTextBox.TabIndex = 0;
            this.Isbn10MaskedTextBox.TabStop = false;
            this.Isbn10MaskedTextBox.Visible = false;
            this.Isbn10MaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Isbn10MaskedTextBox_KeyDown);
            this.Isbn10MaskedTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Isbn10MaskedTextBox_MouseDown);
            // 
            // Isbn13MaskedTextBox
            // 
            this.Isbn13MaskedTextBox.BeepOnError = true;
            this.Isbn13MaskedTextBox.Location = new System.Drawing.Point(115, 135);
            this.Isbn13MaskedTextBox.Mask = "000-0-00-000000-0";
            this.Isbn13MaskedTextBox.Name = "Isbn13MaskedTextBox";
            this.Isbn13MaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.Isbn13MaskedTextBox.TabIndex = 0;
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
            this.SelectionComboBox.Location = new System.Drawing.Point(115, 38);
            this.SelectionComboBox.Name = "SelectionComboBox";
            this.SelectionComboBox.Size = new System.Drawing.Size(100, 21);
            this.SelectionComboBox.TabIndex = 1;
            this.SelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectionComboBox_SelectedIndexChanged);
            // 
            // SelectFormatLabel
            // 
            this.SelectFormatLabel.AutoSize = true;
            this.SelectFormatLabel.Location = new System.Drawing.Point(129, 22);
            this.SelectFormatLabel.Name = "SelectFormatLabel";
            this.SelectFormatLabel.Size = new System.Drawing.Size(70, 13);
            this.SelectFormatLabel.TabIndex = 5;
            this.SelectFormatLabel.Text = "ISBN Format:";
            // 
            // ValidateIsbnButton
            // 
            this.ValidateIsbnButton.Location = new System.Drawing.Point(115, 93);
            this.ValidateIsbnButton.Name = "ValidateIsbnButton";
            this.ValidateIsbnButton.Size = new System.Drawing.Size(100, 23);
            this.ValidateIsbnButton.TabIndex = 2;
            this.ValidateIsbnButton.Text = "Validate ISBN";
            this.ValidateIsbnButton.UseVisualStyleBackColor = true;
            this.ValidateIsbnButton.Click += new System.EventHandler(this.ValidateIsbnButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(20, 93);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Visible = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ValidLabel
            // 
            this.ValidLabel.AutoSize = true;
            this.ValidLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ValidLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.ValidLabel.Location = new System.Drawing.Point(221, 171);
            this.ValidLabel.Name = "ValidLabel";
            this.ValidLabel.Size = new System.Drawing.Size(30, 24);
            this.ValidLabel.TabIndex = 6;
            this.ValidLabel.Text = "✓";
            this.ValidLabel.Visible = false;
            // 
            // InvalidLabel
            // 
            this.InvalidLabel.AutoSize = true;
            this.InvalidLabel.BackColor = System.Drawing.SystemColors.Control;
            this.InvalidLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvalidLabel.ForeColor = System.Drawing.Color.Red;
            this.InvalidLabel.Location = new System.Drawing.Point(221, 170);
            this.InvalidLabel.Name = "InvalidLabel";
            this.InvalidLabel.Size = new System.Drawing.Size(21, 24);
            this.InvalidLabel.TabIndex = 7;
            this.InvalidLabel.Text = "x";
            this.InvalidLabel.Visible = false;
            // 
            // OutputTextBox2
            // 
            this.OutputTextBox2.Enabled = false;
            this.OutputTextBox2.Location = new System.Drawing.Point(115, 227);
            this.OutputTextBox2.Name = "OutputTextBox2";
            this.OutputTextBox2.ReadOnly = true;
            this.OutputTextBox2.Size = new System.Drawing.Size(100, 20);
            this.OutputTextBox2.TabIndex = 8;
            this.OutputTextBox2.TabStop = false;
            // 
            // ClearFormButton
            // 
            this.ClearFormButton.Location = new System.Drawing.Point(20, 38);
            this.ClearFormButton.Name = "ClearFormButton";
            this.ClearFormButton.Size = new System.Drawing.Size(75, 21);
            this.ClearFormButton.TabIndex = 3;
            this.ClearFormButton.Text = "Clear Form";
            this.ClearFormButton.UseVisualStyleBackColor = true;
            this.ClearFormButton.Click += new System.EventHandler(this.ClearFormButton_Click);
            // 
            // SubmittedIsbnTextBox
            // 
            this.SubmittedIsbnTextBox.Enabled = false;
            this.SubmittedIsbnTextBox.Location = new System.Drawing.Point(115, 175);
            this.SubmittedIsbnTextBox.Name = "SubmittedIsbnTextBox";
            this.SubmittedIsbnTextBox.ReadOnly = true;
            this.SubmittedIsbnTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubmittedIsbnTextBox.TabIndex = 9;
            // 
            // InputIsbnLabel
            // 
            this.InputIsbnLabel.AutoSize = true;
            this.InputIsbnLabel.Location = new System.Drawing.Point(24, 178);
            this.InputIsbnLabel.Name = "InputIsbnLabel";
            this.InputIsbnLabel.Size = new System.Drawing.Size(85, 13);
            this.InputIsbnLabel.TabIndex = 10;
            this.InputIsbnLabel.Text = "Submitted ISBN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = " Corrected ISBN-13:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = " Corrected ISBN-10:";
            // 
            // OutputTextBox1
            // 
            this.OutputTextBox1.Enabled = false;
            this.OutputTextBox1.Location = new System.Drawing.Point(115, 201);
            this.OutputTextBox1.Name = "OutputTextBox1";
            this.OutputTextBox1.ReadOnly = true;
            this.OutputTextBox1.Size = new System.Drawing.Size(100, 20);
            this.OutputTextBox1.TabIndex = 13;
            this.OutputTextBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.ValidateIsbnButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(248, 258);
            this.Controls.Add(this.OutputTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputIsbnLabel);
            this.Controls.Add(this.SubmittedIsbnTextBox);
            this.Controls.Add(this.ClearFormButton);
            this.Controls.Add(this.OutputTextBox2);
            this.Controls.Add(this.InvalidLabel);
            this.Controls.Add(this.ValidLabel);
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
        private System.Windows.Forms.Label ValidLabel;
        private System.Windows.Forms.Label InvalidLabel;
        private System.Windows.Forms.TextBox OutputTextBox2;
        private System.Windows.Forms.Button ClearFormButton;
        private System.Windows.Forms.TextBox SubmittedIsbnTextBox;
        private System.Windows.Forms.Label InputIsbnLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OutputTextBox1;
    }
}

