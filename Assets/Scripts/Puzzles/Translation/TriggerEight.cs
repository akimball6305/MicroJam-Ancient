using UnityEngine;

public class TriggerEight : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("8");
    
    }
}
