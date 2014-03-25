using UnityEngine;
using System.Collections;

public class DrawHealthBar : DrawBar {
	//The town which health is displayed
	public Transform townObject;

	//Use the percentage of wall health as the bar percentage
	protected override float GetBarPercentage() {
		Town town = townObject.GetComponent<Town>();
		return town.hitpoints / town.maxHitpoints;
	}
	//Show the remaining health percentage
	protected override GUIContent GetBarContent() {
		Town town = townObject.GetComponent<Town>();
		return new GUIContent(Mathf.RoundToInt(100 * town.hitpoints / town.maxHitpoints).ToString() + "%");
	}

}
//""