using UnityEngine;
using System.Collections;

public class AIAgentProjectileScript : MonoBehaviour {

	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "StaticAI1") 
		{
			Destroy (this.gameObject);
			//Debug.Log ("Hit " + col.ToString ());
		}
	}
}
