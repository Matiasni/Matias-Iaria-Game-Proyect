using System.Collections.Generic;

public class Inventory
{
    private List<Item> items = new List<Item>();
    private float money = 5000;

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void RemoveItem()
    {
        if (items.Count <= 0)
            return;

        items.RemoveAt(items.Count - 1);
    }

    public Item GetItem(int index)
    {       
        return items[index];
    }

    public void SpendMoney(float price)
    {
        money -= price;
    }

    public bool CanBuyItem(float price)
    {
        if (price > money)
            return false;

        return true;
    }
}