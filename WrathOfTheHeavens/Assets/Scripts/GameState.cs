using UnityEngine;
using System.Collections;

/*
 * Keeps track of global variables that determine the state of the game
 */
public class GameState : MonoBehaviour {

	public int zombieKills = 0;
	public Transform town;

	//Lightning cooldown in seconds
	public static float maxCooldown = 2f; 
	public float cooldown = maxCooldown;

	//Game duration in seconds
	public float gameDuration = 600f;
	[HideInInspector]
	public float timeLeft {
		get {
			return startTime + gameDuration - Time.time;
		}
	}

	public float startTime;

	//If this string is set, the game is finished and the message should be displayed
	private string gameFinishedMessage;
	//Style of the displayed message on game-over
	private GUIStyle style;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}

	void Update () {
		if (timeLeft <= 0f) {
			EndGame("Congratualations!\nYou survived for the entire duration!");
		}
		else if (town.GetComponent<Town>().hitpoints <= 0) {
			EndGame("The town has been destroyed!\nYou survived for " + Mathf.RoundToInt(Time.time - startTime) + " seconds.");
		}

		IncreaseCooldown();
	}

	//End the game, pausing everything and displaying the given message on the screen
	void EndGame(string message) {
		Time.timeScale = 0f;
		gameFinishedMessage = message;
	}

	//Sets the style of the game-over text
	private void setStyle() {
		if (style == null) {
			style = new GUIStyle( GUI.skin.box );		
			style.fontSize = 24;
			style.alignment = TextAnchor.MiddleCenter;
			//style.normal.textColor = ;
		}
	}	

	void OnGUI () {
		//If the game has finished, display the message
		if (gameFinishedMessage != null) {
			setStyle ();
			float w = 600;
			float h = 150;
			GUI.Box(new Rect(Screen.width/2 - w/2, Screen.height/2 - h/2, w, h), gameFinishedMessage, style);
		}
	}

	//Increases the cooldown by the seconds passed since last frame
	private void IncreaseCooldown() {
		cooldown += Time.deltaTime;
		if(cooldown >= maxCooldown) cooldown = maxCooldown;
	}

}
//""