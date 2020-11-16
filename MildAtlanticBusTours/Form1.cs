/* Student Name: Bakkesh Shivakumar Aladahalli
 * Student ID: 20230557
 * Date: 27/10/2020
 * Assignment: 2
 * Assignment: Mild Atlantic Bus Tours - */

using System;
using System.Windows.Forms;

namespace MildAtlanticBusTours
{
    public partial class MildAtlanticBusToursForm : Form
    {
        // Global variables/fields declaration

        private int GuestsInNumber;
        private int TotalCompanyTransactions;

        private decimal TotalCost;
        private decimal TotalTripFees;
        private decimal TotalLodgingFees;
        private decimal TotalLunchFees;
        private decimal SumOfTotalCost;
        private decimal LunchCostTotal;
        private decimal TripCostTotal;
        private decimal HotelCostTotal;

        private string LocationSelected = "";
        private string TimeSelected = "";
        private string HotelSelected = "";

        public MildAtlanticBusToursForm()
        {
            InitializeComponent();
        }

        /* When Display Button is pressed user input validation is done and is 
         * Used for calculation of the quotes*/
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            //local variables
            //if constant values needs to be updated
            // in future it can be done here at one place.

            // Location cost per person.
            const decimal CLIFFSOFMOHERCOST = 55m;
            const decimal KYLEMOREABBEYCOST = 50m;
            const decimal BUNRATTYCASTLECOST = 75m;
            const decimal THEBURRENCOST = 45m;
            const decimal CONNEMARACOST = 75m;
            const decimal BELMULLETCOST = 99m;

            // Time Discount.
            const decimal TIME7DISCOUNT = .2m;
            const decimal TIME8DISCOUNT = .1m;
            const decimal TIME9DISCOUNT = .05m;
            const decimal TIME10DISCOUNT = 0m;
            const decimal TIME11DISCOUNT = 0m;
            const decimal TIME13DISCOUNT = .25m;

            // Special Discount.
            const decimal SpecialDiscount = .075m;

            // Hotel cost per person.
            const decimal Star5Cost = 100m;
            const decimal Star4Cost = 75m;
            const decimal Star3Cost = 55m;

            // Lunch cost per person.
            const decimal LunchCost = 11.50m;

            decimal HotelCost = 0m;
            decimal TimeDiscount = 0m;
            decimal TripCostPerPerson = 0m;

            // See whether user has opted the Location. 
            if (LocationListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Location.", "Alert Message !",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // See whether user has opted the Time of departure.
                if (TimeListBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please pick a Time.", "Alert Message !",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // User input is validated against negative and decimals.
                    if (!int.TryParse(GuestsTextBox.Text, out GuestsInNumber) ||
                         GuestsInNumber <= 0)
                    {
                        MessageBox.Show("Please Enter Guest(s) in Whole " +
                                        "numbers greater than '0'.", "Alert Message !",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GuestsTextBox.Focus();
                    }
                    else
                    {
                        switch (LocationListBox.SelectedIndex)
                        {
                            case 0: TripCostPerPerson = CLIFFSOFMOHERCOST; break;
                            case 1: TripCostPerPerson = KYLEMOREABBEYCOST; break;
                            case 2: TripCostPerPerson = BUNRATTYCASTLECOST; break;
                            case 3: TripCostPerPerson = THEBURRENCOST; break;
                            case 4: TripCostPerPerson = CONNEMARACOST; break;
                            case 5: TripCostPerPerson = BELMULLETCOST; break;
                        }

                        switch (TimeListBox.SelectedIndex)
                        {
                            case 0: TimeDiscount = TIME7DISCOUNT; break;
                            case 1: TimeDiscount = TIME8DISCOUNT; break;
                            case 2: TimeDiscount = TIME9DISCOUNT; break;
                            case 3: TimeDiscount = TIME10DISCOUNT; break;
                            case 4: TimeDiscount = TIME11DISCOUNT; break;
                            case 5: TimeDiscount = TIME13DISCOUNT; break;
                        }

                        // See whether user has opted the Hotel facility
                        if (Star5RadioButton.Checked)
                        {
                            HotelSelected = Star5RadioButton.Text.ToString();
                            HotelCost = Star5Cost;
                        }
                        else if (Star4RadioButton.Checked)
                        {
                            HotelSelected = Star4RadioButton.Text.ToString();
                            HotelCost = Star4Cost;
                        }
                        else if (Star3RadioButton.Checked)
                        {
                            HotelSelected = Star3RadioButton.Text.ToString();
                            HotelCost = Star3Cost;
                        }
                        else if (NoHotelRadioButton.Checked)
                        {
                            HotelSelected = NoHotelRadioButton.Text.ToString();
                        }

                        // See whether user has opted the Lunch facility
                        if (LunchCheckBox.Checked)
                        {
                            LunchCostTotal = LunchCost * GuestsInNumber;
                        }


                        //________CALCULATIONS_________

                        /* Calculation of TripCost(Location) based on number of guests
                         * and departure time selected  */
                        TripCostTotal = (TripCostPerPerson -
                                             (TripCostPerPerson * TimeDiscount)) *
                                              GuestsInNumber;

                        // Taking out the Location Name to display
                        LocationSelected = LocationListBox.SelectedItem.ToString();
                        LocationSelected = LocationSelected.Substring(0, 
                                            LocationSelected.Length - 3);

                        // Taking out the Time to display
                        TimeSelected = TimeListBox.SelectedItem.ToString().Substring(0, 6);
                        HotelCostTotal = HotelCost * GuestsInNumber;

                        // TotalCost when no special discount of 7.5% is applied.
                        TotalCost = (TripCostTotal + LunchCostTotal + HotelCostTotal);

                        /* A special discount of 7.5% is given to customers with 3 or
                         * more guests along with hotels and lunch opted. */
                        if (GuestsInNumber >= 3 && !NoHotelRadioButton.Checked &&
                            LunchCheckBox.Checked)
                        {
                            TotalCost = TotalCost - (SpecialDiscount * TotalCost);
                        }

                        // Displaying the values to the user
                        LocationLabel.Text = LocationSelected;
                        TimeLabel.Text = TimeSelected;
                        TotalGuestsLabel.Text = GuestsInNumber.ToString();
                        HotelCostLabel.Text = HotelCostTotal.ToString("C");
                        LunchCostLabel.Text = LunchCostTotal.ToString("C");
                        TripCostLabel.Text = TripCostTotal.ToString("C");
                        TotalCostLabel.Text = TotalCost.ToString("C");

                        this.Text = "Mild Atlantic Bus Tours - Quotation";

                        BookButton.Enabled = true;

                        SummaryGroupBox.Visible = false;
                        LogoBottomPictureBox.Visible = false;
                        OrderDetailsGroupBox.Visible = true;

                        BookButton.Focus();
                    }
                }
            }
        }

