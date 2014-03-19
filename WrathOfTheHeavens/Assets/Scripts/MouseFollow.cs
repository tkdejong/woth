using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pos.z = 0f;
		transform.position = pos;
	}
}
