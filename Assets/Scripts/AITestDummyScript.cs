using UnityEngine;
using System.Collections;

public class AITestDummyScript : MonoBehaviour {

	private Transform _transform;

	public Transform target;
	public GameObject aiAgent;

	public int maxDistance = 2;

	public float lastFired;
	public float fireRate = 1.0f;
	public GameObject projectile;


	void Awake()
	{
		_transform = transform;
	}


	// Use this for initialization
	void Start () 
	{ 
		aiAgent = GameObject.FindGameObjectWithTag ("Agent");
		target = aiAgent.transform;

	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.DrawLine (target.position, _transform.position, Color.magenta);
		Shoot ();

	}

	void OnTriggerEnter2D(Collider2D col)
	{

	}


	void Shoot()
	{
		if (Time.time - lastFired > 1 / fireRate)
		{
			lastFired = Time.time;
			//GameObject shot = Instantiate(projectile, transform.position + (aiAgent.transform.position - transform.position).normalized, Quaternion.LookRotation(aiAgent.transform.position - transform.position)) as GameObject;
			GameObject shot = Instantiate(projectile, transform.position + (aiAgent.transform.position - transform.position).normalized, Quaternion.LookRotation(aiAgent.transform.position - transform.position)) as GameObject;
			shot.GetComponent<Rigidbody2D>().AddForce(((Vector3)(aiAgent.transform.position - shot.transform.position)).normalized * 50);
			shot.transform.position = Vector2.Lerp (shot.transform.position, aiAgent.transform.position, Time.time);
			//shot.transform.position = aiAgent.transform.position;
		}

	}

	void LookAt()
	{
		Vector3 dir = aiAgent.transform.position - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
	}
		
}
