using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2DCamera : MonoBehaviour
{
    [Header("Camera")]
    [Tooltip("Reference to the target GameObject")]
    public Transform target;
    [Tooltip("Current relative offset to the target")]
    public Vector3 offset;
    [Tooltip("Multiplier for the movement speed")]
    [Range(0f, 5f)]
    public float smoothSpeed = 0.125f;
    [Tooltip("Maximum or highest camera position on the Y-axis.")]
    public float maxHeight = 5f;
    [Tooltip("Minimum or lowest camera position on the Y-axis.")]
    public float minHeight = -1f;
    public float StartFollowingDistance = 10f;
    private bool perspective = false;
    private bool following = false;
    CharacterControllerScript player;
    bool flipped = true;

    // Use this for initialization
    void Start()
    {
        player = UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>();
        if (!Camera.main.orthographic)
        {
            perspective = true;
        }
       // offset.x = 0.4f;
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    void LateUpdate()
    {
        if (!player.facingRight && flipped)
        {
            offset.x *= -1;
            flipped = false;
        }
        else if (player.facingRight && !flipped)
        {
            offset.x *= -1;
            flipped = true;
        }
        if (Vector2.Distance(transform.position, target.position) < StartFollowingDistance || following )
        {
            following = true;
            Vector2 smoothedPosition = Vector2.Lerp(transform.position, target.position + offset, smoothSpeed);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minHeight, maxHeight);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, target.position.z + offset.z);

            if (perspective)
            {
                transform.LookAt(target);
            }
        }
        
    }
}
