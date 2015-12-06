using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color(1F, 0.0F, 0.0F, 0.5F);
}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        gameObject.GetComponent<Renderer>().material.color = new Color(0F, 1.0F, 0.0F, 0.5F);
    }

    void OnTriggerExit(Collider other) {
        gameObject.GetComponent<Renderer>().material.color = new Color(1F, 0.0F, 0.0F, 0.5F);
    }
}
