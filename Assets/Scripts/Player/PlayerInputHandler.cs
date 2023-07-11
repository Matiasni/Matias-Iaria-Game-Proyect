using System;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action OnOpenInventory;
    public event Action OnMainMenu;

    private void Update()
    {
        OpenInventory();
        OpenMainMenu();
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
            OnOpenInventory?.Invoke();
    }

    private void OpenMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnMainMenu?.Invoke();
    }
}