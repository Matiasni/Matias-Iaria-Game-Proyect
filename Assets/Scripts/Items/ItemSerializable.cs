using UnityEngine;

[System.Serializable]
public class Item
{
    public Item(string itemName)
    {
        this.itemName = itemName;
    }

    public string itemId;
    public string itemName;
    public int itemPrice;
    public Sprite icon;
}