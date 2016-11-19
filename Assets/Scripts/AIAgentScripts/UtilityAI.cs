using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

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
	public Text highestUtility;

	public float testList;

	public List<float> utilityList = new List<float>();
	public float[] arrayList;
	//public ArrayList arr = new ArrayList();

	// Use this for initialization
	void Start () 
	{
		aiScript = GetComponent<AIScript> ();

		arrayList = new float[4];

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

		DisplayHighestUtility ();

		arrayList [0] = utilityHealthScore;
		arrayList [1] = utilityRunScore;
		arrayList [2] = utilityReloadScore;
		arrayList [3] = utilityAttackScore;
	
		//Debug.Log (Mathf.Max ((float)arrayList [0], (float)arrayList [1]));

		//Debug.Log (arrayList.Max ());

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
		//float healthRun = 1 - (aiScript.currentHealth / aiScript.maxHealth);
		//float ammoRun = 1 - (aiScript.currentAmmo / aiScript.ammoCapacity);
		//utilityRunScore = Mathf.Pow((aiScript.currentHealth/aiScript.maxHealth) / (aiScript.currentAmmo/aiScript.ammoCapacity), 2);
		utilityRunScore = Mathf.Clamp (utilityRunScore, 0.0f, 1.0f);
	}

	void CalculateReloadUtility()
	{
		utilityReloadScore = Mathf.Pow((aiScript.currentAmmo/aiScript.ammoCapacity) - 1 ,2);
		utilityReloadScore = Mathf.Clamp (utilityReloadScore, 0.0f, 1.0f);
	}

	void CalculateAttackUtility()
	{
		utilityAttackScore = Mathf.Pow((aiScript.damage / aiScript.currentHealth),2);
		utilityAttackScore = Mathf.Clamp (utilityAttackScore, 0.5f, 1);
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

	void DisplayHighestUtility()
	{
		highestUtility.text = "Highest Utility: " + arrayList.Max ().ToString();
	}
}
