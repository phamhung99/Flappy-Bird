using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobBanner : MonoBehaviour
{

	private BannerView bannerView;

	public void Start ()
	{
		#if UNITY_ANDROID
		string appId = "ca-app-pub-9335373935858246~7857533241";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3940256099942544~1458002511";
		#else
		string appId = "unexpected_platform";
		#endif

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize (appId);

		this.RequestBanner ();
	}

	private void RequestBanner ()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-9335373935858246/3343573160";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/2934735716";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		AdSize adSize = new AdSize(250, 250);
		bannerView = new BannerView (adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
		AdRequest requestBanner = new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
		.Build();
	

		bannerView.LoadAd (requestBanner);
		bannerView.Show ();

	}

}
