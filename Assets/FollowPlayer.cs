using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // Assign the player in the Inspector
    public float offsetUp = 0f; // Offset from the player position
    public float offsetForward = 0f; // Offset from the player position
    public float offsetRight = 0f; // Offset from the player position


    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the offset using player's local directions
            Vector3 offset = playerTransform.right * offsetRight
                           + playerTransform.up * offsetUp
                           + playerTransform.forward * offsetForward;

            transform.position = playerTransform.position + offset;

            // Optional: Match rotation
            transform.rotation = playerTransform.rotation;
        }
    }

}