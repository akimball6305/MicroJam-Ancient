using UnityEngine;

public class TriggerThree : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.updateSolution("3");
    
    }
}
