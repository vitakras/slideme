using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Grid))]
public class GridBoundary : MonoBehaviour {

    public Vector3 size = new Vector3(1f, 2f, 1f);
    public Vector3 offset = new Vector3(0.5f, 0f, 0.5f);

    private Grid grid;

    private const string BOUNDARIES_NAME = "Boundaries";

    // Use this for initialization
    void Start () {
        // Gets the Grid component
        this.grid = this.gameObject.GetComponent<Grid>();

        this.SetBoundary();
	}
	
    private void SetBoundary() {
        var rows = this.grid.rows;
        var cols = this.grid.cols;

        // Creates a parent element to store children
        GameObject boundaries = Instantiate(new GameObject());
        boundaries.name = BOUNDARIES_NAME;
        boundaries.transform.parent = this.transform;

        // Back Border
        GameObject back = (GameObject) Instantiate(new GameObject(), new Vector3((cols / 2) - this.offset.x,
            this.transform.position.y, this.transform.position.z - 1), Quaternion.identity);
        back.name = "back";
        back.transform.parent = boundaries.transform;
        back.AddComponent<BoxCollider>();
        {
            BoxCollider colider = back.GetComponent<BoxCollider>();
            colider.size = new Vector3(cols * this.size.x, this.size.y, this.size.z);
        }

        // Front Border
        GameObject front = (GameObject)Instantiate(new GameObject(), new Vector3((cols / 2) - this.offset.x,
            this.transform.position.y, this.transform.position.z + rows), Quaternion.identity);
        front.name = "front";
        front.transform.parent = boundaries.transform;
        front.AddComponent<BoxCollider>();
        {
            BoxCollider colider = front.GetComponent<BoxCollider>();
            colider.size = new Vector3(cols * this.size.x, this.size.y, this.size.z);
        }

        // Left Border
        GameObject left = (GameObject)Instantiate(new GameObject(), new Vector3(this.transform.position.x - 1,
            this.transform.position.y, (rows / 2) - this.offset.z), Quaternion.identity);
        left.name = "left";
        left.transform.parent = boundaries.transform;
        left.AddComponent<BoxCollider>();
        {
            BoxCollider colider = left.GetComponent<BoxCollider>();
            colider.size = new Vector3(this.size.x, this.size.y, this.size.z * rows);
        }

        // Left Border
        GameObject right = (GameObject)Instantiate(new GameObject(), new Vector3(this.transform.position.x + cols,
            this.transform.position.y, (rows / 2) - this.offset.z), Quaternion.identity);
        right.name = "right";
        right.transform.parent = boundaries.transform;
        right.AddComponent<BoxCollider>();
        {
            BoxCollider colider = right.GetComponent<BoxCollider>();
            colider.size = new Vector3(this.size.x, this.size.y, this.size.z * rows);
        }
    }
}
