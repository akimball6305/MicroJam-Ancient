using UnityEngine;
using TMPro;

public class BoxmaniaTrigger : MonoBehaviour
{
    [SerializeField] Boxmania BoxmaniaPuzzle;
    [SerializeField] TextMeshProUGUI instructions;
private void OnTriggerEnter(Collider trigger){

    BoxmaniaPuzzle.canBeActive = true;
    instructions.gameObject.SetActive(true);
}

private void OnTriggerExit(Collider trigger){
    BoxmaniaPuzzle.canBeActive = false;
    instructions.gameObject.SetActive(false);
}

}
