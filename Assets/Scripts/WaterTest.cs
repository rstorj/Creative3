using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTest : MonoBehaviour
{
	List<GameObject> waterList;
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < 10; i++) {
			GameObject drop = GameObject.Find ("drop(Clone)");
			waterList.Add (drop);

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void renderMesh ()
	{

		Mesh mesh = ((MeshFilter)GetComponent ("MeshFilter")).mesh;


		//mesh.vertices = fv;
		//mesh.uv = fuv;
//		mesh.triangles = ft;	
//		mesh.normals = fn;

		/*For Disco Ball Effect*/
		mesh.RecalculateNormals ();	


	}
}
