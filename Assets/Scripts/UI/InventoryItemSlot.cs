using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    [SerializeField]
    private Button slotButton;

    [SerializeField]
    private TextMeshProUGUI itemNameText;

    [SerializeField]
    private Image itemImage;

    public void SetItemName(string name)
    {
        itemNameText.text = name;
    }

    public void SetItemImage(Sprite sprite)
    {
        itemImage.sprite = sprite;
        itemImage.gameObject.SetActive(true);
    }

    public void SetButtonAction(Action action)
    {
        slotButton.onClick.AddListener(delegate { action?.Invoke(); });
    }
}