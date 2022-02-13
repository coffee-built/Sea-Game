using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;
    //private CharacterController boatController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float gravityValue = -9.81f;
    public GameObject boat;

    private bool onBoat;

    void Start()
    {
        playerController = gameObject.AddComponent<CharacterController>();
        //boatController = boat.AddComponent<CharacterController>();

        onBoat = false;
    }

    void Update()
    {
        groundedPlayer = playerController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (!onBoat)
        {
            playerController.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            playerController.Move(playerVelocity * Time.deltaTime);
        }
        else
        {

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!onBoat)
        {
            if (other.tag == "Water")
            {
                playerController.Move(-1 * gameObject.transform.position); //TODO: Hacky, see if you can just block characters from it, might need to use invisible walls
            }

            if (other.tag == "Boat")
            {
                Debug.Log("Boarding Boat");
                var boatPosition = boat.transform.position;
                var playerPosition = gameObject.transform.position;
                var playerOnBoatVector = new Vector3(boatPosition.x - playerPosition.x, 3, boatPosition.z - playerPosition.z);

                playerController.Move(playerOnBoatVector);
                onBoat = true;

            }
        }
        else
        {

        }
    }
}
