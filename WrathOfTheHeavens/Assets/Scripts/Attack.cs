using UnityEngine;
using System.Collections.Generic;

public class Attack : MonoBehaviour {
	//The enemies that are currently colliding with the cursors collider
	public List<Transform> underCursor;

	// Use this for initialization
	void Start () {
		underCursor = new List<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			foreach (Transform zombie in underCursor)
			{
				//Send the zombie a message that it has been hit
				zombie.SendMessage("Attacked");
			}
		}
	}

	//Keep track of what enemies are currently under the cursor 
	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<Zombie> () != null) {
			underCursor.Add (other.transform);
		}
	}
	void OnTriggerExit(Collider other) {
		underCursor.Remove (other.transform);
	}
}
