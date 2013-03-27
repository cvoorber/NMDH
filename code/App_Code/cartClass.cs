using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class cartClass
{
    #region Properties  
      
    public List<cartItemClass> Items { get; private set; }  
     
    #endregion  
 
    #region Singleton Implementation  
    // Readonly properties can only be set in initialization or in a constructor  
    public static readonly cartClass Instance;  
  
    // The static constructor is called as soon as the class is loaded into memory  
    static cartClass() {  
        // If the cart is not in the session, create one and put it there  
        // Otherwise, get it from the session  
        if (HttpContext.Current.Session["ShoppingCart"] == null) {  
            Instance = new cartClass();  
            Instance.Items = new List<cartItemClass>();
            HttpContext.Current.Session["ShoppingCart"] = Instance;  
        } else {
            Instance = (cartClass)HttpContext.Current.Session["ShoppingCart"];  
        }  
    }  
  
    // A protected constructor ensures that an object can't be created from outside  
    protected cartClass() { }  
 
    #endregion  
 
    #region Item Modification Methods  
    /** 
     * AddItem() - Adds an item to the shopping  
     */  
    public void AddItem(int productId) {  
        // Create a new item to add to the cart  
        cartItemClass newItem = new cartItemClass(productId);  
  
        // If this item already exists in our list of items, increase the quantity  
        // Otherwise, add the new item to the list  
        if (Items.Contains(newItem)) {  
            foreach (cartItemClass item in Items) {  
                if (item.Equals(newItem)) {  
                    item.Quantity++;  
                    return;  
                }  
            }  
        } else {  
            newItem.Quantity = 1;  
            Items.Add(newItem);  
        }  
    }  
  
    /** 
     * SetItemQuantity() - Changes the quantity of an item in the cart 
     */  
    public void SetItemQuantity(int productId, int quantity) {  
        // If we are setting the quantity to 0, remove the item entirely  
        if (quantity == 0) {  
            RemoveItem(productId);  
            return;  
        }  
  
        // Find the item and update the quantity  
        cartItemClass updatedItem = new cartItemClass(productId);  
  
        foreach (cartItemClass item in Items) {  
            if (item.Equals(updatedItem)) {  
                item.Quantity = quantity;  
                return;  
            }  
        }  
    }  
  
    /** 
     * RemoveItem() - Removes an item from the shopping cart 
     */  
    public void RemoveItem(int productId) {  
        cartItemClass removedItem = new cartItemClass(productId);  
        Items.Remove(removedItem);  
    }  
    #endregion  
 
    #region Reporting Methods  
    /** 
     * GetSubTotal() - returns the total price of all of the items 
     *                 before tax, shipping, etc. 
     */  
    public decimal GetSubTotal() {  
        decimal subTotal = 0;  
        foreach (cartItemClass item in Items)  
            subTotal += item.TotalPrice;  
  
        return subTotal;  
    }  
    #endregion  
}