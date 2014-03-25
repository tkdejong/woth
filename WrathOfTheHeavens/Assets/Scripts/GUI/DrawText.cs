using UnityEngine;
using System.Collections;

public class DrawText : MonoBehaviour {
	//The text position is scaled along with the sprite
	//Position of the text in relative coordinates from the sprite(s top left corner)
	public float textX = 1.3f;
	public float textY = -0.25f;

	//Text style settings
	public int fontSize = 12;
	public bool bold;
	public Color textColor = new Color(0f, 0f, 0f, 1f);

	//Dimensions of the label in which the text is displayed, in screen pixels
	// .. these may not be very important ..
	public float textScreenWidth = 150f;
	public float textScreenHeight = 80f;

	//The color of the bar
	//public Color barColor = new Color(1,0,0,1f);
	
	//The screen coordinates of the text can be stored after they have been calculated
	//If the position is static, this is calculated only once, instead of every frame.
	public bool staticPosition;
	private Vector3 textPos;

	private GUIStyle style;
	
	void Start() {
		if (staticPosition) {
			CalculateCoordinates ();
		}
	}
	
	//Sets the style of the text
	private void setStyle() {
		if (style == null) {
			style = new GUIStyle( GUI.skin.label );
			style.clipping = TextClipping.Overflow;
		
			style.fontSize = fontSize;
			if (bold) {
				style.fontStyle = FontStyle.Bold;
			}
			style.normal.textColor = textColor;
		}
	}


	//Calculates the on-screen drawing coordinates for the bar,
	//  from the current transform of the sprite and the given relative bounds (l/r/t/b).
	private void CalculateCoordinates() {
		//Calculate the extents of the bar in world coordinates
		Vector3 textPosWorld = transform.TransformPoint (new Vector3 (textX, textY, 0f));
		
		//Change to screen coordinates as required for GUI drawing
		textPos = Camera.main.WorldToScreenPoint(textPosWorld);
		textPos.y = Screen.height - textPos.y;
	}
	
	//Draws the bar on screen, fitting it in the sprite and scaling it
	//  according to the game time that is left.
	void OnGUI() {
		setStyle ();
		if (!staticPosition) {
			CalculateCoordinates();
		}

		//Draw the text on the calculated position
		GUI.Label (new Rect(textPos.x, textPos.y, textScreenWidth, textScreenHeight), GetText (), style);
	}
	
	//Subclasses can decide what the text should be
	protected virtual string GetText() {
		return  "100";
	}
}
//""