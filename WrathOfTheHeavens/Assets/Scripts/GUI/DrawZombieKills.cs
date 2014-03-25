using UnityEngine;
using System.Collections;

public class DrawZombieKills : DrawText {
	
	//Draw the nubmer of zombie kills as text
	protected override string GetText() {
		GameState state = GameObject.FindGameObjectWithTag("Global").GetComponent<GameState>();
		return state.zombieKills.ToString ();
	}
}
