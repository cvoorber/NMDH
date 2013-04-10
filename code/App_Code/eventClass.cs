using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Web.UI;

/* This custom control allows staff members to book the staff room at an available time using their employee id 
 * (there is no use in giving each employee a login JUST so that they can book the room once every few years).
 */

namespace ilanaCustom
{

    public class eventClass : CompositeControl
    {
        //this will be the title of the control   
        private Label _lblheading;

        //id of the staff member booking the event
        private Label _lblid;
        private TextBox _id;
        private RequiredFieldValidator _rfvid;
        private CustomValidator _cvid;

        //title of the event
        private Label _lbltitle;
        private TextBox _title;
        private RequiredFieldValidator _rfvtitle;
        private RegularExpressionValidator _revtitle;

        //the date of the event
        private Label _lbldate;
        //labels
        private Label _lblday;
        private Label _lblmonth;
        private Label _lblyear;
        //textboxes
        private DropDownList _day;
        private DropDownList _month;
        private DropDownList _year;
        //validators
        private RequiredFieldValidator _rfvday;
        private RequiredFieldValidator _rfvmonth;
        private RequiredFieldValidator _rfvyear;

        //the start time of the event
        private Label _lblstart;
        private TextBox _start;
        private RequiredFieldValidator _rfvstart;
        private RegularExpressionValidator _revstart;

        //the end time of the event
        private Label _lblend;
        private TextBox _end;
        private RequiredFieldValidator _rfvend;
        private RegularExpressionValidator _revend;
        private CustomValidator _cmtime;

        //number of people
        private Label _lblattendees;
        private TextBox _attendees;
        private RequiredFieldValidator _rfvattendees;
        //first compare validator checks data type, the second ensures that the number is below capacity. The popular people are screwed
        private CompareValidator _cvattendees;
        private CompareValidator _cvattendees2;

        //event description
        private Label _lbldesc;
        private TextBox _desc;
        private RequiredFieldValidator _rfvdesc;

        //submit
        private Button _submit;
        public event EventHandler CustomEvent; //this creates an event handler that is available on the page itself (to hide and show the panels)

        //output the values
        private Label _lbloutput;

        protected override void CreateChildControls()
        {
            /* In this function I initialize each variable as its respective control, give it an ID, text (if applicable), 
             * and any other attributes before adding it to the parent control using this.Controls.Add()
             */

            // --------control title----------- //
            _lblheading = new Label();
            _lblheading.ID = "lbl_head";
            _lblheading.Text = "Book a Staff Event";
            this.Controls.Add(_lblheading);

            // --------id input----------- //
            //this is the label
            _lblid = new Label();
            _lblid.ID = "lbl_id";
            _lblid.Text = "Employee ID:";
            this.Controls.Add(_lblid);

            //textbox
            _id = new TextBox();
            _id.ID = "txt_id";
            this.Controls.Add(_id);

            //id is required
            _rfvid = new RequiredFieldValidator();
            _rfvid.ID = "rfv_id";
            _rfvid.ControlToValidate = _id.ID;
            _rfvid.Text = "Please provide your employee id.";
            _rfvid.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvid);

            //check that id exists
            _cvid = new CustomValidator();
            _cvid.ID = "cv_id";
            _cvid.ControlToValidate = _id.ID;
            _cvid.ServerValidate += new ServerValidateEventHandler(idValidate);
            _cvid.Text = "This ID does not exist!";
            _cvid.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_cvid);
            

            // --------title input----------- //
            //this is the label
            _lbltitle = new Label();
            _lbltitle.ID = "lbl_title";
            _lbltitle.Text = "Event Title:";
            this.Controls.Add(_lbltitle);

            //textbox
            _title = new TextBox();
            _title.ID = "txt_title";
            this.Controls.Add(_title);

