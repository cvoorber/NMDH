﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

public partial class SubMaster1 : System.Web.UI.MasterPage
{
    private string _url = "";
    public string pp_Url
    {
        get { return _url; }
        set { _url = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _loadMenu();
        side_menu.MenuItemClick += sideMenu_Click;
        if (!Page.IsPostBack)
        {
            string xmlPath = Request.PhysicalApplicationPath + @"XMLSitemap.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNodeList titleList = doc.GetElementsByTagName("url");
            string pagename = "";
            for (var i = 0; i < titleList.Count; i++)
            {
                if(titleList[i].ChildNodes[0].FirstChild.Value == pp_Url)
                {
                    pagename = titleList[i].ChildNodes[2].FirstChild.Value.ToString();
                    i = 99999;
                }
            }
            navClass menuObj = new navClass();
            rpt_content.DataSource = menuObj.getPageByName(pagename);
            rpt_content.DataBind();
        }
    }

    protected void sideMenu_Click(object sender, MenuEventArgs e)
    {
        if (e.Item.Value != null)
        {
            navClass menuObj = new navClass();
            rpt_content.DataSource = menuObj.getPageByName(e.Item.Value);
            rpt_content.DataBind();
        }
    }

    protected void _loadMenu()
    {
        side_menu.Items.Clear();

        string xmlPath = Request.PhysicalApplicationPath + @"XMLSitemap.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlPath);
        XmlNodeList titleList = doc.GetElementsByTagName("url");
        string urlparent = "";
        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[0].FirstChild.Value == pp_Url)
            {
                urlparent = node.ChildNodes[3].FirstChild.Value.ToString();
            }
        }

        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[3].FirstChild.Value == urlparent)
            {
                MenuItem output = new MenuItem();
                output.Text = node.ChildNodes[2].FirstChild.Value;
                output.Target = node.ChildNodes[0].FirstChild.Value.ToString();
                side_menu.Items.Add(output);
            }

        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ((maintemplate)this.Master).upFont += new EventHandler(fontInc);
        ((maintemplate)this.Master).downFont += new EventHandler(fontDec);
    }

    protected void fontInc(object sender, EventArgs e)
    {
        Label title = new Label();
        Label content = new Label();
        foreach (RepeaterItem ri in rpt_content.Items)
        {
            title = (Label)ri.FindControl("lbltitle");
            content = (Label)ri.FindControl("lblcontent");
        }
        int newsizeSide = int.Parse(side_menu.Font.Size.Unit.ToString().Substring(0, 2)) + 2;
        int newsizeHead = int.Parse(title.Font.Size.Unit.ToString().Substring(0, 2)) + 2;
        int newsizeContent = int.Parse(content.Font.Size.Unit.ToString().Substring(0, 2)) + 2;

        if (newsizeSide > 16)
        {
            newsizeSide = int.Parse(side_menu.Font.Size.Unit.ToString().Substring(0, 2));
            newsizeHead = int.Parse(title.Font.Size.Unit.ToString().Substring(0, 2));
            newsizeContent = int.Parse(content.Font.Size.Unit.ToString().Substring(0, 2));
        }
        side_menu.Font.Size = FontUnit.Point(newsizeSide);
        title.Font.Size = FontUnit.Point(newsizeHead);
        content.Font.Size = FontUnit.Point(newsizeContent);
    }

    protected void fontDec(object sender, EventArgs e)
    {
        Label title = new Label();
        Label content = new Label();
        foreach (RepeaterItem ri in rpt_content.Items)
        {
            title = (Label)ri.FindControl("lbltitle");
            content = (Label)ri.FindControl("lblcontent");
        }

        int newsizeSide = int.Parse(side_menu.Font.Size.Unit.ToString().Substring(0, 2)) - 2;
        int newsizeHead = int.Parse(title.Font.Size.Unit.ToString().Substring(0, 2)) - 2;
        int newsizeContent = int.Parse(content.Font.Size.Unit.ToString().Substring(0, 2)) - 2;

        if (newsizeSide < 10)
        {
            newsizeSide = int.Parse(side_menu.Font.Size.Unit.ToString().Substring(0, 2));
            newsizeHead = int.Parse(title.Font.Size.Unit.ToString().Substring(0, 2));
            newsizeContent = int.Parse(content.Font.Size.Unit.ToString().Substring(0, 2));
        }
        side_menu.Font.Size = FontUnit.Point(newsizeSide);
        title.Font.Size = FontUnit.Point(newsizeHead);
        content.Font.Size = FontUnit.Point(newsizeContent);
    }
}
