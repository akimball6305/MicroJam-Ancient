using UnityEngine;

public class TriggerTheme : MonoBehaviour
{
    [SerializeField] Audio Audio;


    private void OnTriggerEnter(Collider trigger){

        

    
        Audio.Play("Theme",false);
    
    }
}
