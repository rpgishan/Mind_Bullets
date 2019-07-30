using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ShowData : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getUserData(int usercode){
		
		string APIUrl = "http://date.jsontest.com";
		User user = new User ();

		WWW APIWWW = new WWW (APIUrl);
		//	yield return APIWWW;

		user = JsonUtility.FromJson<User> (APIWWW.text);
	}
}
