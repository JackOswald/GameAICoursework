using UnityEngine;
using System.Collections;

public class HealthPackSpawnScript : MonoBehaviour {

	public GameObject healthPack;
	public Transform spawns;
	Transform[] spawnPoints;
	public float spawnTime = 5.0f;

	// Use this for initialization
	void Start () {

		spawnPoints = new Transform[spawns.childCount];
		int i = 0;
		foreach (Transform theSpawnPoint in spawns) 
		{
			spawnPoints[i] = theSpawnPoint;
			i++;
		}

		InvokeRepeating ("SpawnHealthPack", spawnTime, spawnTime);

	}

	// Update is called once per frame
	void Update () 
	{

	}


	void SpawnHealthPack()
	{
		int spawnChoice;
		spawnChoice = Random.Range (0,spawnPoints.Length);
		Instantiate (healthPack, spawnPoints[spawnChoice].position, spawnPoints[spawnChoice].rotation );
	}
}