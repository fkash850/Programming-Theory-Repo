using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float speed = 20;
    [SerializeField] private float jumpForce = 7.5f;
    private bool isOnGround = true;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfFalling();

        // Add horizontal input for player
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // Make player jump if spacebar is pressed, player is on ground, and game is not over
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Checks if the player is below the ground
    private void CheckIfFalling()
    {
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if player is on ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if player collides with obstacle
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.GameOver();
        }
    }
}