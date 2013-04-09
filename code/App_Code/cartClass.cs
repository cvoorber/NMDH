using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class cartClass
{
    public List<cartItemClass> Items { get; private set; }

    public static readonly cartClass Instance;

    // The static constructor for the Cart
    public static cartClass GetShoppingCart()
    {
        // If a cart doesn't exist in the Session, create one, otherwise return the current one
        if (HttpContext.Current.Session["ShoppingCart"] == null)
        {
            cartClass cart = new cartClass();
            cart.Items = new List<cartItemClass>();
            HttpContext.Current.Session["ShoppingCart"] = cart;
        }

        return (cartClass)HttpContext.Current.Session["ShoppingCart"];
    }

    // Method for adding items to the cart
    public void AddItem(int productId)
    {
        cartItemClass newItem = new cartItemClass(productId);

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

    // Method for updating item quantity
    public void SetItemQuantity(int productId, int quantity)
    {
        if (quantity == 0)
        {
            RemoveItem(productId);
            return;
        }

        cartItemClass updatedItem = new cartItemClass(productId);

        foreach (cartItemClass item in Items)
        {
            if (item.Equals(updatedItem))
            {
                item.Quantity = quantity;
                return;
            }
        }
    }

    // Method for removing all quantities of an item
    public void RemoveItem(int productId)
    {
        cartItemClass removedItem = new cartItemClass(productId);
        Items.Remove(removedItem);
    }

    // function to return details for Order Email
    public string GetDetails()
    {
        string desc = "";
        foreach (cartItemClass item in Items)
        {
            desc += item.Description + " x [" + item.Quantity + "] ~ ";
        }
        return desc;
    }

    // function to return the subTotal of items
    public decimal GetSubTotal()
    {
        decimal subTotal = 0;
        foreach (cartItemClass item in Items)
        {
            subTotal += item.TotalPrice;
        }
        return subTotal;
    }
}