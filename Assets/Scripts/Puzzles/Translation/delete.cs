using UnityEngine;

public class TriggerTextReset : MonoBehaviour
{
    [SerializeField] Translation translation;


    private void OnTriggerEnter(Collider trigger){

        

    
        translation.Reset();
    
    }
}
