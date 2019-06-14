using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobReward : MonoBehaviour {

	private RewardBasedVideoAd rewardBasedVideo;

	public static AdmobReward instance;



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
	public void Start()
	{
		#if UNITY_ANDROID
		string appId = "ca-app-pub-9335373935858246/5681927472";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3940256099942544~1458002511";
		#else
		string appId = "unexpected_platform";
		#endif

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);

		// Get singleton reward based video ad reference.
		this.rewardBasedVideo = RewardBasedVideoAd.Instance;

		this.RequestRewardBasedVideo();
		}

		private void RequestRewardBasedVideo()
		{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-8762939070073191/1068643475";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/1712485313";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the rewarded video ad with the request.
		this.rewardBasedVideo.LoadAd(request, adUnitId);
		}
		public void _Show()
		{
		rewardBasedVideo.Show();
		}

}
