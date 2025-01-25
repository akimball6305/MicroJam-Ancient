using UnityEngine;

public class TriggerOne : MonoBehaviour
{


    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("1");
    
    }
}
