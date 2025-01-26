using System;
using Mono.Cecil.Cil;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] Boxmania boxmaniaPuzzle;

    [SerializeField] Maze mazePuzzle;

    [SerializeField] Audio audioPuzzle;

    [SerializeField] Translation translationPuzzle;

    [SerializeField] PlatformMovement platform;


    // Update is called once per frame

    void Update()
    {

        platform.canRise = boxmaniaPuzzle.didWin && mazePuzzle.didWin && audioPuzzle.didWin && translationPuzzle.didWin;
        
    }
}
