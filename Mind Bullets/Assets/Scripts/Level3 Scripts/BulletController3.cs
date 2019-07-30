using UnityEngine;
using System.Collections;

public class BulletController3 : MonoBehaviour {

	[PunRPC]
	public void Pick (){
		if (PhotonNetwork.isMasterClient) {	
			PhotonNetwork.Destroy (this.gameObject);
		}
	}
}