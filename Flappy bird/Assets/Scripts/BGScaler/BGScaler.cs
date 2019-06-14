using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Vector3 teamScale = transform.localScale; // lay scale hien tai = 1, 1, 1
		float height = sr.bounds.size.y; // lay bien
		float width = sr.bounds.size.x; // lay bien

		float worldHeight = Camera.main.orthographicSize * 2; // chieu dai cua camera
		float worldWidth = worldHeight * Screen.width / Screen.height;

		teamScale.y = worldHeight / height;
		teamScale.x = worldWidth / width;

		transform.localScale = teamScale; // gan nguoc lai

	}
}
	
