using UnityEngine;
using System.Collections;

public class PlayerTestScript : MonoBehaviour {

	public float speed = 5.0f;

	public float attackInRange = 1.0f;

	public GameObject aiAgent;
	public Transform target1;

	// Use this for initialization
	void Start () 
	{
		aiAgent = GameObject.FindGameObjectWithTag ("Agent");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveToAI ();
		
	}

	public void MoveToAI()
	{
		transform.LookAt (target1.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

		if (Vector3.Distance (transform.position, target1.position) > attackInRange) 
		{
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}

	}

		
}
