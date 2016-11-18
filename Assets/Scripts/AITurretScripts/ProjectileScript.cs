using UnityEngine;
using System.Collections;

public class ProjectileScript : BaseProjectileScript {

	Vector3 direction;

	bool fired;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (fired)
		{
			transform.position += direction * (speed * Time.deltaTime);
		}
	}

	public override void FireProjectile1 (GameObject turret, GameObject aiAgent, int damage)
	{
		if (turret && aiAgent) 
		{
			direction = (aiAgent.transform.position - turret.transform.position).normalized;
			fired = true;
		}
	}

	public override void FireProjectile2 (GameObject aiAgent, GameObject turret, int damage)
	{
		if (aiAgent && turret) 
		{
			direction = (turret.transform.position - aiAgent.transform.position).normalized;
			fired = true;
		}
	}
}
