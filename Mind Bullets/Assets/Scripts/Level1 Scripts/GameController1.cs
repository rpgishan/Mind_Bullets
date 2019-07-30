using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController1 : MonoBehaviour {
	public Transform gen1;
	public Transform gen2;
	public Transform gen3;

	string pile1Bullet= "Pile1BulletL1";
	string pile2Bullet= "Pile2BulletL1";
	string pile3Bullet= "Pile3BulletL1";
	bool isMute;
	bool sign = true;

	void Update () {		
			if (sign == true) {
			firstGen ();
			seconddGen ();
			thirdGen ();
			sign = false;
			}		
	}

	void firstGen(){
		int toGen =  Random.Range(1,10);
		for (int i = 1; i <= toGen; i++) {
			GameObject newBullet =  (GameObject)PhotonNetwork.Instantiate(pile1Bullet, gen1.position, gen1.rotation,0);
			newBullet.GetComponent<BulletController1> ().enabled = true;
			newBullet.transform.SetParent (gen1);
		}
	}

	void seconddGen(){
		int toGen =  Random.Range(1,10);
		for (int i = 1; i <= toGen; i++) {
			GameObject newBullet =  (GameObject)PhotonNetwork.Instantiate(pile2Bullet, gen2.position, gen2.rotation,0);
			newBullet.GetComponent<BulletController1> ().enabled = true;
			newBullet.transform.SetParent (gen2);
		}
	}

	void thirdGen(){
		int toGen =  Random.Range(1,10);
		for (int i = 1; i <= toGen; i++) {
			GameObject newBullet =  (GameObject)PhotonNetwork.Instantiate(pile3Bullet, gen3.position, gen3.rotation,0);
			newBullet.GetComponent<BulletController1> ().enabled = true;
			newBullet.transform.SetParent (gen3);
		}
	}
}