            //title is required
            _rfvtitle = new RequiredFieldValidator();
            _rfvtitle.ID = "rfv_title";
            _rfvtitle.ControlToValidate = _title.ID;
            _rfvtitle.Text = "Please provide the event title.";
            _rfvtitle.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvtitle);

            //title must contain only letters and ' or . if applicable
            _revtitle = new RegularExpressionValidator();
            _revtitle.ID = "rev_title";
            _revtitle.ControlToValidate = _title.ID;
            _revtitle.Text = "Please enter a valid title.";
            _revtitle.ValidationExpression = @"^[A-Za-z ']+$";
            _revtitle.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_revtitle);

            // --------date input----------- //
            //this is the heading for the date section
            _lbldate = new Label();
            _lbldate.ID = "lbl_date";
            _lbldate.Text = "Event Date:";
            this.Controls.Add(_lbldate);

            //label for day
            _lblday = new Label();
            _lblday.ID = "lbl_day";
            _lblday.Text = "day";
            this.Controls.Add(_lblday);

            //label for month
            _lblmonth = new Label();
            _lblmonth.ID = "lbl_month";
            _lblmonth.Text = "month";
            this.Controls.Add(_lblmonth);

            //label for year
            _lblyear = new Label();
            _lblyear.ID = "lbl_year";
            _lblyear.Text = "year";
            this.Controls.Add(_lblyear);

            //create and populate the drop down list for days of the month
            _day = new DropDownList();
            _day.ID = "ddl_day";
            _day.DataSource = getdays(); //this function gets a list of numbers 1-31
            _day.DataBind();
            this.Controls.Add(_day);

            //create and populate the drop down list for months of the year
            _month = new DropDownList();
            _month.ID = "ddl_month";
            _month.DataSource = getmonths(); //gets a list of shortened months
            _month.DataBind();
            this.Controls.Add(_month);
            _month.SelectedValue = DateTime.Now.Month.ToString();

            //create and populate the drop down list for coming years
            _year = new DropDownList();
            _year.ID = "ddl_year";
            _year.DataSource = getyears();
            _year.DataBind();
            this.Controls.Add(_year);
            _year.SelectedValue = DateTime.Now.Year.ToString();

            //a day must be selected
            _rfvday = new RequiredFieldValidator();
            _rfvday.ID = "rfv_day";
            _rfvday.ControlToValidate = _day.ID;
            _rfvday.Text = "Select a day";
            _rfvday.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvday);

            //month must be selected
            _rfvmonth = new RequiredFieldValidator();
            _rfvmonth.ID = "rfv_month";
            _rfvmonth.ControlToValidate = _month.ID;
            _rfvmonth.Text = "Select a month";
            _rfvmonth.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvmonth);

            //year must be selected
            _rfvyear = new RequiredFieldValidator();
            _rfvyear.ID = "rfv_year";
            _rfvyear.ControlToValidate = _year.ID;
            _rfvyear.Text = "Select a year";
            _rfvyear.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvyear);

            // --------start time----------- //
            //start label
            _lblstart = new Label();
            _lblstart.ID = "lbl_start";
            _lblstart.Text = "Start Time:";
            this.Controls.Add(_lblstart);

            //start textbox
            _start = new TextBox();
            _start.ID = "txt_start";
            this.Controls.Add(_start);
            _lblstart.AssociatedControlID = _start.ID;

            //start time is required
            _rfvstart = new RequiredFieldValidator();
            _rfvstart.ID = "rfv_start";
            _rfvstart.ControlToValidate = _start.ID;
            _rfvstart.Text = "Please enter a start time";
            _rfvstart.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvstart);

            //start time must be a valid time
            _revstart = new RegularExpressionValidator();
            _revstart.ControlToValidate = _start.ID;
            _revstart.Text = "Please enter a valid time in 00:00AM/PM format";
            //WOOOO I made this expression on my own!!! Validates for 12 hour clock, accepts: 03:00 pm, 3:00am, 3:00PM, 3:00Am
            _revstart.ValidationExpression = "^([0]?[1-9]|[1][0-2]):[0-5][0-9][ ]?[aApP][mM]$";
            _revstart.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_revstart);

            // --------end time----------- //
            //end time label
            _lblend = new Label();
            _lblend.ID = "lbl_end";
            _lblend.Text = "End Time:";
            this.Controls.Add(_lblend);

            //end time input (text)
            _end = new TextBox();
            _end.ID = "txt_end";
            this.Controls.Add(_end);
            _lblend.AssociatedControlID = _end.ID;

            //end time is required
            _rfvend = new RequiredFieldValidator();
            _rfvend.ID = "rfv_end";
            _rfvend.ControlToValidate = _end.ID;
            _rfvend.Text = "Please enter a end time";
            _rfvend.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvend);

            //end time must be valid
            _revend = new RegularExpressionValidator();
            _revend.ControlToValidate = _end.ID;
            _revend.Text = "Please enter a valid time in 00:00 AM/PM format";
            //WOOOO I made this expression on my own!!! Validates for 12 hour clock, accepts: 03:00 pm, 3:00am, 3:00PM, 3:00Am
            _revend.ValidationExpression = "^([0]?[1-9]|[1][0-2]):[0-5][0-9][ ]?[aApP][mM]$";
            _revend.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_revend);

            _cmtime = new CustomValidator();
            _cmtime.ControlToValidate = _end.ID;
            _cmtime.ServerValidate += new ServerValidateEventHandler(timeValidate);
            _cmtime.Display = ValidatorDisplay.Dynamic;
            _cmtime.Text = "End time must be after the start time!";
            this.Controls.Add(_cmtime);


            // --------Number of Attendees----------- //
            //label
            _lblattendees = new Label();
            _lblattendees.ID = "lbl_attendees";
            _lblattendees.Text = "# of People:";
            this.Controls.Add(_lblattendees);

            //textbox
            _attendees = new TextBox();
            _attendees.ID = "txt_attendees";
            _attendees.MaxLength = 2;
            this.Controls.Add(_attendees);
            _lblattendees.AssociatedControlID = _attendees.ID;

            //# is required
            _rfvattendees = new RequiredFieldValidator();
            _rfvattendees.ID = "rfv_attendees";
            _rfvattendees.ControlToValidate = _attendees.ID;
            _rfvattendees.Text = "Please provide the number of people using the room.";
            _rfvattendees.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvattendees);

            //# must be an integer
            _cvattendees = new CompareValidator();
            _cvattendees.ID = "cv_attendees";
            _cvattendees.ControlToValidate = _attendees.ID;
            _cvattendees.Text = "Please enter a valid number";
            _cvattendees.Type = ValidationDataType.Integer;
            _cvattendees.Operator = ValidationCompareOperator.DataTypeCheck;
            _cvattendees.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_cvattendees);

            //#must be less than 51 (capacity)
            _cvattendees2 = new CompareValidator();
            _cvattendees2.ID = "cv_attendees2";
            _cvattendees2.ControlToValidate = _attendees.ID;
            _cvattendees2.Text = "Maximum capacity for this room is 50";
            _cvattendees2.Type = ValidationDataType.Integer;
            _cvattendees2.Operator = ValidationCompareOperator.LessThanEqual;
            _cvattendees2.ValueToCompare = "50";
            _cvattendees2.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_cvattendees2);

            // --------Event Description----------- //
            //label
            _lbldesc = new Label();
            _lbldesc.ID = "lbl_desc";
            _lbldesc.Text = "Details:";
            this.Controls.Add(_lbldesc);

            //textbox
            _desc = new TextBox();
            _desc.ID = "txt_desc";
            _desc.TextMode = TextBoxMode.MultiLine; //longer length is accepted
            _desc.Width = 145;
            this.Controls.Add(_desc);
            _lbldesc.AssociatedControlID = _desc.ID;

            //description is required
            _rfvdesc = new RequiredFieldValidator();
            _rfvdesc.ID = "rfv_desc";
            _rfvdesc.ControlToValidate = _desc.ID;
            _rfvdesc.Text = "Please enter a description/details";
            _rfvdesc.Display = ValidatorDisplay.Dynamic;
            this.Controls.Add(_rfvdesc);

            // --------submit form----------- //
            _submit = new Button();
            _submit.ID = "btn_submit";
            _submit.Text = "Submit";
            _submit.Click += this.subSubmit;
            this.Controls.Add(_submit);

            // --------display output----------- //
            _lbloutput = new Label();
            _lbloutput.ID = "lbl_output";
            this.Controls.Add(_lbloutput);
        }

        //this method adds the record into the database
        protected void subSubmit(object sender, EventArgs e)
        {
            //check that the page is valid before proceeding
            if (!Page.IsValid)
                return;

            //clear any previous messages
            _lbloutput.Text = string.Empty;

            //form a proper datetime using the day, month, year, and time provided
            DateTime start = DateTime.Parse(_month.Text.ToString() + "/" + _day.Text.ToString() + "/" + _year.Text.ToString() + " " + _start.Text.ToString());
            DateTime end = DateTime.Parse(_month.Text.ToString() + "/" + _day.Text.ToString() + "/" + _year.Text.ToString() + " " + _end.Text.ToString());
            
            //get the other values from the inputs and convert them to the proper datatype
            int staffID = int.Parse(_id.Text);
            int people = int.Parse(_attendees.Text);
            string desc = _desc.Text.ToString();
            string title = _title.Text.ToString();

            //create a new instance of the class
            staffroomClass objtest = new staffroomClass();

            //in validating the provided times, initially we assume that there is no time conflict
            bool conflict = false;

            //compare the inputs to each booked time in the database
            foreach (var test in objtest.getEventsbyDay(start.Date, start.Date.AddDays(1)))
            {
                //there are three scenarios here that indicate a conflict.
                //1. The start time of the new booking is between the start and end of an existing booking
                //2. The end time of the new booking is between the start and end of an existing booking
                //3. The start time of the new booking is before that of an existing booking WHILE the end time of the new 
                //      booking is after the end of the existing one. In this case, the new event is encompassing one that exists.    
                if (start < test.rb_start && end > test.rb_end
                    || start > test.rb_start && start < test.rb_end
                    || end > test.rb_start && end < test.rb_end)
                {
                    conflict = true; //if the if statement ever rings true, the new booking is conflicting with an existing one
                    _lbloutput.Text = "<span style='color:red;font-style:italic;'>The event you are trying to add conflicts with " + test.rb_title.ToString() + " on that day which begins at " + test.rb_start.ToShortTimeString() + " and ends at " + test.rb_end.ToShortTimeString() + ".</span>";
                    break; //stop the foreach
                }
            }

            if (!conflict) //insert the event if there is no conflict
            {

                //creating an instance of our LINQ object
                ndmhDCDataContext objDatabaseDC = new ndmhDCDataContext();
                //to ensure all data will be disposed when finished
                using (objDatabaseDC)
                {
                    //create an instance of our table object
                    ndmh_roomBooking objNewBook = new ndmh_roomBooking();

                    //set the value of each variable in the object
                    objNewBook.rb_member = staffID;
                    objNewBook.rb_title = title;
                    objNewBook.rb_start = start;
                    objNewBook.rb_end = end;
                    objNewBook.rb_people = people;
                    objNewBook.rb_description = desc;

                    //insert command
                    objDatabaseDC.ndmh_roomBookings.InsertOnSubmit(objNewBook);

                    //commit insert against database
                    objDatabaseDC.SubmitChanges();

                    //empty the input controls and hide the new event panel
                    _title.Text = string.Empty;
                    _month.SelectedValue = "";
                    _day.SelectedValue = "";
                    _year.SelectedValue = DateTime.Now.Year.ToString();
                    _start.Text = string.Empty;
                    _end.Text = string.Empty;
                    _attendees.Text = string.Empty;
                    _desc.Text = string.Empty;
                }

                //fire the public EventHandler
                CustomEvent(this, EventArgs.Empty);
            }
        }

        //populate days of the month
        public List<ListItem> getdays()
        {
            List<ListItem> days = new List<ListItem>();
            days.Add(new ListItem(""));
            for (var i = 1; i < 32; i++)
            {
                days.Add(new ListItem(i.ToString()));
            }
            return days;
        }

        //populate months of the year
        public List<ListItem> getmonths()
        {
            List<ListItem> months = new List<ListItem>();
            months.Add(new ListItem(""));

            for (int i = 1; i < 13; i++)
            {
                months.Add(new ListItem(i.ToString()));
            }
            return months;
        }

        //populate the next 20 years
        public List<ListItem> getyears()
        {
            List<ListItem> years = new List<ListItem>();
            years.Add(new ListItem(""));
            for (var i = int.Parse(DateTime.Now.Year.ToString()); i < (int.Parse(DateTime.Now.Year.ToString()) + 20); i++)
            {
                years.Add(new ListItem(i.ToString()));
            }
            return years;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            /* This function determines the display of the custom control using HtmlTextWriter to render the controls within it.
             * In summary, the inputs are all organized within a table that sits inside a div. The results are shown below it */

            //this div contains the table and the submit button together
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, "Solid");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderColor, "Gray");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, "1px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "#e2f6f3");
            writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "Left");

            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "10px");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "customControl");
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            //header section of the table displays the title
            writer.RenderBeginTag(HtmlTextWriterTag.Thead);
            writer.AddStyleAttribute(HtmlTextWriterStyle.FontStyle, "Bold");
            writer.AddStyleAttribute(HtmlTextWriterStyle.FontSize, "14pt");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "#496662");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "White");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0 47px");
            _lblheading.RenderControl(writer);
            writer.RenderEndTag(); //thead

            //the id inputs
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _lblid.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _id.RenderControl(writer);
            _rfvid.RenderControl(writer);
            _cvid.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderEndTag(); //tr

            //the title inputs
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _lbltitle.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _title.RenderControl(writer);
            _rfvtitle.RenderControl(writer);
            _revtitle.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderEndTag(); //tr

            //the date inputs
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _lbldate.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _day.RenderControl(writer); //day dropdown
            _rfvday.RenderControl(writer);
            _month.RenderControl(writer); //month dropdown
            _rfvmonth.RenderControl(writer);
            _year.RenderControl(writer); //year dropdown
            _rfvyear.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderEndTag(); //tr

            //helper labels for the date inputs
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.RenderEndTag(); //td
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0 7px");
            _lblday.RenderControl(writer);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0 10px");
            _lblmonth.RenderControl(writer);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0 10px");
            _lblyear.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderEndTag(); //tr

            //start time inputs
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _lblstart.RenderControl(writer);
            writer.RenderEndTag();//td
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _start.RenderControl(writer); //start textbox
            _rfvstart.RenderControl(writer);
            _revstart.RenderControl(writer);
            writer.RenderEndTag();//td
            writer.RenderEndTag();//tr

            //end time inputs
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _lblend.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _end.RenderControl(writer); //end textbox
            _rfvend.RenderControl(writer);
            _revend.RenderControl(writer);
            _cmtime.RenderControl(writer);
            writer.RenderEndTag();//td
            writer.RenderEndTag();//tr

            //number of attendees
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _lblattendees.RenderControl(writer);
            writer.RenderEndTag();//td
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _attendees.RenderControl(writer); //attendees textbox
            _rfvattendees.RenderControl(writer);
            _cvattendees.RenderControl(writer);
            _cvattendees2.RenderControl(writer);
            writer.RenderEndTag();//td
            writer.RenderEndTag();//tr

            //description inputs
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _lbldesc.RenderControl(writer); //description text area
            writer.RenderEndTag(); //td
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _desc.RenderControl(writer);
            _rfvdesc.RenderControl(writer);
            writer.RenderEndTag(); //td
            writer.RenderEndTag(); //tr

            writer.RenderEndTag(); //table

            //the submit button
            writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "#496662");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "White");
            writer.AddStyleAttribute(HtmlTextWriterStyle.FontStyle, "Bold");
            writer.AddStyleAttribute(HtmlTextWriterStyle.FontFamily, "Times New Roman");
            writer.AddStyleAttribute(HtmlTextWriterStyle.FontSize, "12pt");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0 100px");
            _submit.RenderControl(writer);

            writer.RenderEndTag(); //div

            //display the outputs
            writer.AddStyleAttribute(HtmlTextWriterStyle.MarginTop, "30px");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            _lbloutput.RenderControl(writer);
            writer.RenderEndTag();//div
        }

        //this is a custom validation method to check that the start time is before the end time
        protected void timeValidate(object sender, ServerValidateEventArgs e)
        {
            DateTime start = DateTime.Parse(_start.Text.ToString());
            DateTime end = DateTime.Parse(e.Value.ToString());

            if (start < end)
            {
                e.IsValid = true;
            }
            else e.IsValid = false;
        }

        //this is a custom validation method that checks the employee id provided against the database to ensure that it exists
        protected void idValidate(object sender, ServerValidateEventArgs e)
        {
            //we initially assume that the page is invalid
            e.IsValid = false;

            //create a new instance of the class
            staffClass objID = new staffClass();

            //get a list of all employees
            var allID = objID.getList();
            foreach (var staff in allID)
            {
                //if the id matches an existing employee, the page is valid
                if (staff.sl_id.ToString() == _id.Text.ToString())
                {
                    e.IsValid = true;
                    break;
                }
            }
        }
    }
}