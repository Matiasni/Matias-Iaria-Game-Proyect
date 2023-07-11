using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;
    [SerializeField]
    private InventoryItemSlot inventorySlot;
    [SerializeField]
    private InventoryItemSlot currentEquippedItem;
    [SerializeField]
    private Transform container;

    private List<InventoryItemSlot> slotsCreated = new List<InventoryItemSlot>();

    public void InventoryOpen()
    {
        var playerInventory = gm.GetCharacter().GetInventory();

        foreach (var slot in slotsCreated)
        {
            Destroy(slot.gameObject);
        }

        slotsCreated = new List<InventoryItemSlot>();

        if (playerInventory.InventoryItems().Count <= 0)
            return;

        foreach (var item in playerInventory.InventoryItems())
        {
            if (item != playerInventory.ItemEquiped())
            {
                var instance = CreateItemSlot(item.itemName, item.icon, delegate { EquipItemFunction(item); });
                slotsCreated.Add(instance);
            }
            else
            {
                currentEquippedItem.SetItemName(item.itemName);
                currentEquippedItem.SetItemImage(item.icon);
            }
        }
    }

    public InventoryItemSlot CreateItemSlot(string name, Sprite sprite, Action action)
    {
        var instance = Instantiate(inventorySlot, container);
        instance.SetItemName(name);
        instance.SetItemImage(sprite);
        instance.SetButtonAction(action);

        return instance;
    }

    public void EquipItemFunction(Item item)
    {
        gm.GetCharacter().GetInventory().EquipItem(item);
        InventoryOpen();
    }
}