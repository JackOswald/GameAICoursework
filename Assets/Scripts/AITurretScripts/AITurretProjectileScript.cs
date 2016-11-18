using UnityEngine;
using System.Collections;

public class AITurretProjectileScript : MonoBehaviour {

	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Agent") 
		{
			col.GetComponent<AIScript> ().TakeDamage (damage);
			Destroy (this.gameObject);
			//Debug.Log("Agent has taken " + damage + " damage" );
		}
	}
}
