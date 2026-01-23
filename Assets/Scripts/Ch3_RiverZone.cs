using UnityEngine;

public class Ch3_RiverZone : MonoBehaviour
{
    [Header("River settings")]
    [Tooltip("Direction of the river flow (will be normalized).")]
    public Ch3_CustomVector2 riverDirection = new Ch3_CustomVector2(1f, 0f);

    [Tooltip("Scalar strength of the river (units per second).")]
    public float riverStrength = 1.5f;

    void OnTriggerEnter(Collider other)
    {
        Ch3_PlayerController player = other.GetComponent<Ch3_PlayerController>();
        if (player != null)
        {
            player.inRiver = true;
            var appliedCurrent =
                Ch3_CustomVector2.Multiply(
                    riverDirection.Normalized(),
                    riverStrength * Time.deltaTime
                );
            player.riverCurrent = appliedCurrent;

            Debug.Log($"[RiverZone] Player entered river. Direction: {riverDirection}, Strength: {riverStrength}, Applied current (this frame): {appliedCurrent}");
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Keep applying current while the player stays in the river and log periodically
        Ch3_PlayerController player = other.GetComponent<Ch3_PlayerController>();
        if (player != null && player.inRiver)
        {
            var appliedCurrent =
                Ch3_CustomVector2.Multiply(
                    riverDirection.Normalized(),
                    riverStrength * Time.deltaTime
                );
            player.riverCurrent = appliedCurrent;

            Debug.Log($"[RiverZone] Applying river current to player: {appliedCurrent}");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Ch3_PlayerController player = other.GetComponent<Ch3_PlayerController>();
        if (player != null)
        {
            player.inRiver = false;
            player.riverCurrent = new Ch3_CustomVector2(0f, 0f);
            Debug.Log("[RiverZone] Player exited river. River effect cleared.");
        }
    }
}
