using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour {

	public float time1, time2, time3;

	[SerializeField]
	private GameObject pipeHolder1, pipeHolder2, pipeHolder3;
	// Use this for initialization
	void Start () {
		StartCoroutine (Spawner ());
	}
	
	// Update is called once per frame

	IEnumerator Spawner(){ 
		
		if (BirdController.instance.score >= 48) {
			yield return new WaitForSeconds (time3); // đợi time3 s
		//	pipeHolder2.SetActive (false);
			Vector3 tem = pipeHolder1.transform.position;
			tem.y = Random.Range (-2.5f, 2.5f);

			Instantiate (pipeHolder1, tem, Quaternion.identity);
			StartCoroutine (Spawner ());


	
		} else {
			if (BirdController.instance.score >= 18) {
				yield return new WaitForSeconds (time2);
			//	pipeHolder3.SetActive (false);
				Vector3 tem = pipeHolder2.transform.position;
				tem.y = Random.Range (-2.5f, 2.5f);

				Instantiate (pipeHolder2, tem, Quaternion.identity);
				StartCoroutine (Spawner ());
			} else {
				yield return new WaitForSeconds (time1);
				Vector3 tem = pipeHolder3.transform.position;
				tem.y = Random.Range (-2.5f, 2.5f);

				Instantiate (pipeHolder3, tem, Quaternion.identity);
				StartCoroutine (Spawner ());
			}
		}


	}
}
