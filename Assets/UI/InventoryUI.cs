using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InventoryItemSlot inventorySlot;
    [SerializeField]
    private InventoryItemSlot currentEquippedItem;

    //void Start()
    //{
    //    addSarasa.onClick.AddListener(delegate { gm.GetCharacter().GetInventory().AddItem(new Item("Sarasa ")); UpdateUI(); });

    //    addPotion.onClick.AddListener(delegate { gm.GetCharacter().GetInventory().AddItem(new Item("Potion ")); UpdateUI(); });

    //    removeItem.onClick.AddListener(delegate { gm.GetCharacter().GetInventory().RemoveItem(); UpdateUI(); });
    //}

    //string textFull;
    //void UpdateUI()
    //{
    //    textFull = "";

    //    Debug.Log(gm.GetCharacter());
    //    if (gm.GetCharacter().GetInventory().items.Count > 0)
    //    {
    //        foreach (var item in gm.GetCharacter().GetInventory().items)
    //        {
    //            textFull += item.itemName;
    //        }
    //    }
        

    //    text.text = textFull;
    //}

}