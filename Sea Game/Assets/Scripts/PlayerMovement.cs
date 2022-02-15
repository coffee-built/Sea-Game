using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public GameObject boat;
    public float landPushBackFactor = 5;

    private Rigidbody2D rb;
    private Vector2 playerVelocity;

    private bool onBoat;
    private bool onGround;
    private bool movementStalled;
    private Vector2 backToLandDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onBoat = false;
    }

    void Update()
    {
        if (!movementStalled)
        {
            Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (!onBoat)
            {
                rb.AddForce(move, ForceMode2D.Impulse);
            }
            else
            {

            }
        }
        else
        {
            rb.AddForce(backToLandDirection, ForceMode2D.Impulse);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (!onBoat)
        {
            if (other.tag == "Ground")
            {
                movementStalled = true;
                backToLandDirection = -1 * landPushBackFactor * rb.velocity;
            }
        }
        else
        {
            if (other.tag == "Water")
            {
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!onBoat)
        {
            if (other.tag == "Ground")
            {
                movementStalled = false;
                backToLandDirection = Vector2.zero;
            }
            if (other.tag == "Boat")
            {
                Debug.Log("Boarding Boat");
                var boatPosition = boat.transform.position;
                var playerPosition = gameObject.transform.position;
                var playerOnBoatVector = new Vector2(boatPosition.x - playerPosition.x, boatPosition.z - playerPosition.z);

                //playerController.Move(playerOnBoatVector);
                onBoat = true;

            }
        }

    }
}
