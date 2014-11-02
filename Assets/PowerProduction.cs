using Glide;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerProduction : MonoBehaviour
{

	public bool playerControlled;
	public int windPower = 10;
	public int cows = 0;
	public float cattleonium = 30;
	public SpriteRenderer windMill;

	public Text CowPowerText;
	public Text CattleoniumText;

	private Tweener Tweener = new Tweener();


	public int TotalCowPower
	{
		get { return windPower + cows; }
	}


	void OnTriggerEnter(Collider other)
	{
		cows ++;
		var scaleWrap = new TweenTransformWrap(other.transform);
		Tweener.Tween(scaleWrap, new { LocalScaleX = 0f }, 1.5f).OnComplete(() => Destroy(other.gameObject));
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Tweener.Update(Time.deltaTime);

		cattleonium += TotalCowPower * 0.1f * Time.deltaTime;

		if (playerControlled)
		{
			CowPowerText.text = TotalCowPower.ToString();
			CattleoniumText.text = ((int)cattleonium).ToString();
		}

		// Make the windmill rotate faster with more cow power
		windMill.transform.Rotate(0, 0, (TotalCowPower * TotalCowPower) / 2f * Time.deltaTime);
	}


	public bool TakeCattleonium(int i)
	{
		if (cattleonium >= i)
		{
			cattleonium -= i;
			return true;
		}
		return false;
	}
}
