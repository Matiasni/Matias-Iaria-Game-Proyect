using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellingItemSlot : MonoBehaviour
{
    [SerializeField]
    private Button slotButton;

    [SerializeField]
    private TextMeshProUGUI itemNameText;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TextMeshProUGUI itemPriceText;

    [SerializeField]
    private Material grayMaterial;

    public void SetItemName(string name)
    {
        itemNameText.text = name;
    }

    public void SetItemImage(Sprite sprite)
    {
        itemImage.sprite = sprite;
    }

    public void SetItemPrice(float price)
    {
        itemPriceText.text = price.ToString();
    }

    public void SetButtonAction(Action action)
    {
        slotButton.onClick.AddListener(delegate { action?.Invoke(); });
    }

    public void SetAsBlocked()
    {
        slotButton.interactable = false;
        itemNameText.color = Color.red;
        itemPriceText.color = Color.red;
        itemImage.material = grayMaterial;
    }
}