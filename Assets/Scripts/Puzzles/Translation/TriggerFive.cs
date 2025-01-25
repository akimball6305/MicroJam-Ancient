using UnityEngine;

public class TriggerFive : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("5");
    
    }
}
