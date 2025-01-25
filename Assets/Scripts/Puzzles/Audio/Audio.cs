using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public bool didWin = false;
    private bool playTheme = false;
    private int themeIndex = 0;

    [SerializeField] AudioSource c;
    [SerializeField] AudioSource e;
    [SerializeField] AudioSource g;
    [SerializeField] AudioSource highC;
    [SerializeField] AudioSource right;
    [SerializeField] AudioSource wrong;

    private System.Random random = new System.Random();

    private List<string> playPitches = new List<string>();
    private string[] actualPitches = new string[] { "C", "E", "G", "HighC" };
    private List<string> solutionPitches = new List<string>();

    private string debugString = "";
    void Start(){
        for (int i = 0; i < 5; i++){

            int randomIndex = random.Next(actualPitches.Length);
            string pitch = actualPitches[randomIndex];
            playPitches.Add(pitch);
            debugString += pitch;
        }
        Debug.Log(debugString);
    }

    private bool IsPlaying(){
        return c.isPlaying || e.isPlaying || g.isPlaying || highC.isPlaying;
    }

    public void Play(string note, bool shouldAdd = true){
        if (IsPlaying() || didWin || (playTheme && shouldAdd)){
            return;
        }

        switch (note){
            case "C":
                
                c.Play();
                break;
            case "E":
                e.Play();
                break;
            case "G":
                g.Play();
                break;
            case "HighC":
                highC.Play();
                break;
            case "Theme":
                playTheme = true;
                Debug.Log(playTheme);
                break;
        }

        if (shouldAdd){
            solutionPitches.Add(note);

            if (solutionPitches.Count != playPitches.Count){
                return;
            }

            if (solutionPitches.SequenceEqual(playPitches)){
                didWin = true;
                right.Play();
            }
            else{
                wrong.Play();
            }
        }
    }
    void Update()
    {
        if (didWin){
            return;
        }

        if (playTheme){
            
            if (IsPlaying()){
            
                return;
            }
            
    

            Play(playPitches[themeIndex], false);
            themeIndex++;

            if (themeIndex >= playPitches.Count){
                themeIndex = 0;
                playTheme = false;
            }
        }
    }
}
