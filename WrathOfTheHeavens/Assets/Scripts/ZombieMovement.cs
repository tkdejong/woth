using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour {
	public float speed;
	public float goalX;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(speed, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (new Vector2(speed * Time.deltaTime, 0f));
		if (transform.position.x >= goalX) {
			Debug.Log ("Zombie reached the town!");
			Destroy(gameObject);
		}
	}
}
//""