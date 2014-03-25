using UnityEngine;
using System.Collections;

public class DrawTimeBar : DrawBar {

	//Use the percentage of time remaining as bar percentage
	protected override float GetBarPercentage() {
		GameState state = GameObject.FindGameObjectWithTag("Global").GetComponent<GameState>();
		return state.timeLeft / state.gameDuration;
	}
	//Show the remaining seconds
	protected override GUIContent GetBarContent() {
		GameState state = GameObject.FindGameObjectWithTag("Global").GetComponent<GameState>();
		return new GUIContent(Mathf.RoundToInt(state.timeLeft).ToString() + " sec");
	}

}
//""