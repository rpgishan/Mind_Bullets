using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

	string pickedPile;

	void OnEnable(){
		pickedPile = null;
	}

	void Update () {
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (ray, out hit);

			if (hit.transform.tag == "PlayerL2") {	//hit on the cube
				GameObject.FindGameObjectWithTag ("Managers").GetComponent<PhotonView> ().RPC ("PickCountReset", PhotonTargets.All, null);
				GetComponent<PhotonView> ().RPC ("SwitchTurn", PhotonTargets.All, null);
			} else if ((hit.transform.tag == "Pile1BulletL2") || (hit.transform.tag == "Pile2BulletL2") || (hit.transform.tag == "Pile3BulletL2")) {
				//hit on a bullet
				if (pickedPile == null) {	//if its a new turn this becomes true and the tag of the first picked bullet will be stored
					pickedPile = hit.transform.tag;
				}

				if (pickedPile.Equals (hit.transform.tag)) {	//this is true if the next picked bullets belong to the same pile
					hit.collider.transform.GetComponent<PhotonView> ().RPC ("Pick", PhotonTargets.MasterClient, null);
				}
			} else if (hit.transform.tag == "MagicBullet") {
				//hit on magic bullet
				GameObject.FindGameObjectWithTag ("Managers").GetComponent<PhotonView> ().RPC("MagicBulletActivator",PhotonTargets.All,true);
			}else{
				//hit on something else				
			}
		}
	}

	void OnDisable(){
		GameObject.FindGameObjectWithTag ("Managers").GetComponent<PhotonView> ().RPC("MagicBulletActivator",PhotonTargets.All,false);
	}
}