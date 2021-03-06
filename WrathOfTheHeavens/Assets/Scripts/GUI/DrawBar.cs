﻿using UnityEngine;
using System.Collections;

public class DrawBar : MonoBehaviour {
	//The bar is scaled to be as big on the screen as the sprite
	//Borders of the bar, in relative coordinates from the sprite(s top left corner)
	public float barLeft = 0.0934f;
	public float barRight = 5.91f;
	public float barTop = -0.103f;
	public float barBottom = -0.71f;
	//The color of the bar
	public Color barColor = new Color(1,0,0,1f);

	//The screen coordinates of the bar can be stored after they have been calculated
	//If the position is static, the topleft and bottomright are calculated only once,
	//  instead of every frame.
	public bool staticPosition;
	private Vector3 topLeft;
	private Vector3 bottomRight;
	
	private Texture2D barTexture = null;
	//private ZombieScheduler scheduler;

	void Start() {
		//scheduler = GameObject.FindGameObjectWithTag ("Global").GetComponent<ZombieScheduler>();

		if (staticPosition) {
			CalculateCoordinates ();
		}
	}

	//Sets the texture of the bar
	private void setTexture() {
		if (barTexture == null) {
			//Make a texture that is just one simple color (this is absurdly difficult and weird in Unity)
			//This HAS to be called from within OnGUI
			barTexture = new Texture2D(1, 1);
			barTexture.SetPixel(0,0, barColor);
			barTexture.Apply();
		}
	}

	//Calculates the on-screen drawing coordinates for the bar,
	//  from the current transform of the sprite and the given relative bounds (l/r/t/b).
	private void CalculateCoordinates() {
		//Calculate the extents of the bar in world coordinates
		Vector3 topLeftWorld = transform.TransformPoint (new Vector3 (barLeft, barTop, 0f));
		Vector3 bottomRightWorld = transform.TransformPoint (new Vector3(barRight, barBottom, 0f));
		
		//Change to screen coordinates as required for GUI drawing
		topLeft = Camera.main.WorldToScreenPoint(topLeftWorld);
		topLeft.y = Screen.height - topLeft.y;
		bottomRight = Camera.main.WorldToScreenPoint(bottomRightWorld);
		bottomRight.y = Screen.height - bottomRight.y;
	}

	//Draws the bar on screen, fitting it in the sprite and scaling it
	//  according to the game time that is left.
	void OnGUI() {
		setTexture ();
		if (!staticPosition) {
			CalculateCoordinates();
		}

		//Draw the rectange for a certain percentage of the width (showing how full the bar is)
		float width = GetBarPercentage() * (bottomRight.x - topLeft.x);
		GUI.DrawTexture(new Rect (topLeft.x, topLeft.y, width, bottomRight.y - topLeft.y), barTexture);
	}

	//Subclasses can decide what the bar percentage and content is based on
	protected virtual float GetBarPercentage() {
		return 1f;
	}

}
//""