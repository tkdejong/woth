using UnityEngine;
using System.Collections;

public class ZombieScheduler : MonoBehaviour {
	public AnimationCurve spawnInterval1 = AnimationCurve.Linear (0f, 7f, 600f, .5f);
	public AnimationCurve spawnInterval2 = AnimationCurve.Linear (0f, 14f, 600f, 1.0f);
	public AnimationCurve spawnInterval3 = AnimationCurve.Linear (0f, 21f, 600f, 1.5f);
	
	public float minSpawnY = -3.3f;
	public float maxSpawnY = 3.3f;
	public float spawnX = -6f;
	
	public GameObject templateZombie;
	
	float startTime;
	float lastSpawn1, lastSpawn2, lastSpawn3;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		lastSpawn1 = 0;
		lastSpawn2 = 0;
		lastSpawn3 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Speed = " + speed.Evaluate (Time.time - startTime) + " at time " + (Time.time - startTime));
		
		//Zombie Type 1
		if (Time.time - lastSpawn1 >= spawnInterval1.Evaluate (lastSpawn1)) {
			lastSpawn1 = Time.time;
			SpawnZombie(0.6f);
		}
		
		//Zombie Type 2
		if (Time.time - lastSpawn2 >= spawnInterval2.Evaluate (lastSpawn2)) {
			lastSpawn2 = Time.time;
			SpawnZombie(2.0f);
		}
		
		//Zombie Type 1
		if (Time.time - lastSpawn3 >= spawnInterval3.Evaluate (lastSpawn3)) {
			lastSpawn3 = Time.time;
			SpawnZombie(4.0f);
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
