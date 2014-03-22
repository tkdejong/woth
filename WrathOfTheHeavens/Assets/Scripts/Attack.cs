using UnityEngine;
using System.Collections.Generic;

public class Attack : MonoBehaviour {
	//The enemies that are currently colliding with the cursors collider
	List<Transform> underCursor;
	//The lightning bolt that is spawned on attack
	public GameObject lightningBolt;

	// Use this for initialization
	void Start () {
		underCursor = new List<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		//Check if attack is executed
		if (Input.GetMouseButtonDown(0)) {
			//Display the effects of the attack on the targeted location
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = 0;
			Transform lightning = ((GameObject) Instantiate (lightningBolt)).transform;
			lightning.position = pos;

			//Keep track of the zombies that should be removed,
			//  without modifying the list in mid-loop
			List<Transform> killedZombies = new List<Transform>();

			foreach (Transform zombie in underCursor)
			{
				//Send the zombie a message that it has been hit
				zombie.SendMessage("Attacked");
				killedZombies.Add(zombie);
			}
			foreach (Transform killed in killedZombies)
			{
				underCursor.Remove (killed);
			}
		}
	}

	//Keep track of what enemies are currently under the cursor 
	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<Zombie> () != null) {
			underCursor.Add (other.transform);
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		underCursor.Remove (other.transform);
	}
}
//""