using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class cartItemClass : IEquatable<cartItemClass>
{
	public int Quantity { get; set; }

    private int _proID;
    public int proID
    {
        get { return _proID; }
        set { _product = null; _proID = value; }
    }

    private Product _product = null;
    public Product Prod
    {
        get
        {
            if (_product == null)
            {
                _product = new Product(proID);
            }
        }
        return _product;
    }

    public string Description {
        get { return proDesc; }
    }

    public decimal Price {
        get { return proPrice; }
    }

    public decimal TotalPrice {
        get { return Price * Quantity; }
    }

    public cartItemClass(int _proID) 
    {
        this.proID = proID;
    }

    public bool Equals(cartItemClass item)
    {
        return item.proID == this.proID;
    }
}