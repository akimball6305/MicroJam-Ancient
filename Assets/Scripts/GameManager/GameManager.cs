using System;
using Mono.Cecil.Cil;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    [SerializeField] Boxmania boxmaniaPuzzle;

    [SerializeField] Maze mazePuzzle;

    [SerializeField] Audio audioPuzzle;

    [SerializeField] Translation translationPuzzle;

    [SerializeField] PlatformMovement platform;

    [SerializeField] TextMeshProUGUI text;
    // Update is called once per frame

    void Update()
    {

        platform.canRise = boxmaniaPuzzle.didWin && mazePuzzle.didWin && audioPuzzle.didWin && translationPuzzle.didWin;

        int total = 0;

        if(boxmaniaPuzzle.didWin){
            total += 1;
        }

        if(mazePuzzle.didWin){

            total += 1;
        }

        if(audioPuzzle.didWin){
            total += 1;
        }

        if(translationPuzzle.didWin){
            total += 1;
        }
        text.text = "Progress: " + total.ToString() + "/4";
    }
}
