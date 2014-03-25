using UnityEngine;
using System.Collections;

public class DrawTimeBar : DrawBar {

	//Use the percentage of time remaining as bar percentage
	protected override float GetBarPercentage() {
		GameState state = GameObject.FindGameObjectWithTag("Global").GetComponent<GameState>();
		return state.timeLeft / state.gameDuration;
	}

}
//""