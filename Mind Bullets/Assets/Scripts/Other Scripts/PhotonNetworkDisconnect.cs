using UnityEngine;
using System.Collections;

public class PhotonNetworkDisconnect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PhotonNetwork.connected) {
			PhotonNetwork.Disconnect ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
