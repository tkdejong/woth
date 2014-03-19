using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Called when the zombie has been hit by the players attack
	void Attacked () {
		Debug.Log ("Zombie was killed!");
		Destroy(gameObject);
	}
}
