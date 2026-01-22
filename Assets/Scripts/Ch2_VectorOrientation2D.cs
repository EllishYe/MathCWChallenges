using UnityEngine;

public class Ch2_VectorOrientation2D : MonoBehaviour
{
    // Test vector (can be modified in Inspector)
    public Vector2 testVector = new Vector2(1, 1);

    void Start()
    {
        float angle = ComputeOrientation(testVector.x, testVector.y);
        Debug.Log("Vector: " + testVector + " | Angle: " + angle + " degrees");
    }

    /// <summary>
    /// Returns the orientation angle (0¨C360 degrees)
    /// between the positive X-axis and vector (x, y)
    /// </summary>
    float ComputeOrientation(float x, float y)
    {
        // Handle zero vector
        if (x == 0 && y == 0)
            return 0f;

        // Step 1: Compute base angle using custom atan
        float angleRad = CustomAtan(y / x);

        // Step 2: Quadrant correction
        if (x < 0)
        {
            // II or III quadrant
            angleRad += PI;
        }
        else if (x > 0 && y < 0)
        {
            // IV quadrant
            angleRad += TWO_PI;
        }

        // Convert radians to degrees
        return angleRad * RAD_TO_DEG;
    }

    // ----------------------------
    // Hard-coded math helpers
    // ----------------------------

    const float PI = 3.14159265359f;
    const float TWO_PI = 6.28318530718f;
    const float RAD_TO_DEG = 57.295779513f;

    /// <summary>
    /// Approximation of arctangent using Taylor series
    /// Valid for |x| <= 1
    /// </summary>
    float CustomAtan(float z)
    {
        // If |z| > 1, use identity:
        // atan(z) = PI/2 - atan(1/z)
        if (z > 1)
            return PI / 2 - CustomAtan(1 / z);
        if (z < -1)
            return -PI / 2 - CustomAtan(1 / z);

        // Taylor series approximation
        float z2 = z * z;
        float z3 = z2 * z;
        float z5 = z3 * z2;
        float z7 = z5 * z2;

        return z - z3 / 3f + z5 / 5f - z7 / 7f;
    }

    // ----------------------------
    // Visualization in Scene View
    // ----------------------------

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, new Vector3(testVector.x, testVector.y, 0));

        Gizmos.color = Color.white;
        Gizmos.DrawLine(Vector3.zero, Vector3.right * 3f);
    }
}
