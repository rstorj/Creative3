using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBucket : MonoBehaviour
{
	private bool filled;
	public GameObject bucketContents;
	private List<GameObject> bucketInventory = new List<GameObject> ();


	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "WaterDrop") {
			Debug.Log ("fill 'er up");
			other.gameObject.transform.parent = gameObject.transform;
			bucketInventory.Add (other.gameObject);

		
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "WaterDrop") {
			Debug.Log ("empty out");
			bucketInventory.Remove (other.gameObject);
		}
	}

	void Update ()
	{
		if (bucketInventory.Count >= 1) {
			filled = true;
			bucketContents.SetActive (true);
		} 
		if (bucketInventory.Count == 0) {
			filled = false;
			bucketContents.SetActive (false);
		}
	}
}
