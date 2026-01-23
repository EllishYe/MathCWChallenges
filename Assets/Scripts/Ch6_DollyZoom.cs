using UnityEngine;

public class Ch6_DollyZoom : MonoBehaviour
{
    [Header("Target")]
    // The subject that should remain the same size on screen
    public Transform target;

    [Header("Movement")]
    // Speed of camera movement along the forward axis
    public float dollySpeed = 2f;

    [Header("FOV Settings")]
    // Initial field of view of the camera
    public float initialFOV = 60f;

    private Camera cam;
    private float initialDistance;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Store the initial distance between camera and target
        initialDistance = Vector3.Distance(transform.position, target.position);

        // Set initial FOV
        cam.fieldOfView = initialFOV;
    }

    void Update()
    {
        // Move camera forward/backward using keyboard input
        float input = Input.GetAxis("Vertical"); // W/S or Up/Down
        transform.position += transform.forward * input * dollySpeed * Time.deltaTime;

        // Calculate current distance to the target
        float currentDistance = Vector3.Distance(transform.position, target.position);

        // Adjust FOV to keep target size consistent
        cam.fieldOfView = CalculateFOV(initialDistance, currentDistance, initialFOV);
    }

    /*
     <summary>
    - Calculates the new field of view based on camera distance.
    - This maintains the same apparent size of the target.
    */
    float CalculateFOV(float initialDist, float currentDist, float initialFOV)
    {
        // Convert FOV from degrees to radians
        float initialFOVRad = initialFOV * Mathf.Deg2Rad;

        // Formula derived from perspective projection
        float newFOVRad = 2f * Mathf.Atan(
            Mathf.Tan(initialFOVRad / 2f) * (initialDist / currentDist)
        );

        // Convert back to degrees
        return newFOVRad * Mathf.Rad2Deg;
    }
}
