using UnityEngine;
using System.Collections;

public class SwitchPlayer1 : Photon.MonoBehaviour {

	[PunRPC]
	public void SwitchTurn(){
		//rotation
		if (gameObject.transform.rotation.eulerAngles.y == 0)  {
			gameObject.transform.rotation = new Quaternion (0f, 180f, 0f, 0f);
		}else if (gameObject.transform.rotation.eulerAngles.y == 180)  {
			gameObject.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		}

		//switching
		PlayerController1 pc = GetComponent<PlayerController1> ();
		if (pc.enabled == true) {
			pc.enabled = false;
		}else if(pc.enabled ==false){
			pc.enabled = true;
		}
	}
}