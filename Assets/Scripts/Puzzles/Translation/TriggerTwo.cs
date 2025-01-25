using UnityEngine;

public class TriggerTwo : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("2");
    
    }
}
