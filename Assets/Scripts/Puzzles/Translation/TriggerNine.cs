using UnityEngine;

public class TriggerNine : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        Debug.Log(trigger.tag);

    
        translation.updateSolution("9");
    
    }
}
