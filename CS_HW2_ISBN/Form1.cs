using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_HW2_ISBN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Isbn10 label constant.
        /// </summary>
        private const string Isbn10LabelString = "ISBN-10";

        /// <summary>
        /// Isbn13 label constant.
        /// </summary>
        private const string Isbn13LabelString = "ISBN-13";

        /// <summary>
        /// Isbn conversion prefix. (Must remain "9","7","8")
        /// </summary>
        private const string UpConvertString = "978";

        /// <summary>
        /// Sets initial form state on Form1_Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SelectionComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Sets correct form state for SelectionComboBox_SelectedIndexChanged event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                this.Isbn10MaskedTextBox.Visible = true;
                this.Isbn10MaskedTextBox.Focus();
                this.Isbn13MaskedTextBox.Visible = false;
                this.Isbn13MaskedTextBox.Clear();
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                this.Isbn13MaskedTextBox.Visible = true;
                this.Isbn13MaskedTextBox.Focus();
                this.Isbn10MaskedTextBox.Visible = false;
                this.Isbn10MaskedTextBox.Clear();
            }
            else {/*doNothing()*/} //No other possible cases
        }


//FIX ME---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Runs methods for data entry, validation, calculating ISBN check-digits, and setting form state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateIsbnButton_Click(object sender, EventArgs e)
        {
            this.ValidLabel.Visible = false;
            this.InvalidLabel.Visible = false;
            var IsbnIsValid = false;
            var IsbnToValidate = "";

            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                IsbnToValidate = StripStringToDigits(this.Isbn10MaskedTextBox.Text);
                this.SubmittedIsbnTextBox.Text = this.Isbn10MaskedTextBox.Text;
                this.Isbn10MaskedTextBox.Clear();
                this.Isbn10MaskedTextBox.Focus();
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                IsbnToValidate = StripStringToDigits(this.Isbn13MaskedTextBox.Text);
                this.SubmittedIsbnTextBox.Text = this.Isbn13MaskedTextBox.Text;
                this.Isbn13MaskedTextBox.Clear();
                this.Isbn13MaskedTextBox.Focus();
            }
            else {/*doNothing()*/} //No other possible cases

            IsbnIsValid = ValidateIsbn(IsbnToValidate, out var FinalIsbn);

            if (IsbnIsValid)
            {
                try
                {
                    FinalIsbn = FinalIsbn.Insert(3, "-").Insert(5, "-").Insert(8, "-").Insert(15, "-");
                    this.OutputTextBox.Text = FinalIsbn;
                    this.ValidLabel.Visible = true;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    this.InvalidLabel.Visible = true;
                    DisplayInvalidDataMessage(SelectionComboBox.SelectedItem.ToString());
                    this.OutputTextBox.Clear();
                }
            }
            else if (!IsbnIsValid)
            {
                SubmittedIsbnTextBox.Clear();
                this.InvalidLabel.Visible = true;
                MessageBox.Show("No data has been entered!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else {/*doNothing()*/} //No other possible cases
        }
        
        /// <summary>
        /// Removes dashes from string with regular expression.
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        private string StripStringToDigits(string Str)
        {
            var StrippedStr = Regex.Replace(Str, @"\D", "");
            return StrippedStr;
        }

        //SEEMS TO BE WORKING AS EXPECTED
        //TODO: Still need to add ISBN validation calculation formulas
        private bool ValidateIsbn(string IsbnToValidate, out string FinalIsbn)
        {
            char[] IsbnArray = IsbnToValidate.ToCharArray();

            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString && IsbnArray.Length > 0)
            {
                FinalIsbn = UpConvertString + string.Join("", IsbnArray);
                return true;
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString && IsbnArray.Length > 0)
            {
                FinalIsbn = string.Join("", IsbnArray);
                return true;
            }
            else
            {
                FinalIsbn = "";
                return false;
            }
        }

        //END OF FIX ME---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Displays error MessageBox on Invalid data entered.
        /// </summary>
        /// <param name="IsbnFormat"></param>
        private void DisplayInvalidDataMessage(string IsbnFormat)
        {
            MessageBox.Show("Input was incomplete!\n" +
                            "1. Verify that the proper ISBN format is selected.\n" +
                            "2. Enter the complete ISBN.\n" +
                            "3. Click 'Validate ISBN'.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            SubmittedIsbnTextBox.Clear();

            if (IsbnFormat == Isbn10LabelString)
            {
                this.Isbn10MaskedTextBox.Clear();
                this.Isbn10MaskedTextBox.Focus();
            }
            else if(IsbnFormat == Isbn13LabelString)
            {
                this.Isbn13MaskedTextBox.Clear();
                this.Isbn13MaskedTextBox.Focus();
            }
            else {/*doNothing()*/} //No other possible cases
        }

        /// <summary>
        /// Resets the form state on the ClearFormButton_Click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            this.ValidLabel.Visible = false;
            this.InvalidLabel.Visible = false;
            this.Isbn10MaskedTextBox.Clear();
            this.Isbn13MaskedTextBox.Clear();
            this.SubmittedIsbnTextBox.Clear();
            this.OutputTextBox.Clear();

            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                this.Isbn10MaskedTextBox.Focus();
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                this.Isbn13MaskedTextBox.Focus();
            }
            else {/*doNothing()*/} //No other possible cases
        }

        /// <summary>
        /// Clears and refocuses Isbn10MaskedTextBox on Isbn10MaskedTextBox_MouseDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Isbn10MaskedTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            Isbn10MaskedTextBox.Clear();
            Isbn10MaskedTextBox.Focus();
        }

        /// <summary>
        /// Clears and refocuses Isbn13MaskedTextBox on Isbn13MaskedTextBox_MouseDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Isbn13MaskedTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            Isbn13MaskedTextBox.Clear();
            Isbn13MaskedTextBox.Focus();
        }

        /// <summary>
        /// Disable 'Space', 'Left Arrow', 'Right Arrow', 'Up Arrow', and 'Down Arrow' keys 
        /// w/BeepOnError on Isbn10MaskedTextBox_KeyDown event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Isbn10MaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right
                || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
            else {/*doNothing()*/} //No other cases needed
        }

        /// <summary>
        /// Disable 'Space', 'Left Arrow', 'Right Arrow', 'Up Arrow', and 'Down Arrow' keys 
        /// w/BeepOnError on Isbn13MaskedTextBox_KeyDown event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Isbn13MaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right 
                || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
            else {/*doNothing()*/} //No other cases needed
        }

        /// <summary>
        /// Closes the form on ExitButton_Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}