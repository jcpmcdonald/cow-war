using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour
{

	private float warToMillRatio = 1.5f;
	private float cowsSentToWar = 1;
	private float cowsSentToMill = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		BarnSpawn barn = GetComponent<BarnSpawn>();
		if (barn.powerProduction.cattleonium >= barn.cowCost)
		{
			if ((cowsSentToWar / cowsSentToMill) > warToMillRatio)
			{
				barn.SpawnMillCow();
				cowsSentToMill++;
			}
			else
			{
				barn.SpawnFighterCow();
				cowsSentToWar++;
			}
		}
	}
}
