using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGround : MonoBehaviour {

	[SerializeField]
	public float time;

	[SerializeField]
	private GameObject ground;

	private GameObject spawner;
	// Use this for initialization
	void Start () {
		StartCoroutine (_Spawner ());
	}

	void Awake(){
		spawner = GameObject.Find ("Spawner Ground");
	}
	IEnumerator _Spawner(){
		yield return new WaitForSeconds (time);
		Vector3 tem = ground.transform.position;
		Instantiate (ground, tem, Quaternion.identity);
		if (BirdController.instance.isAlive == true) {
			StartCoroutine (_Spawner ());
		} else {
			Destroy (spawner);
		}
	}
}
