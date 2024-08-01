using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float distanceFromPlayer = .2f;
    public Transform playerTransform; // Assign the player in the Inspector
    public Vector3 offset = Vector3.zero; // Offset from the player position

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the new position in front of the player
            Vector3 newPosition = playerTransform.position + playerTransform.forward * distanceFromPlayer + new Vector3(0f,.5f, 0f);

            // Set the position of the GameObject
            transform.position = newPosition;

            // Optional: Rotate the GameObject to face the same direction as the player
            transform.rotation = playerTransform.rotation;
        }
    }
}