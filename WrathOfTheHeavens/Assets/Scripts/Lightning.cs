using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {
	//Time over which the sprite goes from opaque to completely transparent (in seconds)
	public float fadeTime;
	//How long before this object removes itself
	public float lifeTime;

	SpriteRenderer sprite;
	//Time when the object is created
	float creationTime;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		creationTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//Slowly decrease the sprites alpha channel (transparency) from 1 to 0
		Color color = sprite.color;
		color.a -= Time.deltaTime/fadeTime;
		sprite.color = color;

		//See if it is time to self-destruct
		if (Time.time > creationTime + lifeTime) {
			Destroy (gameObject);
		}
	}
}
