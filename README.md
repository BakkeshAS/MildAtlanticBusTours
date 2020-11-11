# MildAtlanticBusTours
MildAtlanticBusTours MABT is a Windows Forms built using C# to assist the sales representatives at the front desk of the company.

**Problem Statement:**

Create a well-designed application for Mild Atlantic Bus Tours (MABT), a company that provides bus excursions to well-known landmarks on the west coast of Ireland. The purpose of your application is to enable the companies front of house sales team to generate prices and process bookings for these excursions. The company currently provides excursions to the following locations, each of which is priced based on location and departure time.

| Location | Price|
|----------|------|
|Cliffs of Moher | €55|
|Kylemore Abbey |€50|
|Bunratty Castle |€75|
|The Burren | €45|
|Connemara|  €75|
|Belmullet  | €99|

**Table 1: Locations& base pricing**

MABT offers discounts for departures booked for earlier in the day, and for the last departure of the day as follows:
|Departure | Price|
|----------|------|
|7.00 |20%|
|8.00| 10%|
|9.00 |5%|
|10.00| 0%|
|11.00| 0%|
|13.00| 25%|

**Table 2: Discounts based on Departure time**

In addition, this season MABT has decided to offer its customers the option of an overnight stay in a hotel near their chosen destination – pricing is based on the hotels star rating. As this is a potential large revenue generator – the company have asked that the sales team does it best to upsell this to as many customers as possible.

|Hotel Rating | Price|
|-------------|------|
|3 Star |€55 per person|
|4 Star |€75 per person|
|5 Star |€100 per person|

**Table 3: Hotel Pricing**

The company offers its customers an option of purchasing a packed lunch for their excursion in advance at a cost of €11.50 per person.
Finally, if a potential client wishes to book an excursion for 3 or more guests, which includes an overnight stay and a packed lunch, a discount of 7.5% is applied to the full booking cost.

**Basic Flow of events:**

To generate a quote for a perspective customer(s), the user enters the location where the guest(s) wishes to take the bus tour, what time they wish to depart, and how many guest(s) wish to go. Potential customers can also select a hotel option and whether they wish to avail of the pack lunch for their trip, which the user will input into the application using a suitable control. When the user clicks the ‘Display’ button, the application displays all of the details of the chosen excursion along with trip cost, the costs of any optional extras and the overall cost.
If the prospective customer wishes to proceed, the user clicks the ‘Book’ button, after which a Message Box with a formatted message confirming the completion of the booking is displayed. This confirmation message contains the number of places booked, the excursion location, its departure time (hotel details if applicable) along total cost.
If the user wishes to check how many bookings have been processed, they can click the ‘Summary’ button and the application displays the total number transactions processed, the total trip fees, the total lodging fees, the value of options chosen and the average revenue per booking.

**Design Notes:**

Follow principles of good design.
Handle any exceptions that could occur in your project & provide user input validation as needed.
Include Display, Book, Booking Summary, Clear, and Exit buttons.
Include appropriate ToolTips & Access keys as appropriate.
The project contains a single form, and you are required to include the following controls in its design - Radio buttons, Check Boxes& List Boxes.
Use of any collections (list, array etc.) including list view, data grid controls, along with any database is strictly prohibited. If in doubt, please consult first before use.
