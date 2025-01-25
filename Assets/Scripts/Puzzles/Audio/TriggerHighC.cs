using UnityEngine;

public class TriggerHighC : MonoBehaviour
{
    [SerializeField] Audio Audio;


    private void OnTriggerEnter(Collider trigger){

        

    
        Audio.Play("HighC");
    
    }
}
