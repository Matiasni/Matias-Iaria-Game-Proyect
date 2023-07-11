using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI npcText;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private Button sellButton;
    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private SellingItemSlot slotItem;
    [SerializeField]
    private GameObject container;

    void Start()
    {
        SetBuy();
    }

    public void SetBuy()
    {
        buyButton.interactable = false;
        sellButton.interactable = true;
        titleText.text = "Buy Items";
    }

    public void SetSell()
    {
        buyButton.interactable = true;
        sellButton.interactable = false;
        titleText.text = "Sell Items";
    }

    public SellingItemSlot CreateItemSlot(string name, float price, Sprite sprite, Action action)
    {
        var instance = Instantiate(slotItem, container.transform);
        instance.SetItemName(name);
        instance.SetItemPrice(price);
        instance.SetItemImage(sprite);
        instance.SetButtonAction(action);

        return instance;
    }
}