using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		BarnSpawn barn = GetComponent<BarnSpawn>();
		if (barn.powerProduction.TotalCowPower >= barn.cowCost)
		{
			barn.SpawnMillCow();
		}
	}
}
