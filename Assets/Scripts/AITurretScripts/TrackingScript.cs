using UnityEngine;
using System.Collections;

public class TrackingScript : MonoBehaviour {

	public float speed = 3;
	public GameObject aiAgent;

	Vector3 lastPosition = Vector3.zero;
	Quaternion lookAtRotation;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (lastPosition != aiAgent.transform.position)
		{
			lastPosition = aiAgent.transform.position;
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

		aiAgent = target;

		return true;
	}
}
