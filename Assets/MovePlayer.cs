using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour, MovableInterface {

    public float thrust;
    public float maxSpeed;

    private Vector3 direction;
    private bool moving = false;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        this.rb = gameObject.GetComponent<Rigidbody>(); 
        this.direction = Vector3.zero;
        this.moving = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate() {
        if (moving && direction != Vector3.zero) {
            this.rb.AddForce(this.direction * this.thrust);
        }

        if (!moving) {
            this.rb.velocity = Vector3.zero;
        }

        // Limits the max speed the object will move
        if (this.rb.velocity.magnitude > this.maxSpeed) {
            this.rb.velocity = rb.velocity.normalized * this.maxSpeed;
        }
    }


    public void Move(Vector3 direction) {
        this.direction = direction;

        if (direction != Vector3.zero) {
            if (direction.x == 0) {
                this.rb.constraints = RigidbodyConstraints.FreezePositionX 
                    | RigidbodyConstraints.FreezeRotation 
                    | RigidbodyConstraints.FreezePositionY;
            }
            else if (direction.z == 0) {
                this.rb.constraints = RigidbodyConstraints.FreezePositionZ
                    | RigidbodyConstraints.FreezeRotation
                    | RigidbodyConstraints.FreezePositionY;
            }
        }
        
        // Sets Vector to Magnitude of 1 
        this.direction.Normalize();
    }

    public bool isMoving {
        get {
            return this.moving;
        }

        set {
            this.moving = value;
        }
    }
}
