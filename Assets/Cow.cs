using UnityEngine;
using System.Collections;
using Glide;

public class Cow : MonoBehaviour
{
	private Tweener Tweener = new Tweener();

	public SpriteRenderer HindRightLeg;
	public SpriteRenderer HindLeftLeg;
	public SpriteRenderer FrontRightLeg;
	public SpriteRenderer FrontLeftLeg;
	public SpriteRenderer Tail;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(2.2f * Time.deltaTime * transform.localScale.x, 0, 0);

		HindRightLeg.transform.Rotate(0, 0, 45 * Time.deltaTime);
		HindRightLeg.transform.Rotate(0, 0, 45 * Time.deltaTime);
		HindRightLeg.transform.Rotate(0, 0, 45 * Time.deltaTime);
		HindRightLeg.transform.Rotate(0, 0, 45 * Time.deltaTime);
	}
}
