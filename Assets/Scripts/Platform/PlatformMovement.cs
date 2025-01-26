using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] float lowerYPosition = 1f;
    [SerializeField] float upperYPosition = 18f;
    [SerializeField] float speed = 2f;
    private bool onPlatform = false;
    public bool isLowered = false; 
    private bool isMoving = false; 

    public bool canRise = true;
    [SerializeField] TextMeshProUGUI instructions;

    void Update()
    {
        if (onPlatform && Input.GetKeyDown(KeyCode.E) && !isMoving)
        {
            if (isLowered && !canRise){
                return;
            }
            isLowered = !isLowered;
            isMoving = true;
        }

        if (isMoving)
        {
            if (isLowered && platform.position.y > lowerYPosition)
            {
                platform.position = Vector3.MoveTowards(platform.position, new Vector3(platform.position.x, lowerYPosition, platform.position.z), speed * Time.deltaTime);

                if (platform.position.y <= lowerYPosition)
                {
                    isMoving = false; 
                }
            }
            else if (!isLowered && platform.position.y < upperYPosition)
            {
                platform.position = Vector3.MoveTowards(platform.position, new Vector3(platform.position.x, upperYPosition, platform.position.z), speed * Time.deltaTime);

                if (platform.position.y >= upperYPosition)
                {
                    isMoving = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger. Press E to toggle the platform.");
            onPlatform = true;
            if (isLowered && !canRise){
                return;
            }
            instructions.text = "Press E to interact";

            instructions.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left the trigger.");
            onPlatform = false;
            instructions.gameObject.SetActive(false);
        }
    }
}