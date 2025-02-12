using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {
	
	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	public float yPosRestriction = -1;

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
	
	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;
    public Vector3 offset;
    CharacterControllerScript player;
    bool flipped = true;
    float nextTimeToSearch = 0;
	
	// Use this for initialization
	void Awake () {
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
        player = UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>();
        offset.x = 0.4f;
    }

    // Update is called once per frame
    void Update () {

		if (target == null) {
			FindPlayer ();
			return;
		}
        if (!player.facingRight && flipped)
        {
            offset.x *= -1;
            flipped = false;
        }
        else if(player.facingRight && !flipped)
        {
            offset.x *= -1;
            flipped = true;
        }

		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;

	    bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}
		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

		newPos = new Vector3 (newPos.x, Mathf.Clamp (newPos.y, yPosRestriction, Mathf.Infinity), newPos.z);

		transform.position = newPos;
		
		lastTargetPosition = target.position;

        if (bounds){
            transform.position = new Vector3(
                x: Mathf.Clamp(transform.position.x + offset.x, minCameraPos.x, maxCameraPos.x),
                y: Mathf.Clamp(transform.position.y + offset.y, minCameraPos.y, maxCameraPos.y),
                z: Mathf.Clamp(transform.position.z + offset.z, minCameraPos.z, maxCameraPos.z)
                );
        }
	}

	void FindPlayer () {
		if (nextTimeToSearch <= Time.time) {
            UnityEngine.GameObject searchResult = UnityEngine.GameObject.FindGameObjectWithTag("Player");
			if (searchResult != null)
				target = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
}
