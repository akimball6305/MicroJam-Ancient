using UnityEngine;

public class TriggerG : MonoBehaviour
{
    [SerializeField] Audio Audio;


    private void OnTriggerEnter(Collider trigger){

        

    
        Audio.Play("G");
    
    }
}
