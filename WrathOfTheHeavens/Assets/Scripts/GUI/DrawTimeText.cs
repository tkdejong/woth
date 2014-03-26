using UnityEngine;
using System.Collections;

public class DrawTimeText : DrawText {

	//Show the remaining seconds as text
	protected override string GetText() {
		GameState state = GameObject.FindGameObjectWithTag("Global").GetComponent<GameState>();
		return "Survived for " + Mathf.RoundToInt(state.timeSurvived).ToString() + " sec";
	}
}
