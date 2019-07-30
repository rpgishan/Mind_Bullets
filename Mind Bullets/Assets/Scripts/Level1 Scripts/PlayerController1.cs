using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {
	
	string pickedPile;

	void OnEnable(){
		pickedPile = null;
	}

	void Update () {
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (ray, out hit);
		
			if (hit.transform.tag == "PlayerL1") {	//hit on the cube
				GetComponent<PhotonView> ().RPC ("SwitchTurn", PhotonTargets.All, null);

			} else if ((hit.transform.tag == "Pile1BulletL1") || (hit.transform.tag == "Pile2BulletL1") || (hit.transform.tag == "Pile3BulletL1")) {
				//hit on a bullet
				if (pickedPile == null) {	//if its a new turn this becomes true and the tag of the first picked bullet will be stored
					pickedPile = hit.transform.tag;
				}

				if (pickedPile.Equals (hit.transform.tag)) {	//this is true if the next picked bullets belong to the same pile
					hit.collider.transform.GetComponent<PhotonView> ().RPC ("Pick", PhotonTargets.All, null);
				}
			} else {
				//hit on something else				
			}
		}
	}
}