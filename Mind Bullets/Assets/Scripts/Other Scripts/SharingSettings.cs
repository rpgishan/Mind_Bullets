using UnityEngine;
using System.Collections;

public class SharingSettings : MonoBehaviour {

	public void shareOnTwitter(){
		Application.OpenURL ("https://twitter.com/intent/tweet?text=Hey+,+I+just+completed+a+level+in+mind+bullets.+It+is+awesome.&amplang=eng");
	}

	public void shareOnTwitterWithHashTag(){
		Application.OpenURL ("https://twitter.com/intent/tweet?&text=Feedback%20&hashtags=MindBullets");
	}
}
