using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_PiprMovement();
		if (BirdController.instance != null) {
			if (BirdController.instance.flag == 1) {
				Destroy (GetComponent <PipeController> ());
			}
		}

	}

	void _PiprMovement() {
		
		Vector3 temp = transform.position;
		temp.x -=  speed * Time.deltaTime;
		transform.position = temp;
	}

	//void OnCollisionEnter2D(CapsuleCollider2D targer){

	//}

	void OnTriggerEnter2D(Collider2D targer){
		if (targer.tag == "Destroy") {
			Destroy (gameObject); // xóa gameObject PipeController
		}
	}
}
