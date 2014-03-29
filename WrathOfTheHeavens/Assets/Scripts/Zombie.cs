using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public AudioClip deathSound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Called when the zombie has been hit by the players attack
	void Attacked () {
		Debug.Log ("Zombie was killed!");
		GameObject.FindGameObjectWithTag("Global").GetComponent<GameState>().zombieKills ++;
		gameObject.audio.Play ();		
		AudioSource.PlayClipAtPoint (deathSound, Camera.main.transform.position, 0.8f);
		Destroy(gameObject);
	}
}
