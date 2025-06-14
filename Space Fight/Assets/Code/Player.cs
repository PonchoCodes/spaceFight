using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float playerSpeed = 0.27f;

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        // Move the player by adding the raw input to the player's position and multiplying the player speed (so the player doesn't move obscenely fast)
        Vector3 positionChange = rawInput;
        transform.position += positionChange * playerSpeed;
    }

    private void OnMove(InputValue value)
    {
        // Get input direction through a vector 2 when movement key is pressed
        rawInput = value.Get<Vector2>();

        /* Debug Log: 
        Debug.Log(rawInput); 
        */
    }
}
