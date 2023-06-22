using CatCity;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    /// <summary>
    /// Current player inventory file 
    /// </summary>
    public Inventory PlayerInventory; 
    //{ get; private set; }

    /// <summary>
    /// Set a inventory player
    /// </summary>
    /// <param name="inventory">inventory file to load</param>
    public void SetInventory(Inventory inventory)
    {
        PlayerInventory = inventory;
    }

    /// <summary>
    /// Set a inventory player
    /// </summary>
    public void SetInventory()
    {
        PlayerInventory = new();
    }

    #region Add item
    /// <summary>
    /// Add a new item to inventory
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        byte itemFound = 0;

        foreach(Item itemObject in PlayerInventory.items)
        {
            if(itemObject.name == item.name)
            {
                itemObject.quant += item.quant;
                itemFound = 1;
                break;
            }
        }

        if(itemFound != 1)
        {
            Item itemToAdd = new()
            {
                name = item.name,
                quant = item.quant,
                sprite = item.sprite
            };

            PlayerInventory.items.Add(itemToAdd);
        }
    }

    /// <summary>
    /// Add a new item to inventory
    /// </summary>
    /// <param name="_name">name of item</param>
    /// <param name="_sprite">sprite of item</param>
    public void AddItem(string _name, Sprite _sprite)
    {
        Item item = new()
        {
            name = _name,
            sprite = _sprite,
            quant = 1
        };

        AddItem(item);
    }

    /// <summary>
    /// Add a new item to inventory
    /// </summary>
    /// <param name="_name">name of item</param>
    /// <param name="_sprite">sprite of item</param>
    /// <param name="_quant">quant of items to add</param>
    public void AddItem(string _name, Sprite _sprite, float _quant)
    {
        Item item = new()
        {
            name = _name,
            sprite = _sprite,
            quant = _quant
        };

        AddItem(item);
    }
    #endregion

    #region Remove Item
    /// <summary>
    /// Remove a item of player inventory
    /// </summary>
    public void RemoveItem(Item item)
    {
        var theItem = PlayerInventory.items.FirstOrDefault(x => x.name == item.name);
        if(theItem != null)
        {
            theItem.quant -= item.quant;
            if(theItem.quant <= 0)
            {
                PlayerInventory.items.Remove(theItem);
            }
        }
    }

    /// <summary>
    /// Remove a item of player inventory
    /// </summary>
    /// <param name="_name">name of object</param>
    public void RemoveItem(string _name)
    {
        Item item = new()
        {
            name = _name
        };

        RemoveItem(item);
    }

    /// <summary>
    /// Remove a item of player inventory
    /// </summary>
    /// <param name="_name">name of object</param>
    /// <param name="_quant">quant to remove</param>
    public void RemoveItem(string _name, double _quant)
    {
        Item item = new()
        {
            name = _name,
            quant = _quant
        };

        RemoveItem(item);
    }
    #endregion

    #region Verify Item
    /// <summary>
    /// Verify if a item exists in player inventory
    /// </summary>
    /// <param name="item">Item to compare</param>
    /// <returns>true if the item exists</returns>
    public bool VerifyItem(Item item)
    {
        foreach(Item itemObject in PlayerInventory.items)
        {
            if(item.name == itemObject.name)
            {
                if(item.quant <= itemObject.quant)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Verify if a item exists in player inventory
    /// </summary>
    /// <param name="_name">name of object</param>
    /// <returns>true if the item exists</returns>
    public bool VerifyItem(string _name)
    {
        Item item = new()
        {
            name = _name
        };

        foreach(Item itemObject in PlayerInventory.items)
        {
            if(item.name == itemObject.name)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Verify if a item exists in player inventory
    /// </summary>
    /// <param name="_name">name of object</param>
    /// <param name="_quant">quant of objects to compare</param>
    /// <returns>true if the item exists</returns>
    public bool VerifyItem(string _name, double _quant)
    {
        Item item = new()
        {
            name = _name,
            quant = _quant
        };

        foreach(Item itemObject in PlayerInventory.items)
        {
            if(item.name == itemObject.name)
            {
                if(item.quant <= itemObject.quant)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }
    #endregion

    //////////////////////////////////////////////

    public void AddItem()
    {
        AddItem(itemToCompare);
    }
    public void RemoveItem()
    {
        RemoveItem(itemToCompare);
    }

    public Item itemToCompare;

}