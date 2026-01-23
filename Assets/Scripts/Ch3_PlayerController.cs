using UnityEngine;

public class Ch3_PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;

    // River influence (set by RiverZone)
    public Ch3_CustomVector2 riverCurrent;
    public bool inRiver = false;

    void Update()
    {
        // Read input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Ch3_CustomVector2 inputDir = new Ch3_CustomVector2(h, v);

        // Normalize input direction
        inputDir = inputDir.Normalized();

        // Base movement
        Ch3_CustomVector2 movement =Ch3_CustomVector2.Multiply(inputDir, moveSpeed * Time.deltaTime);

        // Add river current if in river
        if (inRiver)
        {
            movement = Ch3_CustomVector2.Add(movement, riverCurrent);
        }

        // Apply movement to transform
        transform.position += new Vector3(movement.x, 0f, movement.y);
    }
}
