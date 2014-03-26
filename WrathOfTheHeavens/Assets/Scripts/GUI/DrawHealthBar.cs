using UnityEngine;
using System.Collections;

public class DrawHealthBar : DrawBar {
	//The town which health is displayed
	public Transform townObject;

	//Use the percentage of wall health as the bar percentage
	protected override float GetBarPercentage() {
		Town town = townObject.GetComponent<Town>();
		return (float)town.hitpoints / (float)town.maxHitpoints;
	}

}
//""