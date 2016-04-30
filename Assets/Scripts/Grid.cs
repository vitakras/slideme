using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public GameObject tilePrefab;
    public int rows, cols = 10;
    public float offset = 1;

    private const string TILES_NAME = "Tiles";

	// Use this for initialization
	void Start () {
        CreateGrid();   
	}

    private void CreateGrid() {
        float rowOffset = this.gameObject.transform.position.z;
        float colOffset = this.gameObject.transform.position.x;

        // Creates a Child element to store all the tiles
        GameObject tiles = Instantiate(new GameObject());
        tiles.name = TILES_NAME;
        tiles.transform.parent = this.transform;


        for (int i = 0; i < this.rows; i++) {
            rowOffset = this.gameObject.transform.position.z + (this.offset * i);
            for(int j = 0; j < this.cols; j++) {
                colOffset = this.gameObject.transform.position.x + (this.offset * j);
                GameObject child = (GameObject) Instantiate(tilePrefab, new Vector3(colOffset,
                    this.gameObject.transform.position.y, rowOffset), Quaternion.identity);

                child.transform.parent = tiles.transform;
            }
        }

    }
}
