using UnityEngine;
using TMPro;
public class MazeTrigger : MonoBehaviour
{
    [SerializeField] Maze mazePuzzle;

    [SerializeField] TextMeshProUGUI instructions;
private void OnTriggerEnter(Collider trigger){

   
    mazePuzzle.canBeActive = true;
    
    if (mazePuzzle.didWin){
        return;
    }
    instructions.text = "Press E to interact then WASD to move";
    instructions.gameObject.SetActive(true);
  
}

private void OnTriggerExit(Collider trigger){
    mazePuzzle.canBeActive = false;
    instructions.gameObject.SetActive(false);
  
}

}
