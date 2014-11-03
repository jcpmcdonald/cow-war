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

	public AudioClip deadSoundClip;

	public int team;

	public bool alive = true;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(2.2f * Time.deltaTime * transform.localScale.x, 0, 0);

		Tweener.Update(Time.deltaTime);
	}


	void OnTriggerEnter(Collider other)
	{
		Cow cow = other.gameObject.GetComponent<Cow>();
		if (cow != null && cow.team != team && cow.alive && alive)
		{
			cow.alive = false;
			alive = false;

			GetComponent<AudioSource>().PlayOneShot(deadSoundClip);

			Kill();
			other.gameObject.GetComponent<Cow>().Kill();
		}
	}


	public void Kill()
	{
		GameObject boom = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
		boom.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		Destroy(boom, 0.8f);

		var scaleWrap = new TweenTransformWrap(transform);
		Tweener.Tween(scaleWrap, new { LocalScaleX = 0f }, 0.5f).OnComplete(() => Destroy(gameObject));
	}
}
