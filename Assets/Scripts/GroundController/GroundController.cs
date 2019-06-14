using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{

	private float speed;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		_GroundMovement ();
	}


	void _GroundMovement ()
	{
		if (BirdController.instance.flag == 0) {
		//	speed = 0;
		
			if (BirdController.instance.score >= 50) {
				speed = 4;
			} else {
				if (BirdController.instance.score >= 20) {
					speed = 3.5f;
				} else {
					speed = 3;
				}
			}

			Vector3 temp = transform.position;
			temp.x -= speed * Time.deltaTime;
			transform.position = temp;
		}
	}

	void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Destroy") {
			Destroy (gameObject);
		}
	}
}
