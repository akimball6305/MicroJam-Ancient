using UnityEngine;

public class TriggerFive : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        Debug.Log(trigger.tag);

    
        translation.updateSolution("5");
    
    }
}
