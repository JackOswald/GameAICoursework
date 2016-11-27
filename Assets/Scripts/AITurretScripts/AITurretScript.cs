using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AITurretScript : MonoBehaviour {

	public float maxHealth = 100;
	public float currentHealth;

	public float regeneration;

	public Text healthText;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
		InvokeRepeating ("RegenHealth", 0.0f, 1.0f / regeneration);
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateHealth ();
		//Death ();
	}

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;

		if (currentHealth > maxHealth) 
		{
			currentHealth = maxHealth;
		}

		UpdateHealth ();
	}

	public void Death()
	{
		if (currentHealth <= 0) 
		{
			Destroy (this.gameObject);
		}
	}

	void RegenHealth()
	{
		if (currentHealth < maxHealth) 
		{
			currentHealth += 1.0f;
		}
	}
			
	void UpdateHealth()
	{
		healthText.text = "Turret Health: " + currentHealth.ToString ();
	}
}
