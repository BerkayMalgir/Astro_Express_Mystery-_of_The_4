using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Ball movement speed
    public int columnCount = 5; // Number of columns
    public int rowCount = 3; // Number of rows
    public Transform spawnPoint; // Spawn point empty object
    private Transform[,] intersections; // Array of intersection transforms
    private int currentRowIndex = 0; // Index of the current row
    private int currentColumnIndex = 0; // Index of the current column
    private Vector3 targetPosition; // Target position for transition

    private bool isMoving = false; // Flag to track if the character is moving
    private Vector3 startPosition; // Starting position for the movement
    private float movementStartTime; // Time when the movement started
    private float movementDuration = 0.5f; // Duration of the movement in seconds

    void Start()
    {
        intersections = new Transform[rowCount, columnCount]; // Initialize the intersections array

        // Calculate the position of each intersection point
        float columnSpacing = 2f; // Spacing between columns
        float rowSpacing = 2f; // Spacing between rows

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                // Calculate the position based on the spacing and row/column index
                Vector3 position = spawnPoint.position + new Vector3(column * columnSpacing, row * rowSpacing, 0f);

                // Instantiate an intersection object at the calculated position
                GameObject intersectionObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                intersectionObj.transform.position = position;
                intersectionObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Reduce the size of intersection objects

                // Assign the intersection object to the intersections array
                intersections[row, column] = intersectionObj.transform;
            }
        }

        targetPosition = intersections[currentRowIndex, currentColumnIndex].position; // Set the initial target position

        // Set the visibility of intersection objects to false
        SetIntersectionVisibility(false);
    }

    void Update()
    {
        // Called every frame

        // Check if the character is already moving
        if (isMoving)
        {
            // Calculate the time passed since the movement started
            float elapsedTime = Time.time - movementStartTime;

            // Calculate the percentage of the movement completed
            float percentageComplete = elapsedTime / movementDuration;

            // Smoothly move towards the target position using Lerp
            transform.position = Vector3.Lerp(startPosition, targetPosition, percentageComplete);

            // Check if the movement is complete
            if (percentageComplete >= 1f)
            {
                isMoving = false;
                transform.position = targetPosition; // Ensure the final position is accurate
            }
        }
        else
        {
            // Check for input and start a new movement if available

            // Check if the A key is pressed
            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move to the previous column (if available)
                if (currentColumnIndex > 0)
                {
                    currentColumnIndex--;
                    StartMovementToIntersection(intersections[currentRowIndex, currentColumnIndex].position);
                }
            }
            // Check if the D key is pressed
            else if (Input.GetKeyDown(KeyCode.D))
            {
                // Move to the next column (if available)
                if (currentColumnIndex < columnCount - 1)
                {
                    currentColumnIndex++;
                    StartMovementToIntersection(intersections[currentRowIndex, currentColumnIndex].position);
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move to the previous row (if available)
                if (currentRowIndex > 0)
                {
                    currentRowIndex--;
                    StartMovementToIntersection(intersections[currentRowIndex, currentColumnIndex].position);
                }
            }
            // Check if the S key is pressed
            else if (Input.GetKeyDown(KeyCode.W))
            {
                // Move to the next row (if available)
                if (currentRowIndex < rowCount - 1)
                {
                    currentRowIndex++;
                    StartMovementToIntersection(intersections[currentRowIndex, currentColumnIndex].position);
                }
            }
        }

        // Check if the V key is pressed to toggle intersection visibility
        if (Input.GetKeyDown(KeyCode.V))
        {
            bool isVisible = intersections[0, 0].gameObject.activeSelf;
            SetIntersectionVisibility(!isVisible);
        }
    }

    // Function to set the visibility of intersection objects
    void SetIntersectionVisibility(bool isVisible)
    {
        foreach (Transform intersection in intersections)
        {
            intersection.gameObject.SetActive(isVisible);
        }
    }

    // Function to start a new movement to the specified position
    void StartMovementToIntersection(Vector3 destination)
    {
        // Store the starting position and time
        startPosition = transform.position;
        movementStartTime = Time.time;

        // Set the target position and start the movement
        targetPosition = destination;
        isMoving = true;
    }
}
