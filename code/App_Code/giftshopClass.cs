using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public class giftshopClass
{
    // publicly accessible giftshopClass properties(used by cartItemClass to determine what has been added/removed in the cart)
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    // constructor that queries the database and returns column values for a selected product based on id
    public giftshopClass(int Id)
    {
        // connection string
        string connString = WebConfigurationManager.ConnectionStrings["cvoorberConnectionString1"].ConnectionString;

        // query strings
        string idQuery = "SELECT p_id FROM ndmh_products WHERE p_id='" + Id + "'";
        string descQuery = "SELECT p_name FROM ndmh_products WHERE p_id='" + Id + "'";
        string priceQuery = "SELECT p_price FROM ndmh_products WHERE p_id='" + Id + "'";

        // sql connection object and commands
        SqlConnection SqlConn = new SqlConnection(connString);
        SqlCommand IdComm = new SqlCommand(idQuery, SqlConn);
        SqlCommand DescComm = new SqlCommand(descQuery, SqlConn);
        SqlCommand PriceComm = new SqlCommand(priceQuery, SqlConn);

        //execution of the commands on the connection to return the values
        SqlConn.Open();
        this.Id = Convert.ToInt32(IdComm.ExecuteScalar());
        this.Description = Convert.ToString(DescComm.ExecuteScalar());
        this.Price = Convert.ToDecimal(PriceComm.ExecuteScalar());
    }

}