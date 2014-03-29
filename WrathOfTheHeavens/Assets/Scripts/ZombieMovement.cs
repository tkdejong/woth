using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour {
	public float speed;
	public float goalX;
	Transform town;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(speed, 0f);
		town = GameObject.FindWithTag("Town").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (new Vector2(speed * Time.deltaTime, 0f));
		if (transform.position.x >= goalX) {
			Debug.Log ("Zombie reached the town!");
			//Notify the town that it has been attacked
			town.SendMessage("Attacked");
			AudioSource.PlayClipAtPoint (gameObject.GetComponent<Zombie>().deathSound, Camera.main.transform.position, 0.8f);
			Destroy(gameObject);
		}
	}
}
//""