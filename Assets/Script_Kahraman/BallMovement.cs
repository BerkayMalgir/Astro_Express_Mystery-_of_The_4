using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Ball movement speed
    public Transform[] columns; // Array of column transforms
    public float columnHeight = 5f; // Column height

    private int currentColumnIndex = 0; // Index of the current column
    private bool movingUp = true; // Flag to indicate if the ball is moving up
    private Vector3 targetPosition; // Target position for column transition

    void Start()
    {
        targetPosition = columns[currentColumnIndex].position; // Initialize target position to the first column
    }

    void Update()
    {
        // Called every frame

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if the A key is pressed or D key is pressed
        if (horizontalInput < 0 && currentColumnIndex > 0)
        {
            // Move to the previous column
            currentColumnIndex--;
        }
        else if (horizontalInput > 0 && currentColumnIndex < columns.Length - 1)
        {
            // Move to the next column
            currentColumnIndex++;
        }

        // Check if the W key is pressed or S key is pressed
        if (verticalInput > 0 && transform.position.y < targetPosition.y + columnHeight)
        {
            // Move up within the current column
            targetPosition = new Vector3(targetPosition.x, targetPosition.y + columnHeight, targetPosition.z);
            movingUp = true;
        }
        else if (verticalInput < 0 && transform.position.y > targetPosition.y - columnHeight)
        {
            // Move down within the current column
            targetPosition = new Vector3(targetPosition.x, targetPosition.y - columnHeight, targetPosition.z);
            movingUp = false;
        }

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }
}
