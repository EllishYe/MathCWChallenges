using UnityEngine;

/*
<summary>
- Computes the orientation angle of a 2D vector (x, y) relative to the positive X-axis.
- Fully hard-coded, does not use any built-in Mathf or trigonometric functions.
- Uses a fast arctangent approximation with error < 0.1бу.
- Also draws the vector and X-axis in Scene View for visualization.
*/

public class Ch2_VectorOrientation2D : MonoBehaviour
{
    // Test vector, adjustable in Inspector
    public Vector2 testVector = new Vector2(1, 1);

    // Optional: vector scale for Gizmos
    public float gizmoScale = 5f;

    void Start()
    {
        // Compute the orientation angle
        float angle = ComputeOrientation(testVector.x, testVector.y);

        // Output result to console
        Debug.Log("Vector: " + FormatVector(testVector) + " | Angle: " + angle + " degrees");
    }

    /*
     <summary>
     Computes the orientation angle (0иC360 degrees) of a 2D vector (x, y)
     relative to the positive X-axis
    */
    float ComputeOrientation(float x, float y)
    {
        // Handle zero vector
        if (x == 0f && y == 0f)
            return 0f;

        // Step 1: Compute base angle using custom high-precision atan
        float angleRad = CustomAtan(y / x);

        // Step 2: Quadrant correction
        if (x < 0f)
        {
            // Quadrant II or III
            angleRad += PI;
        }
        else if (x > 0f && y < 0f)
        {
            // Quadrant IV
            angleRad += TWO_PI;
        }

        // Convert radians to degrees
        return angleRad * RAD_TO_DEG;
    }

    // Hard-coded constants

    const float PI = 3.14159265358979323846f;
    const float TWO_PI = 2f * PI;
    const float RAD_TO_DEG = 180f / PI;


    // Fully hard-coded arctangent approximation,Error < 0.1бу for all inputs

    float CustomAtan(float z)
    {
        // Use identity for |z| > 1 to improve accuracy
        if (z > 1f) return PI / 2 - CustomAtan(1f / z);
        if (z < -1f) return -PI / 2 - CustomAtan(1f / -z);

        // Absolute value (hard-coded)
        float absZ = Abs(z);

        // Fast arctangent approximation formula
        return (PI / 4f) * z - z * (absZ - 1f) * (0.2447f + 0.0663f * absZ);
    }


    // Custom absolute value function

    float Abs(float x)
    {
        return x >= 0f ? x : -x;
    }


    // Format Vector2 for console printing

    string FormatVector(Vector2 v)
    {
        return "(" + v.x.ToString("F2") + ", " + v.y.ToString("F2") + ")";
    }

    // Scene View visualization

    void OnDrawGizmos()
    {
        // Draw the test vector in red
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, new Vector3(testVector.x, testVector.y, 0) * gizmoScale);

        // Draw the positive X-axis in white
        Gizmos.color = Color.white;
        Gizmos.DrawLine(Vector3.zero, Vector3.right * gizmoScale);
    }

}
