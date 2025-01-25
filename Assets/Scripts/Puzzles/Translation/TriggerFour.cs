using UnityEngine;

public class TriggerFour : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("4");
    
    }
}
