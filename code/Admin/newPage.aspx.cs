using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class newPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //display the list of pages and bind the drop down list content
        if (!Page.IsPostBack)
        {
            _bindDDL();
            _rebind();
        }
    }

    //create a list of types of pages
    public List<ListItem> getTypes()
    {
        List<ListItem> type = new List<ListItem>();
        type.Add(new ListItem("Select"));
        type.Add(new ListItem("About"));
        type.Add(new ListItem("Services"));
        type.Add(new ListItem("Visitors"));
        type.Add(new ListItem("Policies"));
        return type;
    }

    //bind the dropdownlist to the section list
    private void _bindDDL()
    {
        ddl_type.DataSource = getTypes();
        ddl_type.DataBind();
    }

    //add a new page
    protected void subSubmit(object sender, EventArgs e)
    {
        //create a new instance of the class
        navClass objPage = new navClass();

        //get the values inserted in the form
        string _title = txt_title.Text.ToString();
        string _content = txt_content.Text.ToString();
        string _type = ddl_type.SelectedValue.ToString();
        bool _pub = chk_publish.Checked;

        //send the values to the insert function in the class file, 
        //through a message method that returns a message based on the success of the insert
        output.Text = _message(objPage.newPage(_title, _type, _content, _pub), "add");

        //add a new element to the XML file if the page is to be published
        if (_pub)
        {
            //NOTE: THE FOLLOWING CODE WAS CREATED WITH THE HELP OF http://forums.asp.net/t/1062335.aspx/1.

            //find the xml document
            string xmlpath = Request.PhysicalApplicationPath + "XMLSitemap.xml";
            //initiate a new XML document
            XmlDocument doc = new XmlDocument();
            //load the xml document into the XmlDocument object
            doc.Load(xmlpath);

            //create a new XML Element "url" in the XML document
            XmlElement newElem = doc.CreateElement("url");

            //declare a string to contain the source id for the element
            string pagesource = "";

            //get a "list" (just one item is returned) of pages in the database with the title just entered
            var source = objPage.getPageByName(txt_title.Text.ToString());

            //access the page record
            foreach (var s in source)
            {
                //set the pagesource element in the xml document to the id that was given to the page just inserted
                pagesource = s.gp_id.ToString();
            }

            //initialize the values for the other elements in "url"
            string parent = "";
            string path = "";

            //based on the page section selected, set the value of the parent and path elements
            switch (ddl_type.SelectedValue.ToString())
            {
                case "About":
                    parent = "about";
                    path = "~/navigation/about.aspx";
                    break;
                case "Services":
                    parent = "services";
                    path = "~/navigation/services.aspx";
                    break;
                case "Visitors":
                    parent = "visitors";
                    path = "~/navigation/visitors.aspx";
                    break;
                case "Policies":
                    parent = "policies";
                    path = "~/navigation/policies.aspx";
                    break;
            }


            //Create the child nodes
            newElem.InnerXml = "<loc></loc><lastmod></lastmod><title></title><parent></parent><sourceid></sourceid>";
            newElem["loc"].InnerText = path;
            newElem["lastmod"].InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            newElem["title"].InnerText = txt_title.Text.ToString();
            newElem["parent"].InnerText = parent;
            newElem["sourceid"].InnerText = pagesource;


            //Add the new element to the end of the item list.
            doc.DocumentElement.SelectNodes("/urlset/url[loc='" + path + "']")[0].AppendChild(newElem);


            //Save the modified XML to a file in Unicode format.
            doc.PreserveWhitespace = true;
            XmlTextWriter wrtr = new XmlTextWriter(xmlpath, System.Text.Encoding.Unicode);
            doc.WriteTo(wrtr);
            wrtr.Close();
        }

        //clear the insert form
        txt_title.Text = string.Empty;
        txt_content.Text = string.Empty;
        ddl_type.SelectedIndex = 0;

        //rebind the list of pages to show the new one
        _rebind();
        //hide the new page panel
        pnl_new.Visible = false;

    }

    //hide the new page panel and clear its contents
    protected void subCancel(object sender, EventArgs e)
    {
        output.Text = string.Empty;
        txt_title.Text = string.Empty;
        txt_content.Text = string.Empty;
        ddl_type.SelectedIndex = 0;
        pnl_new.Visible = false;
    }

    //return a message based on the success of an operation
    private string _message(bool success, string action)
    {
        if (success == true)
        {
            return "Page has been " + action + "ed successfully!";
        }
        else
        {
            return "There has been an error on " + action + "ing the page. Please try again or contact a network administrator.";
        }
    }

    //bind the list of pages
    private void _rebind()
    {
        navClass objPages = new navClass();
        rpt_all.DataSource = objPages.getAll();
        rpt_all.DataBind();
    }

    //show the edit panel for an existing page
    protected void subEdit(object sender, RepeaterCommandEventArgs e)
    {
        //clear the output label
        output.Text = string.Empty;

        //create a new instance of the class
        navClass objDetails = new navClass();

        //bind the detailsview to the event aquired from the class file
        dtv_edit.DataSource = objDetails.getPageByID(int.Parse(e.CommandArgument.ToString()));
        dtv_edit.DataBind();

        //fill the dropdownlist in the detailsview with the types list
        DropDownList sections = (DropDownList)dtv_edit.FindControl("ddl_section");
        sections.DataSource = getTypes();
        sections.DataBind();

        //set the selected type to that matching the record
        var selected = objDetails.getPageByID(int.Parse(e.CommandArgument.ToString()));
        string sel = "";
        foreach (var s in selected)
        {
            sel = s.gp_section.ToString();
        }
        sections.SelectedValue = sel;

        //change the mode of the detailsview to edit and make the panel visible
        dtv_edit.ChangeMode(DetailsViewMode.Edit);
        pnl_edit.Visible = true;

        //hide the panel that shows all pages
        pnl_all.Visible = false;
    }

    //execute an update of a page
    protected void subChange(object sender, DetailsViewCommandEventArgs e)
    {
        //create a new instance of the navigation class
        navClass objNav = new navClass();

        //NOTE: THE FOLLOWING CODE WAS CREATED WITH THE HELP OF http://forums.asp.net/t/1062335.aspx/1.

        //locate the xml file containing the sitemap
        string xmlpath = Request.PhysicalApplicationPath + "XMLSitemap.xml";

        //create a new XmlDocument object to store the sitemap
        XmlDocument doc = new XmlDocument();

        //load the sitemap into the new XmlDocument
        doc.Load(xmlpath);

        //create variables to store the parent and path element values for the new xml "url" element
        string parent = "";
        string path = "";

        //do something based on the command name provided
        switch (e.CommandName)
        {
            case "save":
                //get the id value sent from the sender
                int _id = int.Parse(e.CommandArgument.ToString());

                //go into the edit mode of the detailsview to access its controls
                if (dtv_edit.CurrentMode == DetailsViewMode.Edit)
                {
                    //set the title textbox input to the title
                    TextBox txt_title = (TextBox)dtv_edit.FindControl("txt_title");
                    string title = txt_title.Text;

                    //set the content textbox input to the content
                    TextBox txt_content = (TextBox)dtv_edit.FindControl("txt_content");
                    string content = txt_content.Text;

                    //set active to true or false based on the status of the check box
                    CheckBox chk_active = (CheckBox)dtv_edit.FindControl("chk_activeE");
                    bool active = chk_active.Checked;

                    //find the section the page belongs in based on the section selected in the drop down list
                    DropDownList ddl_section = (DropDownList)dtv_edit.FindControl("ddl_section");
                    string section = ddl_section.SelectedValue.ToString();

                    //run the update against the database and display a message in the output label based on its success
                    output.Text = _message(objNav.updatePage(_id, title, section, content, active), "edit");

                    //set the parent and path based on the section provided to be inserted into the url element
                    switch (section)
                    {
                        case "About":
                            parent = "about";
                            path = "~/navigation/about.aspx";
                            break;
                        case "Services":
                            parent = "services";
                            path = "~/navigation/services.aspx";
                            break;
                        case "Visitors":
                            parent = "visitors";
                            path = "~/navigation/visitors.aspx";
                            break;
                        case "Policies":
                            parent = "policies";
                            path = "~/navigation/policies.aspx";
                            break;
                    }

                    //create the url element in the XmlDocument
                    XmlElement updElem = doc.CreateElement("url");

                    //create the child nodes
                    updElem.InnerXml = "<loc></loc><lastmod></lastmod><title></title><parent></parent><sourceid></sourceid>";
                    updElem["loc"].InnerText = path;
                    updElem["lastmod"].InnerText = DateTime.Now.ToString("yyyy-MM-dd");
                    updElem["title"].InnerText = title;
                    updElem["parent"].InnerText = parent;
                    updElem["sourceid"].InnerText = _id.ToString();

                    //find the element that matches this page in the xml document
                    var elements = doc.GetElementsByTagName("sourceid");
                    var match = false;

                    //loop through the elements in the xml document looking for the element with the source id that matches this record id
                    foreach (XmlNode el in elements)
                    {
                        if (el.InnerText == _id.ToString())
                        {
                            match = true;

                            /*
                             * Now we want to figure out what we need to do with the existing xml sitemap. There are a few different scenarios:
                            1. The record in the table matches a url element in the sitemap and the user inputs that the page is published AND is in the same section as before.
                                  -in this instance we simply update the content of the element by replacing it with a new one
                            2. The record in the table matches a url element in the sitemap and the user inputs that the page is published AND is NOT in the same section as before
                                  -in this instance we remove the element from where it is and add a new one to the new section
                            3. The record in the table DOES NOT match a url element in the sitemap and the user inputs that the page is published
                                  -in this instance the url element must simply be added to the appropriate section
                            4. The user input determines that the page should not be published and the record in the table matches a url element in the sitemap
                                  -here we simply remove the element from the sitemap
                            5. The user input determines that the page should not be published and the record in the table DOES NOT match a url element in the sitemap
                                  -do nothing
                             * */

                            
                            if (el.ParentNode.ChildNodes[0].InnerText == path && active)
                            {
                                //scenario 1
                                el.ParentNode.ParentNode.ReplaceChild(updElem, el.ParentNode);
                                break;
                            }
                            else
                            {
                                //scenario 2 and 4
                                el.ParentNode.ParentNode.RemoveChild(el.ParentNode);
                                if (active)
                                {
                                    //scenario 2
                                    doc.DocumentElement.SelectNodes("/urlset/url[loc='" + path + "']")[0].AppendChild(updElem);
                                    break;
                                }
                            }
                        }
                    }
                    if (!match && active)
                    {
                        //scenario 3
                        doc.DocumentElement.SelectNodes("/urlset/url[loc='" + path + "']")[0].AppendChild(updElem);
                    }

                    // 3. Save the modified XML to a file in Unicode format.
                    doc.PreserveWhitespace = true;
                    XmlTextWriter wrtr = new XmlTextWriter(xmlpath, System.Text.Encoding.Unicode);
                    doc.WriteTo(wrtr);
                    wrtr.Close();
                }

                break;
            case "cancel":
                break;
            case "delet":
                //execute a delete against the database and display an output message
                output.Text = _message(objNav.deletePage(int.Parse(e.CommandArgument.ToString())), "delet");

                //find the matching url element in the sitemap and remove it
                var elementsD = doc.GetElementsByTagName("sourceid");
                foreach (XmlNode el in elementsD)
                {
                    if (el.InnerText == e.CommandArgument.ToString())
                    {
                        el.ParentNode.ParentNode.RemoveChild(el.ParentNode);
                        break;
                    }
                }
                // 3. Save the modified XML to a file in Unicode format.
                doc.PreserveWhitespace = true;
                XmlTextWriter wrtrD = new XmlTextWriter(xmlpath, System.Text.Encoding.Unicode);
                doc.WriteTo(wrtrD);
                wrtrD.Close();
                break;
        }
        //hide and show the appropriate panels
        pnl_edit.Visible = false;
        pnl_all.Visible = true;

        //rebind the page list to show changes
        _rebind();
    }

    protected void showNew(object sender, EventArgs e)
    {
        //clear the output label and display the new page panel
        output.Text = string.Empty;
        pnl_new.Visible = true;
    }
    protected void modeChange(object sender, DetailsViewModeEventArgs e)
    {
    }
}