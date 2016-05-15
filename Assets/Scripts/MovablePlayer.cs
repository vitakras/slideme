using UnityEngine;
using System.Collections;

public class MovablePlayer : MonoBehaviour, MovableInterface {

	public float speed = 5f;
	public float movableBy = 1f;
	public float rayCastDistance = 1.0f;
	public string [] collidableTags = new string[0];
	public float movementOffset = 0.002f;

	private bool _isMoving;
	private Vector3 direction;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		this.ResetMovement();
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			float step = speed * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.targetPosition, step);

			float distance = Vector3.Distance(transform.position, this.targetPosition);
			if (distance <= this.movementOffset) {
				this.transform.position = this.targetPosition;
				this.ResetMovement();
			}
		}
	}

	// debug purpose
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawRay(this.transform.position, this.direction);
	}
		
	public void Move(Vector3 direction) {
		// only move if the player is not moving
		if(!isMoving && CanMove(direction) && direction != Vector3.zero) {
			this.direction = direction.normalized;
			this.targetPosition = this.transform.position 
				+ (this.direction * this.movableBy);
			this._isMoving = true;
		}
	}

	public bool isMoving {
		get {
			return this._isMoving;
		}
	}

	/// <summary>
	/// Resets the direction and if the player is movings
	/// </summary>
	private void ResetMovement() {
		this._isMoving = false;
		this.direction = Vector3.zero;
		this.targetPosition = this.transform.position;
	}

	/// <summary>
	/// Cans the move the player move into the direction.
	/// </summary>
	/// <returns><c>true</c>, if move was caned, <c>false</c> otherwise.</returns>
	/// <param name="direction">Direction. desired direction</param>
	private bool CanMove(Vector3 direction) {
		bool canMove = true;
		direction = direction.normalized;

		RaycastHit hitInfo;
		if (Physics.Raycast(this.transform.position, direction, out hitInfo, this.rayCastDistance)) {
			MovableInterface movable = hitInfo.collider.gameObject.GetComponent<MovableInterface>();
			if (movable != null) { // if the hit object is a movable try moving it
				movable.Move(direction);
				canMove = movable.isMoving;
			} else {
				foreach (string tag in this.collidableTags) {
					if (tag == hitInfo.collider.tag) {
						Debug.Log(this.gameObject.name + ": Hit Object - " + hitInfo.collider.gameObject.name);
						canMove = false;
					}
				}
			}
		}

		return canMove;
	}
}