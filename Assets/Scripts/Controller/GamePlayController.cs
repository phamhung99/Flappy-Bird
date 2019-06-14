using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, endScoreText, bestScoreText;

	[SerializeField]
	private GameObject gameOverPanel;

	[SerializeField]
	private Button instructionButton, instructionButton_1;



	public Image Gold, Sliver, Copper;

	void Awake(){
		Time.timeScale = 0;
		_MakeInstance();

	}

	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void _InstructionButton(){
		Time.timeScale = 1;
		instructionButton_1.gameObject.SetActive (false);
		instructionButton.gameObject.SetActive (false);
	}

	public void _SetScore(int score){
		scoreText.text = "" + score;
	}
//	IEnumerator Stop(){
//		yield return new WaitForSecondsRealtime (5);

//	}

	public void _BirdDiedShowPanel(int score){
	//	StartCoroutine (Stop ());
		
		gameOverPanel.SetActive (true);
		endScoreText.text = "" + score;
		if (score > GameManager.instance.GetHighScore()) {
			GameManager.instance.SetHighScore (score);
		}
		bestScoreText.text = "" + GameManager.instance.GetHighScore ();

	//	AdmobInterstitial.instance.GameOver ();
		AdmobReward.instance._Show();

		}


	public void _RestartGameButton(){
		
		Application.LoadLevel ("GamePlay");
	}
}
