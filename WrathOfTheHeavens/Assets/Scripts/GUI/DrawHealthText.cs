using UnityEngine;
using System.Collections;

public class DrawHealthText : DrawText {
	//The town which health is displayed
	public Transform townObject;

	//Draw the percentage of town health as text
	protected override string GetText() {
		Town town = townObject.GetComponent<Town>();
		return Mathf.RoundToInt(100 * town.hitpoints / town.maxHitpoints).ToString() + "%";
	}
}
