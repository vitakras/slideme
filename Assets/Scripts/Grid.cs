using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Grid : MonoBehaviour {

	public GameObject [] tiles = new GameObject[2];
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
				GameObject child = (GameObject) Instantiate(PickTile(i, j), new Vector3(colOffset,
                    this.gameObject.transform.position.y, rowOffset), Quaternion.identity);

                child.transform.parent = tiles.transform;
            }
        }
    }

	private GameObject PickTile(int row, int col) {
		if ((row % 2) == 0) {
			if ((col % 2) == 0) {
				return this.tiles[0];
			} else {
				return this.tiles[1];
			}
		} else {
			if ((col % 2) == 0) {
				return this.tiles[1];
			} else {
				return this.tiles[0];
			}
		}
	}
}
