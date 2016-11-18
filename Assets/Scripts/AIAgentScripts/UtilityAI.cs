using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UtilityAI : MonoBehaviour {

	public AIScript aiScript;

	public float utilityHealthScore;
	public float utilityRunScore;
	public float utilityReloadScore;
	public float utilityAttackScore;

	//float eulersNumber = 2.7182818284590452353602874713527f;
	public float eulersNumber = 2.71828f;

	public Text healthUtilityText;
	public Text runUtilityText;
	public Text reloadUtilityText;
	public Text attackUtilityText;

	public float testList;

	public List<float> utilityList = new List<float>();
	public 

	// Use this for initialization
	void Start () 
	{
		aiScript = GetComponent<AIScript> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CalculateHealthUtility ();
		DisplayHealthUtility ();

		CalculateRunAwayUtility ();
		DisplayRunUtility ();

		CalculateReloadUtility ();
		DisplayReloadUtility ();

		CalculateAttackUtility ();
		DisplayAttackUtility ();

		//utilityList.Insert (0, utilityHealthScore);
		//utilityList.Insert (1, utilityRunScore);
		//utilityList.Insert (2, utilityReloadScore);
		//utilityList.Insert (3, utilityAttackScore);

	}

	 void CalculateHealthUtility()
	{
		float exponent = -(( aiScript.currentHealth / aiScript.maxHealth * 12)) + 6.5f;
		float denominator = 1 + Mathf.Pow ((eulersNumber), exponent);  //eulersNumber * 0.68
		utilityHealthScore = 1 - (1 / denominator);
		utilityHealthScore = Mathf.Clamp (utilityHealthScore, 0.0f, 1.0f);
	}

	void CalculateRunAwayUtility()
	{
		utilityRunScore = 1 - (aiScript.currentHealth / aiScript.maxHealth);
		utilityRunScore = Mathf.Clamp (utilityRunScore, 0.0f, 1.0f);
	}

	void CalculateReloadUtility()
	{
		utilityReloadScore = (1 - Mathf.Pow((aiScript.currentAmmo / aiScript.ammoCapacity), 2));
		utilityReloadScore = Mathf.Clamp (utilityReloadScore, 0.0f, 1.0f);
	}

	void CalculateAttackUtility()
	{
		utilityAttackScore = (utilityHealthScore + utilityReloadScore + utilityRunScore) / 3;
	}
		
	void DisplayHealthUtility()
	{
		healthUtilityText.text = "Health Utility: " + utilityHealthScore.ToString();
	}

	void DisplayRunUtility()
	{
		runUtilityText.text = "Run Utility: " + utilityRunScore.ToString();
	}

	void DisplayReloadUtility()
	{
		reloadUtilityText.text = "Reload Utility: " + utilityReloadScore.ToString();
	}

	void DisplayAttackUtility()
	{
		attackUtilityText.text = "Attack Utility: " + utilityAttackScore.ToString ();
	}

	void AddUtilitiesToList()
	{
		
	}

}
