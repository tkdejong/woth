using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//Move to the mouse point in world coordinates
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pos.z = 0f;
		transform.position = pos;
	}
}