        /* When Book Button is presses the Display Quotation is committed and Tour is
         *  booked along with showing the appropriate message to the user. */
        private void BookButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Press OK button to Confirm the Booking" +
                                         Environment.NewLine +
                                         Environment.NewLine + "Total Guests: " +
                                         GuestsInNumber.ToString() +
                                         Environment.NewLine + "Location: " +
                                         LocationSelected +
                                         Environment.NewLine + "Departure Time: " +
                                         TimeSelected.Substring(0, 5) +
                                         Environment.NewLine + "Hotel: " +
                                         HotelSelected.Substring(0, 7) +
                                         Environment.NewLine + "Total Cost: " +
                                         TotalCost.ToString("C"),
                                         "Booking Confirmation !",
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Information);

            // If the OK button is pressed ...
            if (result == DialogResult.OK)
            {
                // Transaction getting saved to be showed later in the summary
                TotalCompanyTransactions += 1;
                SumOfTotalCost += TotalCost;
                TotalTripFees += TripCostTotal;
                TotalLodgingFees += HotelCostTotal;
                TotalLunchFees += LunchCostTotal;

                BookButton.Enabled = false;
                SummaryButton.Enabled = true;
                QuoteDetailsGroupBox.Enabled = false;
                
                DisplayButton.Focus();

                // Clearing form for next user using ClearButton_Click()
                ClearButton_Click(null, null);
            }
        }

        /* When Clear Button is Pressed, the form returns to its original state 
         * allowing next transaction to take place by clearing many user input 
         * controls and altering some UI controls. */
        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Clearing the item selected from ListBox
            LocationListBox.SelectedIndex = -1;
            TimeListBox.SelectedIndex = -1;

            GuestsTextBox.Text = "0";

            LunchCheckBox.Checked = false;
            Star5RadioButton.Checked = false;
            Star4RadioButton.Checked = false;
            Star3RadioButton.Checked = false;
            NoHotelRadioButton.Checked = true;

            SummaryGroupBox.Visible = false;
            LogoTopPictureBox.Visible = false;
            OrderDetailsGroupBox.Visible = false;
            QuoteDetailsGroupBox.Visible = true;
            LogoBottomPictureBox.Visible = true;

            BookButton.Enabled = false;
            DisplayButton.Enabled = true;
            QuoteDetailsGroupBox.Enabled = true;
        }

        // When Summary Button is clicked Total Company Transactions, Total trip Fee
        // Total Lodging Fees, Total Lunch Fees, Average Revenue per Booking is 
        // displayed to the user.
        private void SummaryButton_Click(object sender, EventArgs e)
        {
            this.Text = "Mild Atlantic Bus Tours - Company Summary";

            DisplayButton.Enabled = false;

            SummaryGroupBox.Visible = true;
            LogoTopPictureBox.Visible = true;
            LogoBottomPictureBox.Visible = false;
            QuoteDetailsGroupBox.Visible = false;
            OrderDetailsGroupBox.Visible = false;

            // Assigning appropriate values to Form Labels.
            TotalCompanyTransactionsLabel.Text = TotalCompanyTransactions.ToString();
            TotalTripFeesLabel.Text = TotalTripFees.ToString("C");
            TotalLodgingFeesLabel.Text = TotalLodgingFees.ToString("C");
            TotalLunchFeesLabel.Text = TotalLunchFees.ToString("C");
            AverageRevenuePerBookingLabel.Text = (SumOfTotalCost /
                                                  TotalCompanyTransactions).ToString("C");
            ClearButton.Focus();
        }

        // When ExitButton is clicked the application closes.
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
