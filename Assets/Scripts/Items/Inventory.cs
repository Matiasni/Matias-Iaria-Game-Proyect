using System.Collections.Generic;

public class Inventory
{
    public List<Item> items = new List<Item>();

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
}