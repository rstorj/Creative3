using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLight : MonoBehaviour
{
	public GameObject LightBeam;
	private Vector3 lightSpot;
	public Terrain myTerrain;
	public int landHealth = 0;
	private int NewHealth = 0;
	private int MaxHealth = 100;
	private int MinHealth = 0;

	// Update is called once per frame
	void Update ()
	{
		if (NewHealth >= 0) {
			landHealth = NewHealth; 
		}
		/*FOR TESTING PURPOSES*/
		/*REMOVE BEFORE FINAL BUILD*/
		if (Input.GetKeyDown ("p")) {
			//revert the land to original state
			UpdateTerrainTexture (myTerrain.terrainData, 0, 1);
		}
	}
	//CREATES SPOT OF LIGHT ON TERRAIN
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.name == "WaterDrop(Clone)") {

			lightSpot.x = (other.transform.position.x);
			lightSpot.y = (0);
			lightSpot.z = (other.transform.position.z);
			Destroy (other.gameObject);

			GameObject light = Instantiate (LightBeam) as GameObject;
			light.transform.position = lightSpot;

			//Make terrain more green
			UpdateTerrainTexture (myTerrain.terrainData, 1, 0);
			NewHealth++;
			//Debug.Log (NewHealth);
			//myTerrain.terrainData.wavingGrassTint = ;
		}

	}
	//CHANGES TERRAIN COLORS
	static void UpdateTerrainTexture (TerrainData terrainData, int textureNumberFrom, int textureNumberTo)
	{
		//get current paint mask
		float[, ,] alphas = terrainData.GetAlphamaps (0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
		// make sure every grid on the terrain is modified
		//Debug.Log ("AlphampaWidth: " + terrainData.alphamapWidth + " " + "AlphamapHeight: " + terrainData.alphamapHeight);
		for (int i = 312; i < 712/*terrainData.alphamapWidth*/; i++) {
			for (int j = 312; j < 712/*terrainData.alphamapHeight*/; j++) {
				//for each point of mask do:
				//paint all from old texture to new texture (saving already painted in new texture)
				alphas [i, j, textureNumberTo] = Mathf.Max (alphas [i, j, textureNumberFrom], alphas [i, j, textureNumberTo]);
				//set old texture mask to zero
				alphas [i, j, textureNumberFrom] = 0f;
			}
		}

		// apply the new alpha
		terrainData.SetAlphamaps (0, 0, alphas);
	}

}


//helpful resource for modifying terrain texture in runtime
//https://answers.unity.com/questions/285816/change-terrain-texture-and-tree-at-runtime.html
//	if (Input.GetKeyDown (KeyCode.Space)) {
//switch all painted in texture 1 to texture 2
//UpdateTerrainTexture (myTerrain.terrainData, 1, 2);





