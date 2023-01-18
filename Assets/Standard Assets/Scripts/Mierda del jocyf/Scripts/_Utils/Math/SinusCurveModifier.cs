using UnityEngine;

public class SinusCurveModifier : MonoBehaviour {

    public float scale = 10.0f;
	public float speed = 1.0f;
	public bool HasMeshCollider = false;

    private Vector3[] baseHeight;

    private MeshCollider MeshC = null;
    MeshFilter meshF = null;
    Mesh mesh = null;


    void Start()
    {
        MeshC = GetComponent<MeshCollider>();
        meshF = GetComponent<MeshFilter>();
        mesh = meshF.mesh;

        baseHeight = mesh.vertices;
    }

    void Update ()
    {
	   if(baseHeight == null) baseHeight = mesh.vertices; // Sentencia de seguridad

       Vector3[] vertices = new Vector3[baseHeight.Length];
	   for (int i=0;i<vertices.Length;i++)
       {
	      Vector3 vertex = baseHeight[i];
	      vertex.y += Mathf.Sin(Time.time * speed + baseHeight[i].y + baseHeight[i].z) * (scale*0.5f)
	                + Mathf.Sin(Time.time * speed + baseHeight[i].y + baseHeight[i].x) * (scale*0.5f);
	      vertices[i] = vertex;
	   }

	   mesh.vertices = vertices;
	   mesh.RecalculateNormals();

	   if(HasMeshCollider)
       {
	   		MeshC.sharedMesh = mesh;
	   }
	}
}
