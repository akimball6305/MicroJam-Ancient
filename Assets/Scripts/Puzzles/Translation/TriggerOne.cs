using UnityEngine;

public class TriggerOne : MonoBehaviour
{


    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        Debug.Log(trigger.tag);

    
        translation.updateSolution("1");
    
    }
}
