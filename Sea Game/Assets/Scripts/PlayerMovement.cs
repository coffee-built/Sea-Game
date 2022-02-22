using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float boatSpeed = 2.0f;
    public GameObject boat;
    public GameObject camera;
    public float playerCameraZoom = 5;
    public float boatCameraZoom = 10;
    public float landPushBackFactor = 5;

    private Rigidbody2D rb;
    private Rigidbody2D brb;
    private Vector2 playerVelocity;

    private bool onBoat;
    private bool onGround;
    private bool movementStalled;
    private Vector2 backToLandDirection;
    private Camera thisCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brb = boat.GetComponent<Rigidbody2D>();
        onBoat = false;
        thisCamera = camera.GetComponent<Camera>();
        thisCamera.orthographicSize = playerCameraZoom;
    }

    void Update()
    {
        if (!movementStalled)
        {
            Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (!onBoat)
            {
                rb.velocity = move * playerSpeed;
            }
            else
            {
                brb.AddForce(boatSpeed * move, ForceMode2D.Impulse);
                rb.position = brb.position;
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
                backToLandDirection = -1 * landPushBackFactor * rb.velocity * playerSpeed;
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
                thisCamera.orthographicSize = boatCameraZoom;
                Debug.Log("Boarding Boat");
                rb.position = brb.position;
                onBoat = true;
            }
        }
        else
        {
            if (other.tag == "Ground")
            {
                thisCamera.orthographicSize = playerCameraZoom;
                Debug.Log("Leaving Boat");
                brb.velocity = Vector2.zero;
                onBoat = false;
            }
        }

    }
    
}
