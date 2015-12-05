using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour, MovableInterface {

    public float maxSpeed;
    public float rayDistance = 1.5f;

    private Vector3 targetPosition;
    private Vector3 direction;

    private bool moving;
    private bool calStopPosition;

    // Use this for initialization
    void Start () {
        this.direction = Vector3.zero;
        this.targetPosition = this.transform.position;
        this.moving = false;
        this.calStopPosition = false;
    }

    // Update is called once per frame
    void Update() {
        if (!isMoving && !this.calStopPosition) {
            CalculateTargetPosition();
            this.calStopPosition = true; // to avoid redoing this calculation
        }


        float step = maxSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, this.targetPosition, step);
   }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("ENTER");

    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("ENTER");
    }

    public void Move(Vector3 direction) {
        if (direction != Vector3.zero) {
            RaycastHit hitInfo;
            this.direction = direction.normalized;
            this.calStopPosition = false; // when new position is given we want to rest this

            Debug.DrawRay(this.transform.position, transform.TransformDirection(direction) * this.rayDistance);
            Debug.Log("Drawing array");
            if (Physics.Raycast(this.transform.position, transform.TransformDirection(direction), out hitInfo, this.rayDistance)) {
                this.isMoving = false;
                Debug.Log("Will Hit something");
                return;
            }


            this.targetPosition = this.transform.position + this.direction;
        }
    }

    public bool isMoving {
        get {
            return this.moving;
        }

        set {
            this.moving = value;
        }
    }

    private void CalculateTargetPosition() {
        this.targetPosition = new Vector3(
           Mathf.Round(targetPosition.x), // direction.x < 0 ? Mathf.Floor(targetPosition.x) : Mathf.Ceil(targetPosition.x),
           Mathf.Round(targetPosition.y), // direction.y < 0 ? Mathf.Floor(targetPosition.y) : Mathf.Ceil(targetPosition.y),
           Mathf.Round(targetPosition.z)); // direction.z < 0 ? Mathf.Floor(targetPosition.z) : Mathf.Ceil(targetPosition.z));
        Debug.Log(this.gameObject + " - taget Position: " + this.targetPosition);
    }
}
