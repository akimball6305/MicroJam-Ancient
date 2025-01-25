
using UnityEngine;
using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class Boxmania : MonoBehaviour
{
	public bool didWin = false;
	public bool canBeActive = false;
	public bool isActive = false;

	[SerializeField] GameObject box;



	[SerializeField] GameObject box2;

	[SerializeField] GameObject box3;

	private GameObject na;
	[SerializeField] GameObject wall;
	private GameObject[] boxArray;
	private GameObject[][] pattern;


	private Vector3 boxPosition = new Vector3(0.0f, 0.0f, 0.0f);
	private Vector3 box2Position = new Vector3(0.0f, 0.0f, 0.0f);
	private Vector3 box3Position = new Vector3(0.0f, 0.0f, 0.0f);
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
					if (key == "UP" && yIndex != 0 && pattern[yIndex - 1][xIndex] == na)
					{
						if (boxArray.Contains(cell))
						{
							pattern[yIndex - 1][xIndex] = pattern[yIndex][xIndex];
							pattern[yIndex][xIndex] = na;
							UpdateBoxPosition(cell, xIndex, yIndex - 1);
							didMove = true;
						}
					}
					else if (key == "LEFT" && xIndex != 0 && pattern[yIndex][xIndex - 1] == na)
					{
						if (boxArray.Contains(cell))
						{
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

			for (int yIndex2 = 4; yIndex2 >= 0; yIndex2--)
			{
				for (int xIndex2 = 7; xIndex2 >= 0; xIndex2--)
				{
					if (key == "DOWN" && yIndex2 != 4 && pattern[yIndex2 + 1][xIndex2] == na)
					{
						if (boxArray.Contains(pattern[yIndex2][xIndex2]))
						{
							pattern[yIndex2 + 1][xIndex2] = pattern[yIndex2][xIndex2];
							UpdateBoxPosition(pattern[yIndex2][xIndex2], xIndex2, yIndex2 + 1);
							pattern[yIndex2][xIndex2] = na;
							
							didMove = true;
						}
					}
					else if (key == "RIGHT" && xIndex2 != 7 && pattern[yIndex2][xIndex2 + 1] == na)
					{
						if (boxArray.Contains(pattern[yIndex2][xIndex2]))
						{
							pattern[yIndex2][xIndex2 + 1] = pattern[yIndex2][xIndex2];
							UpdateBoxPosition(pattern[yIndex2][xIndex2], xIndex2 + 1, yIndex2);
							pattern[yIndex2][xIndex2] = na;


							
							didMove = true;
						}
					}
				}
			}
		}

		if(didMove){

			didWin = boxArray.Contains(pattern[2][5]) && boxArray.Contains(pattern[3][3]) && boxArray.Contains(pattern[1][2]);
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
		else if (box == box2)
		{
			box2Position = newPosition;
		}
		else if (box == box3)
		{
			box3Position = newPosition;
		}
	}


	void OnInteract(InputValue value)
	{		

		if(didWin || !canBeActive){
			isActive = false;
			return;
		}
		if (!value.isPressed)
		{

			isActive = !isActive;

		}


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

		if (key.x > 0.1){
			Press("LEFT");
		}
		
	}

	private void Start()
	{

		boxPosition = box.transform.localPosition;
		box2Position = box2.transform.localPosition;
		box3Position = box3.transform.localPosition;


		pattern = new GameObject[][]
	   {
		new GameObject[] { box, na, na, na, na, na, na, na },
		new GameObject[] { na, na, na, na, na, na, na, na },
		new GameObject[] { na, na, na, wall, na, box2, na, na },
		new GameObject[] { na, na, na, na, na, na, na, na },
		new GameObject[] { na, na, na, na, na, na, na, box3 }
	   };

		boxArray = new GameObject[] { box, box2, box3 };

		Debug.Log("Boxmania Test");

	}

	private float speed = 5;

	private void Update()
	{


		if (box.transform.localPosition != boxPosition)
		{

			box.transform.localPosition = Vector3.MoveTowards(box.transform.localPosition, boxPosition, Time.deltaTime * speed);
		}

		if (box2.transform.localPosition != box2Position)
		{

			box2.transform.localPosition = Vector3.MoveTowards(box2.transform.localPosition, box2Position, Time.deltaTime * speed);
		}

		if (box3.transform.localPosition != box3Position)
		{

			box3.transform.localPosition = Vector3.MoveTowards(box3.transform.localPosition, box3Position, Time.deltaTime * speed);
		}



	}


}