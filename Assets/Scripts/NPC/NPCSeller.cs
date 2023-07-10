using UnityEngine;

public class NPCSeller : MonoBehaviour
{
    public GameObject shopUI;

    private bool canInteract = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
            Debug.Log("HI");
        }
    }

    private void OpenShop()
    {
        shopUI.SetActive(true);
    }
}