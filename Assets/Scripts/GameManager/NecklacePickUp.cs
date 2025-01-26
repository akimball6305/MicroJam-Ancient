using UnityEngine;

public class NecklacePickUp : MonoBehaviour
{
    [SerializeField] GameObject necklace;
    
    [SerializeField] GameManager gameManager;
    public bool hasNecklace = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManager.hasWon)
        {
            Destroy(gameObject);
            hasNecklace = true;
           
        }
    }
}
