using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public AudioClip deathSound;

	//Called when the zombie has been hit by the players attack
	void Attacked () {
		Debug.Log ("Zombie was killed!");
		GameObject.FindGameObjectWithTag("Global").GetComponent<GameState>().zombieKills ++;
		gameObject.audio.Play ();		
		AudioSource.PlayClipAtPoint (deathSound, Camera.main.transform.position, 0.8f);
		Destroy(gameObject);
	}
}
