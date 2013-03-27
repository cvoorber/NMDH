using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class cartClass
{
    public List<cartItemClass> Items { get; private set; }
    public static readonly cartClass Instance;

	static cartClass()
	{
        if (HttpContext.Current.Session["ShoppingCart"] == null)
        {
            Instance = new cartClass();
            Instance.Items = new List<cartItemClass>();
            HttpContext.Current.Session["ShoppingCart"] = Instance;
        }
        else
        {
            Instance = (cartClass)HttpContext.Current.Session["ShoppingCart"];
        }
	}

    protected cartClass()
    {

    }

    public void AddItem(int proID)
    {
        cartItemClass newItem = new cartItemClass(proID);

        if (Items.Contains(newItem))
        {
            foreach (cartItemClass item in Items)
            {
                if (item.Equals(newItem))
                {
                    item.Quantity++;
                    return;
                }
            }
        }
        else
        {
            newItem.Quantity = 1;
            Items.Add(newItem);
        }
    }


    public void setItemQuantity(int proID, int quantity)
    {
        if (quantity == 0)
        {
            RemoveItem(proID);
            return;
        }

        cartItemClass updatedItem = new cartItemClass(proID);

        foreach (cartItemClass item in Items)
        {
            if (item.Equals(updatedItem))
            {
                item.Quantity = quantity;
                return;
            }
        }
    }


    public void RemoveItem(int proID)
    {
        cartItemClass removedItem = new cartItemClass(proID);
        Items.Remove(removedItem);
    }


    public decimal getSubtotal()
    {
        decimal subTotal = 0;
        foreach (cartItemClass item in Items)
            subTotal += item.TotalPrice;

        return subTotal;
    }
}