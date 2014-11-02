using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class BarnSpawn : MonoBehaviour
{

	public PowerProduction powerProduction;
	public Transform cow;
	public Transform spawnPoint;
	public Transform millSpawnPoint;


	private int cowCost = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SpawnFighterCow()
	{
		if (powerProduction.TakeCattleonium(cowCost))
		{
			Instantiate(cow, spawnPoint.position + new Vector3(0, Random.Range(-0.2f, 0.2f), 0), Quaternion.identity);
		}
	}

	public void SpawnMillCow()
	{
		if (powerProduction.TakeCattleonium(cowCost))
		{
			Transform t = Instantiate(cow, millSpawnPoint.position + new Vector3(0, Random.Range(-0.2f, 0.2f), 0), Quaternion.identity) as Transform;
			t.localScale = new Vector3(-t.localScale.x, t.localScale.y, t.localScale.z);
		}
	}
}
