using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
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
            this.ValidLabel1.Visible = false;
            this.ValidLabel2.Visible = false;
            this.InvalidLabel.Visible = false;

            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                this.Isbn10MaskedTextBox.Visible = true;
                this.Isbn10MaskedTextBox.Focus();
                this.Isbn13MaskedTextBox.Visible = false;
                this.Isbn13MaskedTextBox.Clear();
                this.Isbn10MaskedTextBox.Clear();
                this.OutputTextBox1.Clear();
                this.OutputTextBox2.Clear();
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
                this.Isbn13MaskedTextBox.Clear();
                this.OutputTextBox1.Clear();
                this.OutputTextBox2.Clear();
                this.Isbn13Label.Visible = true;
                this.OutputTextBox2.Visible = true;
                this.Isbn10Label.Visible = false;
                this.OutputTextBox1.Visible = false;
            }
            else {/*doNothing()*/} //No other possible cases
        }

        /// <summary>
        /// Runs methods for data entry, validation, calculating ISBN check-digits, and setting form state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateIsbnButton_Click(object sender, EventArgs e)
        {
            const int dashAtOne = 1;
            const int dashAtThree = 3;
            const int dashAtFour = 4;
            const int dashAtFive = 5;
            const int dashAtEight = 8;
            const int dashAtEleven = 11;
            const int dashAtFifteen = 15;
            const int isbn10StringLength = 13;
            const int isbn13StringLength = 17;
            var isbnIsValid = false;
            var isbnToValidate = "";

            this.ValidLabel1.Visible = false;
            this.InvalidLabel.Visible = false;
            this.OutputTextBox1.Clear();
            this.OutputTextBox2.Clear();

            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                isbnToValidate = StripStringToDigits(this.Isbn10MaskedTextBox.Text);
                this.SubmittedIsbnTextBox.Text = this.Isbn10MaskedTextBox.Text;
                this.Isbn10MaskedTextBox.Clear();
                this.Isbn10MaskedTextBox.Focus();
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                isbnToValidate = StripStringToDigits(this.Isbn13MaskedTextBox.Text);
                this.SubmittedIsbnTextBox.Text = this.Isbn13MaskedTextBox.Text;
                this.Isbn13MaskedTextBox.Clear();
                this.Isbn13MaskedTextBox.Focus();
            }
            else {/*doNothing()*/} //No other possible cases

            isbnIsValid = ValidateIsbn(isbnToValidate, out var finalIsbn);

            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                try
                {
                    var tempString1 = finalIsbn;
                    tempString1 = tempString1.Insert(dashAtOne, "-").Insert(dashAtFour, "-").Insert(dashAtEleven, "-");
                    tempString1 = tempString1.Substring(0, isbn10StringLength);
                    this.OutputTextBox1.Text = tempString1;

                    if (isbnIsValid)
                    {
                        this.ValidLabel1.Visible = true;
                    }
                    else
                    {
                        this.InvalidLabel.Visible = true;
                    }

                    this.ValidLabel2.Visible = true;
                }
                catch (Exception)
                {
                    this.SubmittedIsbnTextBox.Clear();
                    this.SubmittedIsbnTextBox.Clear();
                    this.ValidLabel1.Visible = false;
                    this.ValidLabel2.Visible = false;
                    this.InvalidLabel.Visible = false;
                }
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                try
                {
                    var tempString1 = finalIsbn;
                    tempString1 = tempString1.Insert(dashAtThree, "-").Insert(dashAtFive, "-").Insert(dashAtEight, "-").Insert(dashAtFifteen, "-");
                    tempString1 = tempString1.Substring(0, isbn13StringLength);
                    this.OutputTextBox2.Text = tempString1;

                    if (isbnIsValid)
                    {
                        this.ValidLabel1.Visible = true;
                    }
                    else
                    {
                        this.InvalidLabel.Visible = true;
                    }
                    this.ValidLabel2.Visible = true;
                }
                catch (Exception)
                {
                    this.SubmittedIsbnTextBox.Clear();
                    this.SubmittedIsbnTextBox.Clear();
                    this.ValidLabel1.Visible = false;
                    this.ValidLabel2.Visible = false;
                    this.InvalidLabel.Visible = false;
                }
            }
            else {/*doNothing()*/} //No other possible cases
        }

        /// <summary>
        /// Removes dashes from string with regular expression.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string StripStringToDigits(string str)
        {
            var strippedString = Regex.Replace(str, @"\D", "");
            return strippedString;
        }

        /// <summary>
        /// Validates ISBN check digits.
        /// </summary>
        /// <param name="isbnToValidate"></param>
        /// <param name="finalIsbn"></param>
        /// <returns></returns>
        private bool ValidateIsbn(string isbnToValidate, out string finalIsbn)
        {
            var isbnList = new List<int>();
            var isbnCheckDigit = 0;
            var isValid = false;
            finalIsbn = "";

            foreach (var c in isbnToValidate)
            {
                isbnList.Add(int.Parse(c.ToString()));
            }
            
            if (this.SelectionComboBox.SelectedItem.ToString() == Isbn10LabelString)
            {
                try
                {
                    if (isbnList.Sum() == 0 && isbnList.Count > 0)
                    {
                        DisplayInvalidDataMessage(Isbn10LabelString);
                    }
                    else
                    {/*doNothing*/} //No other cases to handle

                    isbnCheckDigit = ((isbnList[0] * 1) + (isbnList[1] * 2) + (isbnList[2] * 3) + (isbnList[3] * 4)
                                      + (isbnList[4] * 5) + (isbnList[5] * 6) + (isbnList[6] * 7) + (isbnList[7] * 8)
                                      + (isbnList[8] * 9)) % 11;

                    if ((isbnList[9] == isbnCheckDigit) && (isbnList.Sum() > 0))
                    {
                        finalIsbn = string.Join("", isbnList);
                        isValid = true;
                    }
                    else if ((isbnList[9] != isbnCheckDigit) && (isbnList.Sum() > 0))
                    {
                        isbnList[9] = isbnCheckDigit;
                        finalIsbn = string.Join("", isbnList);

                        if (finalIsbn.Length == 11)
                        {
                            if (finalIsbn.Substring(9, 2) == "10")
                            {
                                finalIsbn = finalIsbn.Remove(9, 2).Insert(9, "X");
                            }
                            else
                            {/*doNothing*/} //No other cases to handle
                        }
                        else
                        {/*doNothing*/} //No other cases to handle
                    }
                    else
                    {/*doNothing*/} //No other cases to handle
                }
                catch (Exception)
                {
                    DisplayInvalidDataMessage(Isbn13LabelString);
                }
            }
            else if (this.SelectionComboBox.SelectedItem.ToString() == Isbn13LabelString)
            {
                var prefixIsValid = isbnToValidate.StartsWith(NineSevenEight) || isbnToValidate.StartsWith(NineSevenNine);

                if (!prefixIsValid)
                {
                    DisplayInvalidDataMessage(SelectionComboBox.SelectedItem.ToString());
                    finalIsbn = "";
                    return false;
                }
                else
                {/*doNothing*/} //No other cases to handle

                try
                {
                    isbnCheckDigit = 10 - (isbnList[0] + (3 * isbnList[1]) + isbnList[2] + (3 * isbnList[3]) +
                                           isbnList[4] + (3 * isbnList[5]) + isbnList[6] + (3 * isbnList[7]) +
                                           isbnList[8] + (3 * isbnList[9]) + isbnList[10] + (3 * isbnList[11])) % 10;

                    if ((isbnList[12] == isbnCheckDigit) && (isbnList.Sum() > 0))
                    {
                        finalIsbn = string.Join("", isbnList);
                        isValid = true;
                    }
                    else if ((isbnList[12] != isbnCheckDigit) && (isbnList.Sum() > 0))
                    {
                        isbnList[12] = isbnCheckDigit;
                        finalIsbn = string.Join("", isbnList);
                    }
                    else
                    {/*doNothing*/} //No other cases to handle
                }
                catch (Exception)
                {
                    DisplayInvalidDataMessage(Isbn13LabelString);
                }
            }
            else
            {/*doNothing*/} //No other cases to handle
            return isValid;
        }

        /// <summary>
        /// Displays error MessageBox on Invalid data entered.
        /// </summary>
        /// <param name="isbnFormat"></param>
        private void DisplayInvalidDataMessage(string isbnFormat)
        {
            this.SubmittedIsbnTextBox.Clear();
            this.SubmittedIsbnTextBox.Clear();
            this.ValidLabel1.Visible = false;
            this.ValidLabel2.Visible = false;
            this.InvalidLabel.Visible = false;

            MessageBox.Show("INVALID INPUT!\n\n" +
                            "Please verify that the following conditions have been met:\n" +
                            "   -Proper ISBN format selected:\n" +
                            "\ta. ISBN-10 or ISBN-13.\n" +
                            "   -Complete ISBN entered:\n" +
                            "\ta. IBSN-10 is 10 digits in length.\n" +
                            "\tb. ISBN-13 is 13 digits in length.\n" +
                            "\t\t1). ISBN-13 begins with \"" + NineSevenEight + "\" or \"" + NineSevenNine + "\".", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Isbn10MaskedTextBox.Clear();
            this.Isbn13MaskedTextBox.Clear();

            if (isbnFormat == Isbn10LabelString)
            {
                this.Isbn10MaskedTextBox.Focus();
            }
            else if(isbnFormat == Isbn13LabelString)
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
            this.ValidLabel1.Visible = false;
            this.ValidLabel2.Visible = false;
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
            this.Isbn10MaskedTextBox.Clear();
            this.Isbn10MaskedTextBox.Focus();
        }

        /// <summary>
        /// Clears and refocuses Isbn13MaskedTextBox on Isbn13MaskedTextBox_MouseDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Isbn13MaskedTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.Isbn13MaskedTextBox.Clear();
            this.Isbn13MaskedTextBox.Focus();
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