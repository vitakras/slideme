using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class FinishBlock : MonoBehaviour {

	public enum State {
		IN,
		OUT
	}

	public string collidedTag = "Player";
	public Material outside;
	public Material inside;
	private State state;

	// Use this for initialization
	void Start () {
		state = State.OUT;
		this.ChangeMaterial();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == this.collidedTag) {
			this.state = State.IN;
			this.ChangeMaterial();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == this.collidedTag) {
			this.state = State.OUT;
			this.ChangeMaterial();
		}
	}

	private void ChangeMaterial() {
		if (state == State.IN) {
			gameObject.GetComponent<Renderer>().material = inside;
		} else {
			gameObject.GetComponent<Renderer>().material = outside;
		}
	}
}
