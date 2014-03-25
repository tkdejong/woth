using UnityEngine;
using System.Collections;

/*
 * Keeps track of global variables that determine the state of the game
 */
public class GameState : MonoBehaviour {

	public int zombieKills = 0;

	//Game duration in seconds
	public float gameDuration = 600f;
	[HideInInspector]
	public float timeLeft {
		get {
			return startTime + gameDuration - Time.time;
		}
	}

	public float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}

}
