using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
	private GameObject theTerrain;
	private int terrainHealth;

	// Use this for initialization
	void Start ()
	{
		theTerrain = GameObject.Find ("Terrain_0_0-20181102-101609");
		terrainHealth = theTerrain.GetComponent<MakeLight> ().landHealth;
		//Debug.Log (terrainHealth);

	}
	
	// Update is called once per frame
	void Update ()
	{
		terrainHealth = theTerrain.GetComponent<MakeLight> ().landHealth;
		//Debug.Log (terrainHealth);
	
	}
}
