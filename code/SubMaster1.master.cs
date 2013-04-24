using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

public partial class SubMaster1 : System.Web.UI.MasterPage
{
    //expose the url publicly so that the page can pass through its url
    private string _url = "";
    public string pp_Url
    {
        get { return _url; }
        set { _url = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //fill the side menu
        _loadMenu();

        //create an event for when a menu item is clicked
        side_menu.MenuItemClick += sideMenu_Click;

        //load the initial content on the page
        if (!Page.IsPostBack)
        {
            //locate the sitemap
            string xmlPath = Request.PhysicalApplicationPath + @"XMLSitemap.xml";
            //create a new XmlDocument object
            XmlDocument doc = new XmlDocument();
            //load the sitemap into the document
            doc.Load(xmlPath);
            //load the url nodes into an XML nodelist
            XmlNodeList titleList = doc.GetElementsByTagName("url");
            //declare the string pagename
            string pagename = "";

            //loop through each node in titlelist (list of page titles)
            for (var i = 0; i < titleList.Count; i++)
            {
                //check if the node's url matches that of the current page
                if(titleList[i].ChildNodes[0].FirstChild.Value == pp_Url)
                {
                    //set the pagename variable to the node that matches the current page
                    //this will be used later to retrieve the content
                    pagename = titleList[i].ChildNodes[2].FirstChild.Value.ToString();
                    break;
                }
            }
            //create a new instance of the navigation class
            navClass menuObj = new navClass();
            //bind the repeater to the content of that page
            rpt_content.DataSource = menuObj.getPageByName(pagename);
            rpt_content.DataBind();
        }
    }

    //method to handle the change of content on the page (when the sidemenu is clicked)
    protected void sideMenu_Click(object sender, MenuEventArgs e)
    {
        //ensure that the menu item has a value
        if (e.Item.Value != null)
        {
            if(e.Item.Value.ToString() == "FAQ")
            {
                Response.Redirect("~/navigation/faq-search.aspx");
            }
            else
            {
            //create a new instance of the navClass and bind the content to that requested
            navClass menuObj = new navClass();
            rpt_content.DataSource = menuObj.getPageByName(e.Item.Value);
            rpt_content.DataBind();
            }
        }
    }

    //method to load the submenu
    public void _loadMenu()
    {
        //clear the current list of menuitems (items may have changed)
        side_menu.Items.Clear();

        //locate the xml document
        string xmlPath = Request.PhysicalApplicationPath + @"XMLSitemap.xml";
        //create a new XmlDocument object to store the xml file
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlPath);
        //load a list of url nodes
        XmlNodeList titleList = doc.GetElementsByTagName("url");
        //declare a string that represents the parent of the current url
        string urlparent = "";
        //loop through each url node
        foreach (XmlNode node in titleList)
        {
            //if the node's url matches the current page url, set the parent to that node's parent tag value
            if (node.ChildNodes[0].FirstChild.Value == pp_Url)
            {
                urlparent = node.ChildNodes[3].FirstChild.Value.ToString();
            }
        }

        //loop through the titlelist
        foreach (XmlNode node in titleList)
        {
            //if the node's parent matches the parent string value determined above (the parent is the page requested)
            if (node.ChildNodes[3].FirstChild.Value == urlparent)
            {
                //create a new MenuItem that stores the node
                MenuItem output = new MenuItem();
                output.Text = node.ChildNodes[2].FirstChild.Value;
                output.Target = node.ChildNodes[0].FirstChild.Value.ToString();
                side_menu.Items.Add(output);
            }

        }
    }

    // initiate the eventhandler passed down from the masterpage
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ((maintemplate)this.Master).upFont += new EventHandler(fontInc);
        ((maintemplate)this.Master).downFont += new EventHandler(fontDec);
    }

    //increase the font size of the repeater on the page
    protected void fontInc(object sender, EventArgs e)
    {
        //check if the repeater is populated
        if (rpt_content.Items.Count > 0)
        {
            // create new title and content objects
            Label title = new Label();
            Label content = new Label();

            //loop through each item in the repeater (which should be one since it matches an ID)
            //this is used to access the controls in the repeater
            foreach (RepeaterItem ri in rpt_content.Items)
            {
                //set the title label to the matching control in the repater
                title = (Label)ri.FindControl("lbltitle");
                content = (Label)ri.FindControl("lblcontent");
            }

            //increase the font size of each by 2pt
            int newsizeSide = int.Parse(side_menu.Font.Size.Unit.ToString().Substring(0, 2)) + 2;
            int newsizeHead = int.Parse(title.Font.Size.Unit.ToString().Substring(0, 2)) + 2;
            int newsizeContent = int.Parse(content.Font.Size.Unit.ToString().Substring(0, 2)) + 2;

            //the maximum size of the side menu is 16pt
            if (newsizeSide > 16)
            {
                //at this point, the new font size variable for each control is equal to its current size
                newsizeSide = int.Parse(side_menu.Font.Size.Unit.ToString().Substring(0, 2));
                newsizeHead = int.Parse(title.Font.Size.Unit.ToString().Substring(0, 2));
                newsizeContent = int.Parse(content.Font.Size.Unit.ToString().Substring(0, 2));
            }

            //set the new font size to match the determined variable
            side_menu.Font.Size = FontUnit.Point(newsizeSide);
            title.Font.Size = FontUnit.Point(newsizeHead);
            content.Font.Size = FontUnit.Point(newsizeContent);
        }
    }

    protected void fontDec(object sender, EventArgs e)
    {
        //check if the repeater is populated
        if (rpt_content.Items.Count > 0)
        {
            // create new title and content objects
            Label title = new Label();
            Label content = new Label();

            //loop through each item in the repeater (which should be one since it matches an ID)
            //this is used to access the controls in the repeater
            foreach (RepeaterItem ri in rpt_content.Items)
            {
                //set the title label to the matching control in the repater
                title = (Label)ri.FindControl("lbltitle");
                content = (Label)ri.FindControl("lblcontent");
            }

            //increase the font size of each by 2pt
            int newsizeSide = int.Parse(side_menu.Font.Size.Unit.ToString().Substring(0, 2)) - 2;
            int newsizeHead = int.Parse(title.Font.Size.Unit.ToString().Substring(0, 2)) - 2;
            int newsizeContent = int.Parse(content.Font.Size.Unit.ToString().Substring(0, 2)) - 2;

            //the minimum size of the side menu is 10pt
            if (newsizeSide <10)
            {
                //at this point, the new font size variable for each control is equal to its current size
                newsizeSide = int.Parse(side_menu.Font.Size.Unit.ToString().Substring(0, 2));
                newsizeHead = int.Parse(title.Font.Size.Unit.ToString().Substring(0, 2));
                newsizeContent = int.Parse(content.Font.Size.Unit.ToString().Substring(0, 2));
            }

            //set the new font size to match the determined variable
            side_menu.Font.Size = FontUnit.Point(newsizeSide);
            title.Font.Size = FontUnit.Point(newsizeHead);
            content.Font.Size = FontUnit.Point(newsizeContent);
        }
    }
}
