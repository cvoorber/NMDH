using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

public class giftProdClass
{
    private static readonly string _connectionString;
    static giftProdClass()
    {
        _connectionString = WebConfigurationManager.ConnectionStrings["cvoorberConnectionString1"].ConnectionString;
    }

    public int proID;
    private int _proID
    {
        get { return _proID; }
        set { _proID = value; }
    }

    public string proName;
    private string _proName
    {
        get { return _proName; }
        set { _proName = value; }
    }

    public int proDesc;
    private int _proDesc
    {
        get { return _proDesc; }
        set { _proDesc = value; }
    }

    public int proPrice;
    private int _proPrice
    {
        get { return _proPrice; }
        set { _proPrice = value; }
    }
}