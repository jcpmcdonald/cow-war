using System;
using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour
{

	private bool mouseIsDown;
	private Vector2 mouseGrabLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			mouseGrabLocation = camera.ScreenToWorldPoint(Input.mousePosition);
		}

		if (Input.GetMouseButton(0))
		{
			float deltaX = mouseGrabLocation.x - camera.ScreenToWorldPoint(Input.mousePosition).x;
			transform.position = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z);
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Keypad6))
		{
			transform.Translate(15f * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Keypad4))
		{
			transform.Translate(-15f * Time.deltaTime, 0f, 0f);
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
