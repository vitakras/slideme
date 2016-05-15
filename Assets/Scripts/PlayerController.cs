using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

	public GameObject [] players;
	private MovableInterface[] movables;

	void Start () {
		this.movables = new MovableInterface[this.players.Length];
		for(var i = 0; i < this.players.Length; i++) {
			this.movables[i] = this.players[i].GetComponent<MovableInterface>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		foreach (MovableInterface moveable in movables) {
			moveable.Move(direction);
		}
    }
}
