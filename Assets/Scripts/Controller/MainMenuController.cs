using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
	

	public void _PlayButton(){
		

		Application.LoadLevel ("GamePlay");// chuyển đến màn hình GamePlay
	//	SceneManager.LoadScene("GamePlay");
	}

}
