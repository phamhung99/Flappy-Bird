using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobInterstitial : MonoBehaviour
{
	public static AdmobInterstitial instance;

	private InterstitialAd interstitial;

	void Awake ()
	{
		_MakeInstance ();
	}


	void _MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	public void Start ()
	{
		#if UNITY_ANDROID
		string appId = "ca-app-pub-8762939070073191~8691257591";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3940256099942544~1458002511";
		#else
		string appId = "unexpected_platform";
		#endif

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize (appId);
		this.RequestInterstitial ();
		this.GameOver ();
	}

	private void RequestInterstitial ()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-8762939070073191/1711804328";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/4411468910";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd (adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder ().Build ();
		// Load the interstitial with the request.
		interstitial.LoadAd (request);
		//interstitial.Show ();
	}

		public void GameOver ()
	{
		if (interstitial.IsLoaded ()) {
			interstitial.Show ();
		}
	}

}
