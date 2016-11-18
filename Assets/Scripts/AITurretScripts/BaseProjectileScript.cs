using UnityEngine;
using System.Collections;

public abstract class BaseProjectileScript : MonoBehaviour {

	public float speed = 5.0f;

	public abstract void FireProjectile1 (GameObject turret, GameObject aiAgent, int damage);

	public abstract void FireProjectile2 (GameObject aiAgent, GameObject turret, int damage);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
