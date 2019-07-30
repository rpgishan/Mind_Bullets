using UnityEngine;
using System.Collections;

public class FloorDestroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (PhotonNetwork.isMasterClient) {	
			PhotonNetwork.Destroy (other.gameObject);
		}else{
			GetComponent<PhotonView>().RPC("DestroyOverflow",PhotonTargets.Others,other);
		}
	}

	[PunRPC]
	void DestroyOverflow(Collider other){
		PhotonNetwork.Destroy (other.gameObject);
	}
}
