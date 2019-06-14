using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
	private GameObject spawner;
	public static BirdController instance;

	public float bounceForce;
	// độ nảy lên

	public Rigidbody2D myBody;
	private Animator anim;
   


	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip flyClip, pingClip, diedClip;



	public bool isAlive;
	//private bool didFlap;
	public int score = 0;
	public float flag = 0;


	IEnumerator _Delay()
	{
		yield return new WaitForSeconds (0.5f);
		if (GamePlayController.instance != null) {


			GamePlayController.instance._BirdDiedShowPanel (score);
		}
		if (score >= 100) {
			GamePlayController.instance.Gold.gameObject.SetActive (true);
		} else {
			if (score >= 50) {
				GamePlayController.instance.Sliver.gameObject.SetActive (true);
			} else {
				if (score >= 20) {
					GamePlayController.instance.Copper.gameObject.SetActive (true);
				}
			}

		}

	}


	// Use this for initialization
	void Awake ()
	{ // Awake là hàm khởi tạo 1 thứ gì đó
		isAlive = true;
		myBody = GetComponent<Rigidbody2D> (); 
		anim = GetComponent<Animator> ();
		_MakeInstance ();
		spawner = GameObject.Find ("Spawner Pipe");

	}

	void _MakeInstance ()
	{
		if (instance == null) {
			instance = this;

		}
	}
	
	// Update is called once per frame

	void FixedUpdate ()
	{ // dùng vật lý thì dùng hàm fixedUpdate
		_BirdMoveMent ();
	}

	void _BirdMoveMent ()
	{

		//if (isAlive) {
		//	if (didFlap) {
		//		didFlap = false;
		//		myBody.velocity = new Vector2 (myBody.velocity.x, bounceForce); // vận tốc
		//		audioSource.PlayOneShot (flyClip);
		//	}
		//}



		if (myBody.velocity.y > 0) {
			float angel = 0;
			angel = Mathf.Lerp (0, 90, myBody.velocity.y / 10); // tính góc trả về phép toán nội suy giữa a và b theo t
			transform.rotation = Quaternion.Euler (0, 0, angel); // trả về góc xoay
		} else if (myBody.velocity.y < 0) {
			float angel = 0;
			angel = Mathf.Lerp (0, -90, -myBody.velocity.y / 14);
			transform.rotation = Quaternion.Euler (0, 0, angel);
		} 
	}

	public void _FlapButton ()
	{
		//didFlap = true;
		if (isAlive) {
			myBody.velocity = new Vector2 (myBody.velocity.x, bounceForce); // vận tốc
			audioSource.PlayOneShot (flyClip);
		}
	}



	void OnTriggerEnter2D (Collider2D target)
	{  // sử dụng nếu 1 trong 2 có is trigger

		if (target.tag == "PipeHolder") { // PipeHolder là 1 gameObject nên ko cần thêm gameObject
			score++;
			audioSource.PlayOneShot (pingClip);
			if (GamePlayController.instance != null) {
				GamePlayController.instance._SetScore (score);
			}

		}
	}



	void OnCollisionEnter2D (Collision2D target)
	{ // sử dụng nếu cả 2 đều ko có is trigger
		if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground") { // đối tượng ko phải là gameObject thì phải thêm .gameObject
			flag = 1;
			if (isAlive) {
				isAlive = false;
				Destroy (spawner);
		
				audioSource.PlayOneShot (diedClip);
				anim.SetTrigger ("Died");

			}

			StartCoroutine (_Delay ());

		}
	//	AdmobInterstitial.instance.GameOver ();
	}

}
