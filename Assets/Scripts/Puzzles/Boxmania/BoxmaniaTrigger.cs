using UnityEngine;
using TMPro;

public class BoxmaniaTrigger : MonoBehaviour
{
    [SerializeField] Boxmania BoxmaniaPuzzle;
    [SerializeField] TextMeshProUGUI instructions;
private void OnTriggerEnter(Collider trigger){

    BoxmaniaPuzzle.canBeActive = true;

    if(BoxmaniaPuzzle.didWin){
        return;
    }
    instructions.text = "Press E to interact then WASD to move";

    instructions.gameObject.SetActive(true);

}

private void OnTriggerExit(Collider trigger){
    BoxmaniaPuzzle.canBeActive = false;
    instructions.gameObject.SetActive(false);
}

}
