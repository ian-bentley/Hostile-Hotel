using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    List<ItemType> _inventory;
    int _heldItemSlotNum;

    public List<ItemType> Inventory
    {
        get => _inventory;
        set => _inventory = value;
    }

    public int HeldItemSlotNum
    {
        get => _heldItemSlotNum;
        set => _heldItemSlotNum = value;
    }

    public PlayerData(List<ItemType> inventory, int heldItemSlotNum)
    {
        Inventory = new List<ItemType>();

        foreach(ItemType it in inventory)
        {
            Inventory.Add(it);
        }
        
        HeldItemSlotNum = heldItemSlotNum;
    }
}
