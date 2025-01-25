using UnityEngine;

public class TriggerSix : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("6");
    
    }
}
