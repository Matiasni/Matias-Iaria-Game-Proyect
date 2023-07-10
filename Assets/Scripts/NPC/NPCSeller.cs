using UnityEngine;

public class NPCSeller : MonoBehaviour, IInteractable
{
    public GameObject shopUI;

    public void OnInteractStart()
    {
        Debug.Log("HI");
    }
    public void OnInteractEnd()
    {

    }
}