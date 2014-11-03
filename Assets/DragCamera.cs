using System;
using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour
{

	private bool mouseIsDown;
	private Vector2 mouseGrabLocation;

	public Transform leftBound;
	public Transform rightBound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float? intendedX = null;

		if (Input.GetMouseButtonDown(0))
		{
			mouseGrabLocation = camera.ScreenToWorldPoint(Input.mousePosition);
		}

		if (Input.GetMouseButton(0))
		{
			float deltaX = mouseGrabLocation.x - camera.ScreenToWorldPoint(Input.mousePosition).x;
			intendedX = transform.position.x + deltaX;
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Keypad6))
		{
			intendedX = transform.position.x + (15f * Time.deltaTime);
			//transform.Translate(15f * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Keypad4))
		{
			intendedX = transform.position.x - (15f * Time.deltaTime);
			//transform.Translate(-15f * Time.deltaTime, 0f, 0f);
		}

		if (intendedX != null)
		{
			if (intendedX < leftBound.position.x)
			{
				intendedX = leftBound.position.x;
			}
			if (intendedX > rightBound.position.x)
			{
				intendedX = rightBound.position.x;
			}
			transform.position = new Vector3(intendedX.Value, transform.position.y, transform.position.z);
		}

		//if (Input.touchCount > 0)
		//{
		//	Touch touch = Input.GetTouch(0);
		//	if (touch.phase == TouchPhase.Moved)
		//	{
		//		transform.Translate(touch.deltaPosition.x, 0, 0);
		//	}
		//}
	}
}
