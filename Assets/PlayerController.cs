using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject[] players;
    private MovableInterface[] movables;

	// Use this for initialization
	void Start () {
        int length = this.players.Length;
        this.movables = new MovableInterface[length];

        for(int i = 0; i < length; i++) {
            this.movables[i] = players[i].GetComponent<MovableInterface>();
        }
       
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        foreach (MovableInterface moveable in this.movables) {
            if (Input.anyKeyDown) {
                moveable.isMoving = true;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow) ||
                Input.GetKeyUp(KeyCode.DownArrow) ||
                Input.GetKeyUp(KeyCode.LeftArrow) ||
                Input.GetKeyUp(KeyCode.RightArrow)) {
                moveable.isMoving = false;
            }

            moveable.Move(direction);

        }

    }
}
