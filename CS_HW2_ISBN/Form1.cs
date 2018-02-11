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
        /// Isbn conversion prefix 1.
        /// </summary>
        private const string NineSevenEight = "978";

        /// <summary>
        /// Isbn conversion prefix 2. 
        /// </summary>
        private const string NineSevenNine = "979";

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
            const int DashOne = 1;
            const int DashThree = 3;
            const int DashFour = 4;
            const int DashFive = 5;
            const int DashEight = 8;
            const int DashEleven = 11;
            const int DashFifteen = 15;
            const int RemoveMe = 4;
            const int Isbn10StringLength = 13;
            const int Isbn13StringLength = 17;
            this.ValidLabel.Visible = false;
            this.InvalidLabel.Visible = false;
            var IsbnIsValid = false;
            var IsbnToValidate = "";

            this.OutputTextBox1.Clear();
            this.OutputTextBox2.Clear();

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

            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                try
                {
                    var TempString1 = FinalIsbn;
                    TempString1 = TempString1.Insert(DashOne, "-").Insert(DashFour, "-").Insert(DashEleven, "-");
                    TempString1 = TempString1.Substring(0, Isbn10StringLength);
                    this.OutputTextBox1.Text = TempString1;
                    TempString1 = TempString1.Insert(0, NineSevenEight + "-");
                    this.OutputTextBox2.Text = TempString1;

                    if (IsbnIsValid)
                    {
                        this.ValidLabel.Visible = true;
                    }
                    else
                    {
                        this.InvalidLabel.Visible = true;
                    }
                }
                catch (Exception Ex)
                {
                    SubmittedIsbnTextBox.Clear();
                    this.InvalidLabel.Visible = true;
                    MessageBox.Show("No data has been entered!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                try
                {
                    var TempString1 = FinalIsbn;
                    TempString1 = TempString1.Insert(DashThree, "-").Insert(DashFive, "-").Insert(DashEight, "-").Insert(DashFifteen, "-");
                    TempString1 = TempString1.Substring(0, Isbn13StringLength);
                    this.OutputTextBox1.Text = TempString1.Remove(0, RemoveMe);
                    this.OutputTextBox2.Text = TempString1;

                    if (IsbnIsValid)
                    {
                        this.ValidLabel.Visible = true;
                    }
                    else
                    {
                        this.InvalidLabel.Visible = true;
                    }
                }
                catch (Exception Ex)
                {
                    SubmittedIsbnTextBox.Clear();
                    this.InvalidLabel.Visible = true;
                    MessageBox.Show("No data has been entered!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        /// <summary>
        /// Validates ISBN check digits.
        /// </summary>
        /// <param name="IsbnToValidate"></param>
        /// <param name="FinalIsbn"></param>
        /// <returns></returns>
        private bool ValidateIsbn(string IsbnToValidate, out string FinalIsbn)
        {
            var IsbnCheckDigit = 0;
            int[] IsbnArray = new int[13];
            int count = 0;

            foreach (char c in IsbnToValidate)
            {
                IsbnArray[count] = int.Parse(c.ToString());
                count += 1;
            }
            
            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                IsbnCheckDigit = ((IsbnArray[0] * 1) + (IsbnArray[1] * 2) + (IsbnArray[2] * 3) + (IsbnArray[3] * 4)
                                  + (IsbnArray[4] * 5) + (IsbnArray[5] * 6) + (IsbnArray[6] * 7) + (IsbnArray[7] * 8)
                                  + (IsbnArray[8] * 9)) % 11;

                if ((IsbnArray[9] == IsbnCheckDigit) && (IsbnArray.Sum() > 0))
                {
                    FinalIsbn = string.Join("", IsbnArray);
                    return true;
                }
                else if ((IsbnArray[9] != IsbnCheckDigit) && (IsbnArray.Sum() > 0))
                {
                    IsbnArray[9] = IsbnCheckDigit;
                    FinalIsbn = string.Join("", IsbnArray);
                    if (FinalIsbn.Substring(9, 2) == "10")
                    {
                        FinalIsbn = FinalIsbn.Remove(9, 2).Insert(9, "X");
                    }
                    else {/*doNothing*/} //No other cases to handle
                    return false;
                }
                else
                {
                    FinalIsbn = "";
                    return false;
                }
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                IsbnCheckDigit = 10 - (IsbnArray[0] + (3 * IsbnArray[1]) + IsbnArray[2] + (3 * IsbnArray[3]) +
                                       IsbnArray[4] + (3 * IsbnArray[5]) + IsbnArray[6] + (3 * IsbnArray[7]) +
                                       IsbnArray[8] + (3 * IsbnArray[9]) + IsbnArray[10] + (3 * IsbnArray[11])) % 10;

                if ((IsbnArray[12] == IsbnCheckDigit) && (IsbnArray.Sum() > 0))
                {
                    FinalIsbn = string.Join("", IsbnArray);
                    return true;
                }
                else if ((IsbnArray[12] != IsbnCheckDigit) && (IsbnArray.Sum() > 0))
                {
                    IsbnArray[12] = IsbnCheckDigit;
                    FinalIsbn = string.Join("", IsbnArray);
                    return false;
                }
                else
                {
                    FinalIsbn = "";
                    return false;
                }
            }
            else
            {
                FinalIsbn = "";
                return false;
            }
        }
//END OF FIX ME--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Displays error MessageBox on Invalid data entered.
        /// </summary>
        /// <param name="IsbnFormat"></param>
        private void DisplayInvalidDataMessage(string IsbnFormat)
        {
            MessageBox.Show("Input was invalid!\n" +
                            "1. Verify proper ISBN format:\n" +
                            "       [ISBN-10/ISBN-13]\n" +
                            "2. Enter the complete ISBN:\n" +
                            "       [IBSN-10 = 13 digits, ISBN-13 = 10 digits]\n" +
                            "3. ISBN-13 must begin with '" + NineSevenEight + "' or '" + NineSevenNine + ".", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SubmittedIsbnTextBox.Clear();
            this.Isbn10MaskedTextBox.Clear();
            this.Isbn13MaskedTextBox.Clear();

            if (IsbnFormat == Isbn10LabelString)
            {
                this.Isbn10MaskedTextBox.Focus();
            }
            else if(IsbnFormat == Isbn13LabelString)
            {
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
            this.OutputTextBox2.Clear();

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