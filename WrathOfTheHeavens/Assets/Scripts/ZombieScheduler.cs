using UnityEngine;
using System.Collections;

public class ZombieScheduler : MonoBehaviour {
	public AnimationCurve speed = AnimationCurve.Linear (0f, 0.3f, 600f, 5f);
	public AnimationCurve spawnInterval = AnimationCurve.Linear (0f, 7f, 600f, .5f);

	public float minSpawnY = -3.3f;
	public float maxSpawnY = 3.3f;
	public float spawnX = -6f;

	public GameObject templateZombie;

	float startTime;
	float lastSpawn;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		lastSpawn = startTime;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Speed = " + speed.Evaluate (Time.time - startTime) + " at time " + (Time.time - startTime));
		if (Time.time - lastSpawn >= spawnInterval.Evaluate (lastSpawn)) {
			lastSpawn = Time.time;
			SpawnZombie(speed.Evaluate(Time.time));
		}
	}

	//Spawns a zombie with a certain speed at a random y-pos on the left of the screen
	void SpawnZombie(float speed) {
		float y = Random.Range (minSpawnY, maxSpawnY);
		Transform zombie = ((GameObject) Instantiate (templateZombie)).transform;

		zombie.position = new Vector2 (spawnX, y);
		zombie.GetComponent<ZombieMovement> ().speed = speed;
	}

}