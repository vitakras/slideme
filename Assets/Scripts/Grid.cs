using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour {

    public int xSize, ySize;

    private Vector3[] vertices;
    private Mesh mesh;
    private float xOffset, yOffSet;

	// Use this for initialization
	void Start () {
	
	}

    void Awake () {
        Generate();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos() {
        if (this.vertices == null) { // prevent from throwing errors in editor mode
            return; 
        }

        Gizmos.color = Color.black;
        for(int i = 0; i < this.vertices.Length; i++) {
            Gizmos.DrawSphere(this.vertices[i], 0.1f);
        }
    }

    private void Generate() {
        // Variable declerations 
        int size = (this.xSize + 1) * (this.ySize + 1);

      //  this.xOffset = this.xSize / 2;
    //    this.yOffSet = this.ySize / 2;
      //  Debug.Log("Grid Offset:" + new Vector3(xOffset, 0, yOffSet));


        GetComponent<MeshFilter>().mesh = this.mesh = new Mesh();
        this.mesh.name = "Procedural Grid";

        // Creates vertices
        this.vertices = new Vector3[size];
        Vector2[] uv = new Vector2[size];
        Vector4[] tangenets = new Vector4[size];
        Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
        for (int i = 0, y = 0; y <= ySize; y++) {
            for (int x = 0; x <= xSize; x++, i++) { // increment i here since its a 1D array
                vertices[i] = new Vector3(x, 0, y);
                uv[i] = new Vector2((float)x / this.xSize, (float)y / ySize);
                tangenets[i] = tangent;
            }
        }
        this.mesh.vertices = vertices;
        this.mesh.uv = uv;
        this.mesh.tangents = tangenets;

        // Creates faces
        int[] triangles = new int[this.xSize * this.ySize * 6]; // each traingle has 3 vertices and each cube has 2 triangles 2 * 3 = 6
        for (int ti = 0, vi = 0, y = 0; y < this.ySize; y++, vi++) {
            for (int x = 0; x < this.xSize; x++, ti += 6, vi++) {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + this.xSize + 1;
                triangles[ti + 5] = vi + this.xSize + 2;
            }
        }
        this.mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }
}
