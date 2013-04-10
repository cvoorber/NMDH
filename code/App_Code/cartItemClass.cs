using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class cartItemClass : IEquatable<cartItemClass>
{
    public int Quantity { get; set; }

    private int _productId;
    public int ProductId
    {
        get { return _productId; }
        set { _product = null; _productId = value; }
    }

    //creating products instances
    private giftshopClass _product = null;
    public giftshopClass Prod
    {
        get 
        {
            if (_product == null)
            {
                _product = new giftshopClass(ProductId);
            }
            return _product;
        }
    }

    public string Description
    {
        get { return Prod.Description; }
    }

    public decimal UnitPrice
    {
        get { return Prod.Price; }
    }

    //calculating the subtotal
    public decimal TotalPrice
    {
        get { return UnitPrice * Quantity; }
    }

    public cartItemClass(int productId)
    {
        this.ProductId = productId;
    }

    public bool Equals(cartItemClass item)
    {
        return item.ProductId == this.ProductId;
    }
}