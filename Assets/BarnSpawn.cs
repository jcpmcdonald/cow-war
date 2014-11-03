using System;
using Glide;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class BarnSpawn : MonoBehaviour
{

	public PowerProduction powerProduction;
	public Transform cow;
	public Transform spawnPoint;
	public Transform millSpawnPoint;

	public int health;
	public int team;

	internal int cowCost = 10;

	private Tweener Tweener = new Tweener();

	public Text GameEndText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Tweener.Update(Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		Cow cow = other.gameObject.GetComponent<Cow>();
		if (cow != null && cow.team != team && cow.alive)
		{
			health --;
			cow.alive = false;

			if (health <= 0)
			{
				if (team == 1)
				{
					// Player wins!
					GameEndText.text = "You are victorious!";
					GameEndText.enabled = true;
				}
				else
				{
					// AI Wins
					GameEndText.text = "You have been defeated";
					GameEndText.enabled = true;
				}

				Time.timeScale = 0.2f;
			}

			cow.GetComponent<AudioSource>().PlayOneShot(cow.deadSoundClip);
			cow.Kill();
		}
		//var scaleWrap = new TweenTransformWrap(other.transform);
		//Tweener.Tween(scaleWrap, new { LocalScaleX = 0f }, 1.5f).OnComplete(() => Destroy(other.gameObject));
	}


	public void SpawnFighterCow()
	{
		if (powerProduction.TakeCattleonium(cowCost))
		{
			float randY = Random.Range(-0.2f, 0.2f);
			Transform t = Instantiate(cow, spawnPoint.position + new Vector3(0, randY, randY / 2), Quaternion.identity) as Transform;
			t.localScale = new Vector3(t.localScale.x * Math.Sign(transform.transform.localScale.x), t.localScale.y, t.localScale.z);
			t.GetComponent<Cow>().team = team;
		}
	}

	public void SpawnMillCow()
	{
		if (powerProduction.TakeCattleonium(cowCost))
		{
			float randY = Random.Range(-0.2f, 0.2f);
			Transform t = Instantiate(cow, millSpawnPoint.position + new Vector3(0, randY, randY / 2), Quaternion.identity) as Transform;
			t.localScale = new Vector3(t.localScale.x * -Math.Sign(transform.transform.localScale.x), t.localScale.y, t.localScale.z);
			t.GetComponent<Cow>().team = team;
		}
	}
}
