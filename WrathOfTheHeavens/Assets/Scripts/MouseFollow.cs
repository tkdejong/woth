using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
	public float followSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Move to the mouse point in world coordinates
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pos.z = 0f;
		transform.position = pos;
		//Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//Vector3 transPos = transform.position;
		//rigidbody2D.velocity = followSpeed * (new Vector2(mousePos.x, mousePos.y) - new Vector2(transPos.x, transPos.y));

	}
}
