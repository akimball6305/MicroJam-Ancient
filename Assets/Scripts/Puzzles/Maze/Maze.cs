
using UnityEngine;
using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class Maze : MonoBehaviour
{
    public bool didWin = false;
    public bool canBeActive = false;
    public bool isActive = false;

    [SerializeField] GameObject box;


    private GameObject na;
    private GameObject death;

    private GameObject wall;
    private GameObject[] boxArray;
    private GameObject[][] pattern;


    private Vector3 boxPosition = new Vector3(0.0f, 0.0f, 0.0f);
    public bool Press(string key)
    {
        int xIndex = 0;
        int yIndex = 0;
        bool didMove = false;

        if (key == "UP" || key == "LEFT" || key == "DOWN" || key == "RIGHT")
        {
            foreach (var row in pattern)
            {
                xIndex = 0;
                foreach (var cell in row)
                {
                    if (key == "UP" && yIndex != 0 && (pattern[yIndex - 1][xIndex] == na || pattern[yIndex - 1][xIndex] == death))
                    {
                        if (boxArray.Contains(cell))
                        {
                            if (pattern[yIndex - 1][xIndex] == death)
                            {
                                Reset();
                                return false;
                            }
                            pattern[yIndex - 1][xIndex] = pattern[yIndex][xIndex];
                            pattern[yIndex][xIndex] = na;
                            UpdateBoxPosition(cell, xIndex, yIndex - 1);
                            didMove = true;
                        }
                    }
                    else if (key == "LEFT" && xIndex != 0 && (pattern[yIndex][xIndex - 1] == na || pattern[yIndex][xIndex - 1] == death))
                    {
                        if (boxArray.Contains(cell))
                        {
                            if (pattern[yIndex][xIndex - 1] == death)
                            {
                                Reset();
                                return false;
                            }
                            pattern[yIndex][xIndex - 1] = pattern[yIndex][xIndex];
                            pattern[yIndex][xIndex] = na;
                            UpdateBoxPosition(cell, xIndex - 1, yIndex);
                            didMove = true;
                        }
                    }
                    xIndex++;
                }
                yIndex++;
            }

            for (int yIndex2 = 9; yIndex2 >= 0; yIndex2--)
            {
                for (int xIndex2 = 9; xIndex2 >= 0; xIndex2--)
                {
                    if (key == "DOWN" && yIndex2 != 9 && (pattern[yIndex2 + 1][xIndex2] == na || pattern[yIndex2 + 1][xIndex2] == death))
                    {
                        if (boxArray.Contains(pattern[yIndex2][xIndex2]))
                        {

                            if (pattern[yIndex2 + 1][xIndex2] == death)
                            {
                                Reset();
                                return false;
                            }
                            pattern[yIndex2 + 1][xIndex2] = pattern[yIndex2][xIndex2];
                            UpdateBoxPosition(pattern[yIndex2][xIndex2], xIndex2, yIndex2 + 1);
                            pattern[yIndex2][xIndex2] = na;

                            didMove = true;
                        }
                    }
                    else if (key == "RIGHT" && xIndex2 != 9 && (pattern[yIndex2][xIndex2 + 1] == na || pattern[yIndex2][xIndex2 + 1] == death))
                    {

                        if (boxArray.Contains(pattern[yIndex2][xIndex2]))
                        {

                            if (pattern[yIndex2][xIndex2 + 1] == death)
                            {
                                Reset();
                                return false;
                            }
                            pattern[yIndex2][xIndex2 + 1] = pattern[yIndex2][xIndex2];
                            UpdateBoxPosition(pattern[yIndex2][xIndex2], xIndex2 + 1, yIndex2);
                            pattern[yIndex2][xIndex2] = na;



                            didMove = true;
                        }
                    }
                }
            }
        }

        if (didMove)
        {

            didWin = boxArray.Contains(pattern[9][9]);
            isActive = !didWin;

        }


        return didMove;
    }

    private void UpdateBoxPosition(GameObject box, int xIndex, int yIndex)
    {


        Vector3 newPosition = new Vector3(xIndex + 0.0f, this.box.transform.localPosition.y, (yIndex) + 0.0f);
        if (box == this.box)
        {

            boxPosition = newPosition;
        }

    }


    void OnInteract(InputValue value)
    {

        if (didWin || !canBeActive)
        {
            isActive = false;
            return;
        }
        if (!value.isPressed)
        {

            isActive = !isActive;

        }


    }

    private void Reset()
    {

        Debug.Log("DEATH D:");
pattern = new GameObject[][]
{
    new GameObject[] { box,    na,    na,    na,    na,    na,    na,    na,    na,    na },
    new GameObject[] { na,     death, na,    na,    na,    na,    na,    na,    na,    na },
    new GameObject[] { death,  wall,  death, na,    na,    na,    na,    death, na,    na },
    new GameObject[] { na,     death, na,    na,    death, na,    death, wall,  death, na },
    new GameObject[] { na,     na,    na,    na,    wall, na,    na,    death, wall,  na },
    new GameObject[] { na,     death, na,    na,    death, na,    na,    death, death, death },
    new GameObject[] { death,  wall,  death, na,    na,    na,    na,    na,    wall,  na },
    new GameObject[] { na,     death, na,    death, wall,  death, na,    na,    death, na },
    new GameObject[] { na,     na,    na,    na,    na,    na,    na,    na,    na,    na },
    new GameObject[] { na,     na,    na,    na,    na,    na,    na,    na,    na,    na }, 
};

        box.transform.localPosition = new Vector3(0.0f, box.transform.localPosition.y, 0.0f);
        boxPosition = box.transform.localPosition;
    }

    void OnMove(InputValue value)
    {

        if (!isActive || didWin)
        {
            return;
        }

        Vector2 key = value.Get<Vector2>();



        if (key.y < -0.1)
        {
            Press("DOWN");

            return;
        }
        if (key.y > 0.1)
        {
            Press("UP");
            return;
        }


        if (key.x < -0.1)
        {
            Press("RIGHT");
            return;
        }

        if (key.x > 0.1)
        {
            Press("LEFT");
        }

    }

    private void Start()
    {


        wall = new GameObject("wall");
        death = new GameObject("death");
        na = new GameObject("na");
        boxPosition = box.transform.localPosition;


    

pattern = new GameObject[][]
{
    new GameObject[] { box,    na,    na,    na,    na,    na,    na,    na,    na,    na },
    new GameObject[] { na,     death, na,    na,    na,    na,    na,    na,    na,    na },
    new GameObject[] { death,  wall,  death, na,    na,    na,    na,    death, na,    na },
    new GameObject[] { na,     death, na,    na,    death, na,    death, wall,  death, na },
    new GameObject[] { na,     na,    na,    na,    wall, na,    na,    death, wall,  na },
    new GameObject[] { na,     death, na,    na,    death, na,    na,    death, death, death },
    new GameObject[] { death,  wall,  death, na,    na,    na,    na,    na,    wall,  na },
    new GameObject[] { na,     death, na,    death, wall,  death, na,    na,    death, na },
    new GameObject[] { na,     na,    na,    na,    na,    na,    na,    na,    na,    na },
    new GameObject[] { na,     na,    na,    na,    na,    na,    na,    na,    na,    na }, 
};

        boxArray = new GameObject[] { box };

        Debug.Log("Boxmania Test");

    }

    private float speed = 5;

    private void Update()
    {


        if (box.transform.localPosition != boxPosition)
        {

            box.transform.localPosition = Vector3.MoveTowards(box.transform.localPosition, boxPosition, Time.deltaTime * speed);
        }


    }


}