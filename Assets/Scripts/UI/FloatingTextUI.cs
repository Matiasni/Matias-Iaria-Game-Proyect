using UnityEngine;

public class FloatingTextUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameUi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!inGameUi.activeInHierarchy)
                inGameUi.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!inGameUi.activeInHierarchy)
                inGameUi.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (inGameUi.activeInHierarchy)
                inGameUi.SetActive(false);
        }
    }
}