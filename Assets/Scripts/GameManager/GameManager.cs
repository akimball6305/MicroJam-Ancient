using System;
using Mono.Cecil.Cil;
using UnityEngine;
using TMPro;
using NUnit.Framework;
public class GameManager : MonoBehaviour
{

    [SerializeField] Boxmania boxmaniaPuzzle;

    [SerializeField] Maze mazePuzzle;

    [SerializeField] Audio audioPuzzle;

    [SerializeField] Translation translationPuzzle;

    [SerializeField] PlatformMovement platform;

    [SerializeField] TextMeshProUGUI text;
    // Update is called once per frame
    private float timer = 0.0f;

    public string timerText(){


        int mins = (int) (timer/60);
        int seconds = (int) timer % 60;
        int dec = (int) (100 * (timer - Math.Truncate(timer)));

        return string.Format("{0:D2}:{1:D2}:{2:D2}", mins, seconds, dec);

    }

    
    public bool hasWon = false;

    void Update()
    {
        int total = 0;


        hasWon = boxmaniaPuzzle.didWin && mazePuzzle.didWin && audioPuzzle.didWin && translationPuzzle.didWin;

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
        if(!hasWon){
            text.text = "Progress: " + total.ToString() + "/4";
        }
        else{
            text.text = "Grab the necklace and escape!";
        }
        

        if(total != 4 && platform.isLowered){
            timer += Time.deltaTime;
            Debug.Log(timerText());
        }
    }
}
