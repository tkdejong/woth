﻿using UnityEngine;
using System.Collections;

public class Town : MonoBehaviour {
	[HideInInspector]
	public int hitpoints = 3;
	public int maxHitpoints = 3;
	Transform wall;

	//Health levels where the wall sprite changes
	public int[] wallChangingHealthLevels;
	private int nextHealthLevel = 0;

	// Use this for initialization
	void Start () {
		hitpoints = maxHitpoints;
		wall = transform.FindChild("TownWall");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Called when a zombie has reached the town and attacks it
	public void Attacked() {
		hitpoints --;
		if (hitpoints <= 0) {
			Debug.Log ("YOU LOSE - the town is destroyed");
		}
		//Show the visual effects of the town getting closer to destruction
		if (hitpoints <= wallChangingHealthLevels[nextHealthLevel]) {
			//Message the wall to become more crubled
			wall.SendMessage("NextSprite");
		}
	}
}
//""