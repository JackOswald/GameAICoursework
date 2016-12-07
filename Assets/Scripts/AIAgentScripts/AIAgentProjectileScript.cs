using UnityEngine;
using System.Collections;

public class AIAgentProjectileScript : MonoBehaviour {

	public AITurretScript aiTurretScript;

	public int damage;

	// Use this for initialization
	void Start () 
	{
		aiTurretScript = GameObject.FindGameObjectWithTag("StaticAI1").GetComponent<AITurretScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "StaticAI1") 
		{
			aiTurretScript.TakeDamage (10);
			Destroy (this.gameObject);
			//Debug.Log ("Hit " + col.ToString ());
		}
	}
}
