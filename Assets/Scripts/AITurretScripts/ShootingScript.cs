using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingScript : MonoBehaviour {

	public float fireRate = 1.0f; //0.7 optimal
	public float lastFired;
	public bool range;
	public int damage;
	public bool randomFireRate = false;
	public GameObject projectile;
	public GameObject projectileSpawn;
	public GameObject aiAgent;

	public AITurretScript aiTurretScript;

	// Use this for initialization
	void Start () 
	{
		range = false;
		aiTurretScript = GetComponentInParent<AITurretScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (range == true) 
		{
			if (randomFireRate == true)
			{
				float random = Random.Range (0.7f, 3.1f);
				fireRate = random;
				randomFireRate = false;
			}
			SpawnProjectile ();
		}
	}

	void SpawnProjectile()
	{
		if (Time.time - lastFired > 1 / fireRate) 
		{
			lastFired = Time.time;
			GameObject proj = Instantiate (projectile, projectileSpawn.transform.position, Quaternion.Euler (projectileSpawn.transform.forward)) as GameObject;
			proj.GetComponent<BaseProjectileScript> ().FireProjectile1 (projectileSpawn, aiAgent, damage);
		}
			
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Agent") 
		{
			aiTurretScript.regeneration = 0.0f;
			randomFireRate = true;
		}
			
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Agent")
		{
			range = true;
			//randomFireRate = true;
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Agent") 
		{
			range = false;
			aiTurretScript.regeneration = 1.0f;
			randomFireRate = false;
		}


	}


}
