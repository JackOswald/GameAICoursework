using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

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

	public GameObject[] healthPacks;
	public GameObject healthChoice;

	public GameObject[] ammoPacks;
	public GameObject ammoChoice;

	public float fireRate = 1.0f;
	public float lastFired;

	public bool isInSafeZone = false;

	public Transform safeZone;

	public UtilityAI utilityAI;

	 public float utilityCooldownTimer;

	// Use this for initialization
	void Start () 
	{
		utilityAI = GetComponent<UtilityAI> ();

		//aiAgent = GameObject.FindGameObjectWithTag ("Agent");
		currentHealth = maxHealth;

		currentAmmo = ammoCapacity;

		inRange = false;
	}

	// Update is called once per frame
	void Update () 
	{
		UpdateHealth ();
		UpdateAmmo ();

		utilityCooldownTimer += Time.deltaTime;

		/*if (utilityCooldownTimer >= 5.0f) 
		{
			HighestUtility ();
			utilityCooldownTimer = 0.0f;
		}*/

		//RunAway ();
		//SelectRandomAction ();
		HighestUtility();

	}

	/*GameObject SelectRandom(GameObject[] objects, GameObject randomChoice)
	{
		int selectRandom = Random.Range (0, objects.Length);
		randomChoice = objects [selectRandom];
		return randomChoice;
	}*/

	#region RandomSelection
	GameObject SelectRandomEnemy()
	{
		int selectRandom = Random.Range (0, targets.Length);
		enemyChoice = targets [selectRandom];
		return enemyChoice;
	}

	GameObject SelectRandomHealthPack()
	{
		int selectRandom = Random.Range (0, healthPacks.Length);
		healthChoice = healthPacks [selectRandom];
		return healthChoice;
	}

	GameObject SelectRandomAmmoPack()
	{
		int selecRandom = Random.Range (0, ammoPacks.Length);
		ammoChoice = ammoPacks [selecRandom];
		return ammoChoice;
	}
	#endregion


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

	#region Attack
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
	#endregion

	#region Heal
	void Heal(GameObject healthPackSelected)
	{ 
		transform.LookAt (healthPackSelected.transform.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
		transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
	}

	public void AddHealth(int healAmount)
	{
		currentHealth += healAmount;

		if (currentHealth > maxHealth) 
		{
			currentHealth = maxHealth;
		}

		UpdateHealth ();
	}
	#endregion

	#region Reload
	public void Reload(GameObject selected)
	{
		transform.LookAt (selected.transform.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
		transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		//StartCoroutine (ReloadGun ());
	}

	public void AddBullets()
	{
		currentAmmo = ammoCapacity;
	}

	IEnumerator ReloadGun()
	{
		yield return new WaitForSeconds (3.0f);
		currentAmmo = ammoCapacity;
	}
	#endregion

	#region Run
	public void RunAway()
	{
		transform.LookAt (safeZone.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

		if (Vector3.Distance (transform.position, safeZone.position) > attackInRange) 
		{
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
			
	}

	void SelectRandomAction()
	{
		int random = Random.Range (0, 2);
		if (random == 0) 
		{
			AddHealth (5);
			Debug.Log ("Add health");
		} 
		else 
		{
			AddBullets ();
			Debug.Log ("Add bullets");
		}
	}
	#endregion


	public void HighestUtility()
	{
		if (utilityAI.arrayList.Max() == utilityAI.utilityHealthScore) 
		{	
			SelectRandomHealthPack ();
			Heal (healthChoice);
		}

		if (utilityAI.arrayList.Max () == utilityAI.utilityAttackScore)
		{
			SelectRandomEnemy ();
			MoveToAI (enemyChoice);
			Attack ();
		}

		if (utilityAI.arrayList.Max () == utilityAI.utilityRunScore) 
		{
			RunAway ();
			Debug.Log("run");
			utilityAI.utilityRunScore = 0;
		}

		if (utilityAI.arrayList.Max () == utilityAI.utilityReloadScore) 
		{
			SelectRandomAmmoPack ();
			Reload (ammoChoice);
		}
	}
		
}
