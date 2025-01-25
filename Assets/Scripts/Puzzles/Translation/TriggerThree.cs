using UnityEngine;

public class TriggerThree : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        Debug.Log(trigger.tag);

    
        translation.updateSolution("3");
    
    }
}
