using UnityEngine;
using System.Collections;

public class BulletController1 : MonoBehaviour {

	[PunRPC]
	public void Pick (){
		if (GetComponent<PhotonView> ().instantiationId == 0) {
			Destroy (this.gameObject);
		} else if(PhotonNetwork.isMasterClient) {			
			PhotonNetwork.Destroy (this.gameObject);
		}
	}
}