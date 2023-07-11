using UnityEngine;
using System.Collections.Generic;
using System;

public class NPCSeller : MonoBehaviour, IInteractable
{
    private Action<bool> onInteractEndBehaviour;

    [SerializeField]
    private ShopUi shop;

    [SerializeField]
    private GameManager gm;

    [SerializeField]
    private NPCItemList listItems;

    private List<Item> availableItems = new List<Item>();
    private List<SellingItemSlot> slotsCreated = new List<SellingItemSlot>();

    private void Awake()
    {
        foreach (var item in listItems.ItemsToSell)
        {
            availableItems.Add(item);
        }
    }

    public void OnInteractStart(Action<bool> extraBehaviour)
    {
        shop.gameObject.SetActive(true);
        SetBuyItems();
        onInteractEndBehaviour = extraBehaviour;
    }

    public void OnInteractEnd()
    {
        onInteractEndBehaviour?.Invoke(true);
    }

    public void SetBuyItems()
    {
        foreach (var slot in slotsCreated)
        {
            Destroy(slot.gameObject);
        }

        slotsCreated = new List<SellingItemSlot>();

        foreach (var item in availableItems)
        {
            var instance = shop.CreateItemSlot(item.itemName, item.itemPrice, item.icon, delegate { ItemBought(item); });
            if (!gm.GetCharacter().GetInventory().CanBuyItem(item.itemPrice))
                instance.SetAsBlocked();

            slotsCreated.Add(instance);
        }
    }

    private void ItemBought(Item itemBought)
    {
        if (gm.GetCharacter().GetInventory().CanBuyItem(itemBought.itemPrice))
        {
            gm.GetCharacter().GetInventory().SpendMoney(itemBought.itemPrice);
            gm.GetCharacter().GetInventory().AddItem(itemBought);
            shop.SetPlayerGold(gm.GetCharacter().GetInventory().GetPlayerGold().ToString("F0"));
            availableItems.Remove(itemBought);
            SetBuyItems();
        }        
    }

    public void SetSellItems()
    {
        foreach (var slot in slotsCreated)
        {
            Destroy(slot.gameObject);
        }

        slotsCreated = new List<SellingItemSlot>();

        foreach (var item in gm.GetCharacter().GetInventory().InventoryItems())
        {
            if (item != gm.GetCharacter().GetInventory().ItemEquiped())
            {
                var instance = shop.CreateItemSlot(item.itemName, (item.itemPrice / 2), item.icon, delegate { ItemSold(item); });                

                slotsCreated.Add(instance);
            }
        }
    }

    private void ItemSold(Item itemSold)
    {
        gm.GetCharacter().GetInventory().RemoveItem(itemSold);
        gm.GetCharacter().GetInventory().SpendMoney(-(itemSold.itemPrice / 2));
        shop.SetPlayerGold(gm.GetCharacter().GetInventory().GetPlayerGold().ToString("F0"));
        availableItems.Add(itemSold);
        SetSellItems();
    }
}