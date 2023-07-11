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
        SetItems();
        onInteractEndBehaviour = extraBehaviour;
    }

    public void OnInteractEnd()
    {
        onInteractEndBehaviour?.Invoke(true);
    }

    private void SetItems()
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
            gm.GetCharacter().GetInventory().AddItem(itemBought);
            availableItems.Remove(itemBought);
            SetItems();
        }        
    }
}