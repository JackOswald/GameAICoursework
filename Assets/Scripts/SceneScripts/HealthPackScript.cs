using UnityEngine;
using System.Collections;

public class HealthPackScript : MonoBehaviour {

	public int healAmount;
	public AIScript aiScript;


	// Use this for initialization
	void Start () 
	{
		aiScript = GameObject.FindGameObjectWithTag("Agent").GetComponent<AIScript> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Agent") 
		{
			aiScript.AddHealth (healAmount);
			//Destroy (this.gameObject);
		}

		if (col.gameObject.tag == "HealthPack") 
		{
			//Destroy (col.gameObject);
		}
	}
}
