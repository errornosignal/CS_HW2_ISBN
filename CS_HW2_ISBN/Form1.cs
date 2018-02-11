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
            this.SubmittedIsbnTextBox.Clear();
            this.ValidLabel.Visible = false;
            this.ValidLabel2.Visible = false;
            this.InvalidLabel.Visible = false;


            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                this.Isbn10MaskedTextBox.Visible = true;
                this.Isbn10MaskedTextBox.Focus();
                this.Isbn13MaskedTextBox.Visible = false;
                this.Isbn13MaskedTextBox.Clear();
                this.Isbn10Label.Visible = true;
                this.OutputTextBox1.Visible = true;
                this.Isbn13Label.Visible = false;
                this.OutputTextBox2.Visible = false;
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                this.Isbn13MaskedTextBox.Visible = true;
                this.Isbn13MaskedTextBox.Focus();
                this.Isbn10MaskedTextBox.Visible = false;
                this.Isbn10MaskedTextBox.Clear();
                this.Isbn13Label.Visible = true;
                this.OutputTextBox2.Visible = true;
                this.Isbn10Label.Visible = false;
                this.OutputTextBox1.Visible = false;
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
            const int Isbn10StringLength = 13;
            const int Isbn13StringLength = 17;
            //const int RemoveMe = 4;
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
                    //TempString1 = TempString1.Insert(0, NineSevenEight + "-");
                    //this.OutputTextBox2.Text = TempString1;

                    if (IsbnIsValid)
                    {
                        this.ValidLabel.Visible = true;
                    }
                    else
                    {
                        this.InvalidLabel.Visible = true;
                    }

                    this.ValidLabel2.Visible = true;
                }
                catch (Exception Ex)
                {
                    SubmittedIsbnTextBox.Clear();
                    this.SubmittedIsbnTextBox.Clear();
                    this.ValidLabel.Visible = false;
                    this.ValidLabel2.Visible = false;
                    this.InvalidLabel.Visible = false;
                    //DisplayNoDataMessage();
                }
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                try
                {
                    var TempString1 = FinalIsbn;
                    TempString1 = TempString1.Insert(DashThree, "-").Insert(DashFive, "-").Insert(DashEight, "-").Insert(DashFifteen, "-");
                    TempString1 = TempString1.Substring(0, Isbn13StringLength);
                    this.OutputTextBox2.Text = TempString1;
                    //this.OutputTextBox1.Text = TempString1.Remove(0, RemoveMe);

                    if (IsbnIsValid)
                    {
                        this.ValidLabel.Visible = true;
                    }
                    else
                    {
                        this.InvalidLabel.Visible = true;
                    }
                    this.ValidLabel2.Visible = true;
                }
                catch (Exception Ex)
                {
                    SubmittedIsbnTextBox.Clear();
                    this.SubmittedIsbnTextBox.Clear();
                    this.ValidLabel.Visible = false;
                    this.ValidLabel2.Visible = false;
                    this.InvalidLabel.Visible = false;
                    //DisplayNoDataMessage();
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
            List<int> IsbnList = new List<int>();

            foreach (char c in IsbnToValidate)
            {
                IsbnList.Add(int.Parse(c.ToString()));
            }
            
            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                try
                {
                    IsbnCheckDigit = ((IsbnList[0] * 1) + (IsbnList[1] * 2) + (IsbnList[2] * 3) + (IsbnList[3] * 4)
                                      + (IsbnList[4] * 5) + (IsbnList[5] * 6) + (IsbnList[6] * 7) + (IsbnList[7] * 8)
                                      + (IsbnList[8] * 9)) % 11;

                    if ((IsbnList[9] == IsbnCheckDigit) && (IsbnList.Sum() > 0))
                    {
                        FinalIsbn = string.Join("", IsbnList);
                        return true;
                    }
                    else if ((IsbnList[9] != IsbnCheckDigit) && (IsbnList.Sum() > 0))
                    {
                        IsbnList[9] = IsbnCheckDigit;
                        FinalIsbn = string.Join("", IsbnList);
                        if (FinalIsbn.Substring(9, 2) == "10")
                        {
                            FinalIsbn = FinalIsbn.Remove(9, 2).Insert(9, "X");
                        }
                        else
                        {
                            /*doNothing*/
                        } //No other cases to handle

                        return false;
                    }
                    else
                    {
                        FinalIsbn = "";
                        return false;
                    }
                }
                catch (Exception Ex)
                {
                    DisplayInvalidDataMessage(Isbn13LabelString);
                }
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                try
                {
                    IsbnCheckDigit = 10 - (IsbnList[0] + (3 * IsbnList[1]) + IsbnList[2] + (3 * IsbnList[3]) +
                                           IsbnList[4] + (3 * IsbnList[5]) + IsbnList[6] + (3 * IsbnList[7]) +
                                           IsbnList[8] + (3 * IsbnList[9]) + IsbnList[10] + (3 * IsbnList[11])) % 10;

                    if ((IsbnList[12] == IsbnCheckDigit) && (IsbnList.Sum() > 0))
                    {
                        FinalIsbn = string.Join("", IsbnList);
                        return true;
                    }
                    else if ((IsbnList[12] != IsbnCheckDigit) && (IsbnList.Sum() > 0))
                    {
                        IsbnList[12] = IsbnCheckDigit;
                        FinalIsbn = string.Join("", IsbnList);
                        return false;
                    }
                    else
                    {
                        FinalIsbn = "";
                        return false;
                    }
                }
                catch (Exception Ex)
                {
                    DisplayInvalidDataMessage(Isbn13LabelString);
                }
            }
            else
            {
                FinalIsbn = "";
                return false;
            }
            FinalIsbn = "";
                return false;
        }
//END OF FIX ME--------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Displays error MessageBox on Invalid data entered.
        /// </summary>
        /// <param name="IsbnFormat"></param>
        private void DisplayInvalidDataMessage(string IsbnFormat)
        {
            SubmittedIsbnTextBox.Clear();
            this.SubmittedIsbnTextBox.Clear();
            this.ValidLabel.Visible = false;
            this.ValidLabel2.Visible = false;
            this.InvalidLabel.Visible = false;
            MessageBox.Show("Input was invalid!\n" +
                            "1. Verify proper ISBN format:\n" +
                            "       [ISBN-10/ISBN-13]\n" +
                            "2. Enter the complete ISBN:\n" +
                            "       [IBSN-10 = 13 digits, ISBN-13 = 10 digits]\n" +
                            "3. ISBN-13 must begin with '" + NineSevenEight + "' or '" + NineSevenNine + ".", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DisplayNoDataMessage()
        {
            MessageBox.Show("No data has been entered!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.OutputTextBox1.Clear();
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