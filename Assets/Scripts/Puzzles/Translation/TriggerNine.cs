using UnityEngine;

public class TriggerNine : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("9");
    
    }
}
