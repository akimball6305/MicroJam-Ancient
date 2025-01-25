using UnityEngine;
using System;
using TMPro;
public class Translation : MonoBehaviour
{

    [SerializeField] TextMeshPro textBox;

    private string[] nums = {"1","2","3","4","5","6","7","8","9"};

    private String[] choice =  {"1","2","3","4","5","6","7","8","9"};
    
    public bool hasWon = false;
    private string solution = "";
    private string correctSolution = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox.text = "";
        System.Random random = new System.Random();
        
        for(int c = 0; c < 9; c++){

            choice[c] = nums[random.Next(0,9)];
            textBox.text += choice[c];
            correctSolution += choice[c];
            
        }
        Debug.Log(correctSolution);
    }

   public void updateSolution(String num){

        if(hasWon){
            return;
        }

        solution += num;
        Debug.Log(solution);
        if (solution.Length == correctSolution.Length){
            if (solution == correctSolution){
                hasWon = true;
                Debug.Log("WINNER!");
            }
            else{
                solution = "";
            }

        }

    }

}
