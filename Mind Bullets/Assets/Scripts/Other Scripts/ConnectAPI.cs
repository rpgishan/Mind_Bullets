using UnityEngine;
using System.Collections;

public class ConnectAPI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void getData(){
		string APIUrl = "http://date.jsontest.com";

		WWW APIWWW = new WWW (APIUrl);
	//	yield return APIWWW;

		//JSONObject tempData = new JSONObject (APIWWW.text);
		JsonScripts js = new JsonScripts();
		js.decJson (APIWWW.text);
	}
}
