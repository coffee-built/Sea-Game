using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public GameObject boat;

    private Rigidbody2D rb;
    private Vector2 playerVelocity;

    private bool onBoat;
    private bool onGround;
    private bool movementStalled;

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
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (!onBoat)
        {
            if (other.tag == "Ground")
            {
                movementStalled = true;
                rb.velocity = -1 * rb.velocity;
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
