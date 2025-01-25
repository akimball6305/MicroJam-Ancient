using UnityEngine;

public class TriggerE : MonoBehaviour
{
    [SerializeField] Audio Audio;


    private void OnTriggerEnter(Collider trigger){

        

    
        Audio.Play("E");
    
    }
}
