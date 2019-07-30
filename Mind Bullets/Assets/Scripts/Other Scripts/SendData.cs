using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class SendData : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void sendD(string un,string pw){
		User user = new User ();
		user.username = un;
		user.paasword = pw;

		string jsonString = JsonUtility.ToJson (user);

	}

}
