using UnityEngine;

public class MazeTrigger : MonoBehaviour
{
    [SerializeField] Maze mazePuzzle;
private void OnTriggerEnter(Collider trigger){

   
    mazePuzzle.canBeActive = true;
  
}

private void OnTriggerExit(Collider trigger){
    mazePuzzle.canBeActive = false;
    
}

}
