using UnityEngine;

public class TriggerEight : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        Debug.Log(trigger.tag);

    
        translation.updateSolution("8");
    
    }
}
