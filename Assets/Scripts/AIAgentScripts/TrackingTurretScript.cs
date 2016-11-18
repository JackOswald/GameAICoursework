using UnityEngine;
using System.Collections;

public class TrackingTurretScript : MonoBehaviour {

	public float speed = 3;
	public GameObject turret1;

	Vector3 lastPosition = Vector3.zero;
	Quaternion lookAtRotation;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if (lastPosition != turret1.transform.position)
		{
			lastPosition = turret1.transform.position;
			lookAtRotation = Quaternion.LookRotation (lastPosition - transform.position);
		}

		if (transform.rotation != lookAtRotation)
		{
			transform.rotation = Quaternion.RotateTowards (transform.rotation, lookAtRotation, speed * Time.deltaTime);
		}

	}

	bool GetTarget (GameObject target)
	{
		if (target) 
		{
			return false;
		}

		turret1 = target;

		return true;
	}
}
