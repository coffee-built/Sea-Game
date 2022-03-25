using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> inventory = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _quantity)
    {
        var existingItem = inventory.FirstOrDefault(i => i.item == _item);

        if (existingItem != null) existingItem.AddAmount(_quantity); //TODO: Check this
        else inventory.Add(new InventorySlot(_item, _quantity));
    }

}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int quantity;
    public InventorySlot(ItemObject _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }
    public void AddAmount(int quantityToAdd)
    {
        quantity += quantityToAdd;
    }

}