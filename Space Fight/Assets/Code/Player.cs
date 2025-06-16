using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    // Player Movement
    Vector2 rawInput;
    [SerializeField] float playerSpeed = 15f;

    // Player Bounds
    // Bottom left
    Vector2 minBounds;
    //Top right
    Vector2 maxBounds;

    // Padding to account for player size
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    void Update()
    {
    Move();
    }
    void Start()
    {
        // Get Camera Boundries
        InitializeBounds();
    }
    private void Move()
    {
        // Move the player by adding the raw input to the player's position and multiplying the player speed (so the player doesn't move obscenely fast)
        Vector2 positionChange = rawInput * playerSpeed * Time.deltaTime;
        //Clamping position whilst simultaneously adding the position change
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + positionChange.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + positionChange.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        // set player position to the new position 
        transform.position = newPos;
    }

    private void OnMove(InputValue value)
    {
        // Get input direction through a vector 2 when movement key is pressed
        rawInput = value.Get<Vector2>();
    }

    private void InitializeBounds()
    {
        // Camera in the heirarchy tagged as main camera
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
