using UnityEngine;

public class Ch3_RiverZone : MonoBehaviour
{
    // Direction and strength of the river
    public Ch3_CustomVector2 riverDirection = new Ch3_CustomVector2(1f, 0f);
    public float riverStrength = 1.5f;

    void OnTriggerEnter(Collider other)
    {
        Ch3_PlayerController player = other.GetComponent<Ch3_PlayerController>();
        if (player != null)
        {
            player.inRiver = true;
            player.riverCurrent =
                Ch3_CustomVector2.Multiply(
                    riverDirection.Normalized(),
                    riverStrength * Time.deltaTime
                );
        }
    }

    void OnTriggerExit(Collider other)
    {
        Ch3_PlayerController player = other.GetComponent<Ch3_PlayerController>();
        if (player != null)
        {
            player.inRiver = false;
            player.riverCurrent = new Ch3_CustomVector2(0f, 0f);
        }
    }
}
