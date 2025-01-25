using UnityEngine;

public class TriggerSeven : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("7");
    
    }
}
