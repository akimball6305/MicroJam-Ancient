using UnityEngine;

public class TriggerFour : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        Debug.Log(trigger.tag);

    
        translation.updateSolution("4");
    
    }
}
