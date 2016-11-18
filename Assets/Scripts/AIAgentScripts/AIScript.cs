using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AIScript : MonoBehaviour {

	public float currentHealth;
	public float maxHealth = 100;

	public float currentAmmo;
	public float ammoCapacity = 5;

	public float speed = 5.0f;
	public float attackInRange = 1.0f;

	public GameObject[] targets;
	public GameObject enemyChoice;

	public Text healthText;
	public Text ammoText;

	public GameObject projectile;
	public GameObject projectileSpawn;
	public GameObject turret1;
	public int damage;
	public bool inRange;

	public float fireRate = 1.0f;
	public float lastFired;

	public Transform safeZone;

	public UtilityAI utilityAI;

	// Use this for initialization
	void Start () 
	{
		utilityAI = GetComponent<UtilityAI> ();

		//aiAgent = GameObject.FindGameObjectWithTag ("Agent");
		currentHealth = maxHealth;

		currentAmmo = ammoCapacity;

		inRange = false;

		SelectRandomEnemy ();

	}

	// Update is called once per frame
	void Update () 
	{
		MoveToAI (enemyChoice);


		UpdateHealth ();
		UpdateAmmo ();

		Attack ();

		//RunAway ();

		if (currentAmmo == 0) 
		{
			Reload ();
		}
			

		//utilityAI.HealthUtility (currentHealth, maxHealth);
		//Debug.Log (utilityAI.HealthUtility(currentHealth, maxHealth));

	}

	GameObject SelectRandomEnemy()
	{
		int selectRandom = Random.Range (0, targets.Length);
		enemyChoice = targets [selectRandom];
		return enemyChoice;
	}

	void MoveToAI(GameObject targetSelected)
	{
		transform.LookAt (targetSelected.transform.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

		if (Vector3.Distance (transform.position, targetSelected.transform.position) > attackInRange) 
		{
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}

	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
	}

	public void UpdateHealth()
	{
		healthText.text = "Health " + currentHealth.ToString();
	}

	public void ShootBullet()
	{
		currentAmmo -= 1;
	}

	public void UpdateAmmo()
	{
		ammoText.text = "Ammo: " + currentAmmo.ToString();
	}

	public void Attack()
	{
		if ((Time.time - lastFired > 1 / fireRate) && currentAmmo > 0) 
		{
			lastFired = Time.time;
			GameObject proj = Instantiate (projectile, projectileSpawn.transform.position, Quaternion.Euler (projectileSpawn.transform.forward)) as GameObject;
			proj.GetComponent<BaseProjectileScript> ().FireProjectile2 (projectileSpawn, enemyChoice , damage);
			ShootBullet ();
		}
			
	}

	public void Heal()
	{
		
	}

	public void Reload()
	{
		StartCoroutine (ReloadGun ());
	}

	IEnumerator ReloadGun()
	{
		yield return new WaitForSeconds (3.0f);
		currentAmmo = ammoCapacity;
	}

	 public void RunAway()
	{
		transform.LookAt (safeZone.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

		if (Vector3.Distance (transform.position, safeZone.position) > attackInRange) 
		{
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
		
	}



}
