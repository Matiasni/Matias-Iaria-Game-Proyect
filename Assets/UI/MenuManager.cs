using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInputHandler playerInputs;

    [SerializeField]
    private GameObject inventoryUi;

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
            inventoryUi.SetActive(true);
    }

    void OpenMainMenu()
    {
        if (inventoryUi.activeInHierarchy)
            inventoryUi.SetActive(false);
        else
        {
            if (!gameExit.activeInHierarchy)
                gameExit.SetActive(true);
            else
                gameExit.SetActive(false);
        }
    }
}