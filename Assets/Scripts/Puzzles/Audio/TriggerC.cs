using UnityEngine;

public class TriggerC : MonoBehaviour
{
    [SerializeField] Audio Audio;


    private void OnTriggerEnter(Collider trigger){

        

    
        Audio.Play("C");
    
    }
}
