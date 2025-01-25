using UnityEngine;

public class BoxmaniaTrigger : MonoBehaviour
{
    [SerializeField] Boxmania BoxmaniaPuzzle;
private void OnTriggerEnter(Collider trigger){

    Debug.Log(trigger.tag);

   
    BoxmaniaPuzzle.canBeActive = true;
  
}

private void OnTriggerExit(Collider trigger){

 

    
    BoxmaniaPuzzle.canBeActive = false;
    
}

}
