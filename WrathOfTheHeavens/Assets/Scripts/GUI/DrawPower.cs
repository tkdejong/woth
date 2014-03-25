using UnityEngine;
using System.Collections;

public class DrawPower : DrawText {
	
	//Draw the power of the lightning as text
	protected override string GetText() {
		GameState state = GameObject.FindGameObjectWithTag("Global").GetComponent<GameState>();
		int power = (int) ((state.cooldown / state.maxCooldown) * 100f);
		return power.ToString () + "%";
	}
}
