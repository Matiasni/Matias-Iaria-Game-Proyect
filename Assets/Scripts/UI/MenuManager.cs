using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInputHandler playerInputs;

    [SerializeField]
    private InventoryUI inventoryUi;

    [SerializeField]
    private GameObject gameExit;

    void Start()
    {
        playerInputs.OnOpenInventory += OpenInventory;
        playerInputs.OnMainMenu += OpenMainMenu;
    }

    void OpenInventory()
    {
        if (!gameExit.activeInHierarchy)
        {
            inventoryUi.gameObject.SetActive(true);
            inventoryUi.InventoryOpen();
        }
    }

    void OpenMainMenu()
    {
        if (inventoryUi.gameObject.activeInHierarchy)
            inventoryUi.gameObject.SetActive(false);
        else
        {
            if (!gameExit.activeInHierarchy)
                gameExit.SetActive(true);
            else
                gameExit.SetActive(false);
        }
    }
}